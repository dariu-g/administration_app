using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper; 

namespace AplicatieDisertatie
{
    public partial class registrationLedger_form : Form
    {
        /* Class scope variables. */
        private static int ReparatieID = 0;

        public registrationLedger_form()
        {
            InitializeComponent();

            /* Checks if the Excel application exists on the PC, if yes btnDescarca is enabled. */
            Type ExcelApp = Type.GetTypeFromProgID("Excel.Application");
            if (ExcelApp != null)
            {
                btnDescarca.Enabled = true;
            }
            dataGridLedger.DoubleBufferedDataGridView(true);
        }

        #region MainButtons
        private void btnCauta_Click(object sender, EventArgs e)
        {
            using (IDbConnection db_con = new SqlConnection(connection_class.connectionString))
            {
                if (db_con.State == ConnectionState.Closed)
                {
                    db_con.Open();
                }
                DateTime dateFROM = dateTimeDin.Value.Date;
                DateTime dateTILL = dateTimePana.Value.Date;

                ledgerclassBindingSource.DataSource = db_con.Query<ledger_class>("CalendarDataInregistrari", new { dateFROM, dateTILL } ,commandType: CommandType.StoredProcedure);
            }
        }
        
        private void btnReparatiiRecente_Click(object sender, EventArgs e)
        {
            using (IDbConnection db_con = new SqlConnection(connection_class.connectionString))
            {
                if (db_con.State == ConnectionState.Closed)
                {
                    db_con.Open();
                }

                ledgerclassBindingSource.DataSource = db_con.Query<ledger_class>("ReparatiiRecente", commandType: CommandType.StoredProcedure);
            }
        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            using (IDbConnection db_con = new SqlConnection(connection_class.connectionString))
            {
                if (db_con.State == ConnectionState.Closed)
                {
                    db_con.Open();
                }

                string searchText = txtCautare.Text.Trim();
                ledgerclassBindingSource.DataSource = db_con.Query<ledger_class>("CautareGeneralaInregistrari", new { searchText }, commandType: CommandType.StoredProcedure);
            }
        }

        /* Utilizes Dapper IDbconnection, to execute PrintInregistrare procedure and stores the result in a list of type ledgerPrint_class
         * and it passes the list and an object of type ledger_class to the print_form which will use Microsoft's Report Viewer tool
         * to create a preview of the printable registration */
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ledger_class objct = ledgerclassBindingSource.Current as ledger_class;
            if (objct != null)
            {
                using (IDbConnection db_con = new SqlConnection(connection_class.connectionString))
                {
                    if (db_con.State == ConnectionState.Closed)
                        db_con.Open();
                    
                    /* Storing the object id_reparatie from ledger_class in order to be sent to the stored procedure as a parameter. */
                    int obiect_ReparatieID = objct.id_reparatie;
                    List<ledger_class> list = db_con.Query<ledger_class>("PrintInregistrare", new { obiect_ReparatieID }, commandType: CommandType.StoredProcedure).ToList();
                    using (print_form form = new print_form(objct))
                    {
                        form.ShowDialog();
                    };
                }
            }
        }

        /* Deletes all fields from a specific registration in the table Date_reparatie, based on id_reparatie. */ 
        private void btnSterge_Click(object sender, EventArgs e)
        {
            DialogResult DialogBox = MessageBox.Show("Aceasta operatiune este ireversibila. Doresti sa stergi aceasta reparatie?", "Atentionare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(DialogBox == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection DatabaseConnection = new SqlConnection(connection_class.connectionString))
                    {
                        if (DatabaseConnection.State == ConnectionState.Closed)
                            DatabaseConnection.Open();
                        SqlCommand sqlCmd = new SqlCommand("StergeReparatie", DatabaseConnection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@Reparatie_id", ReparatieID);

                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Reparatie stearsa!");
                        DatabaseConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Eroare de stergere!");
                }

            }
            else if (DialogBox == DialogResult.No)
            {

            }
        }

        /* Utilizes Microsoft.Office.Interop.Excel.dll reference in order to create a temporary Excel document which will contain
         * the data displayed in dataGridLedger. */
        private void btnDescarca_Click(object sender, EventArgs e)
        {      
            if (dataGridLedger.Rows.Count > 0)
            {
                ClipboardCopy();
                /* A MissingValue type object (empty object) created which will be passed as a parameter to the Workbook. */
                object missValue = System.Reflection.Missing.Value;
                
                Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                Excel.Visible = true;

                /* Creates a new workbook, which becomes the active workbook. */
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook = Excel.Workbooks.Add(missValue);
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

                /* [1, 1] Specifies the location at which Column/Row the pasted data from the dataGridLedger will happen in the Excel file. */
                Microsoft.Office.Interop.Excel.Range ColumnRow = (Microsoft.Office.Interop.Excel.Range)ExcelWorkSheet.Cells[1, 1];
                ColumnRow.Select();
                ExcelWorkSheet.PasteSpecial(ColumnRow, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
        }
        #endregion

        #region LocalMethods
        /* Selects all the Columns/Rows in the dataGridLedger and copies them into the clipboard. */
        private void ClipboardCopy()
        {
            dataGridLedger.RowHeadersVisible = false;

            /* Includes the headers of the dataGridLedger. */
            dataGridLedger.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridLedger.MultiSelect = true;

            dataGridLedger.SelectAll();
            DataObject dataGridViewData = dataGridLedger.GetClipboardContent();
            if (dataGridViewData != null)
                Clipboard.SetDataObject(dataGridViewData);
        }
        #endregion

        /* Click event to select the id of the registration. */
        private void dataGridLedger_Click(object sender, EventArgs e)
        {
            if (dataGridLedger.Rows.Count > 0 && dataGridLedger.CurrentRow.Index != -1)
            {
                ReparatieID = Convert.ToInt32(dataGridLedger.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void dateTimeDin_ValueChanged(object sender, EventArgs e)
        {
            dataGridLedger.Rows.Clear();
            dataGridLedger.Refresh();
        }

        private void dateTimePana_ValueChanged(object sender, EventArgs e)
        {
            dataGridLedger.Rows.Clear();
            dataGridLedger.Refresh();
        }
    }
}