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
    public partial class ledger_form : Form
    {
        /* Global variables. */
        int ReparatieID = 0;

        public ledger_form()
        {
            InitializeComponent();

            Type officeType = Type.GetTypeFromProgID("Excel.Application");
            if (officeType != null)
            {
                btnDescarca.Enabled = true;
            }
            /*
            if (Directory.Exists("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Microsoft Office"))
            {
                btnDescarca.Enabled = true;
            }
            */
        }

        #region MainButtons
        private void btnCauta_Click(object sender, EventArgs e)
        {
            using (IDbConnection db_con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
            {
                if (db_con.State == ConnectionState.Closed)
                {
                    db_con.Open();
                }
                DateTime dateFROM = dateTimeDin.Value;
                DateTime dateTILL = dateTimePana.Value;
                ledgerclassBindingSource.DataSource = db_con.Query<ledger_class>("CalendarDataInregistrari", new { dateFROM, dateTILL } ,commandType: CommandType.StoredProcedure);
            }
        }
        
        private void btnReparatiiRecente_Click(object sender, EventArgs e)
        {
            using (IDbConnection db_con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
            {
                if (db_con.State == ConnectionState.Closed)
                {
                    db_con.Open();
                }

                ledgerclassBindingSource.DataSource = db_con.Query<ledger_class>("ReparatiiRecente", commandType: CommandType.StoredProcedure);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ledger_class objct = ledgerclassBindingSource.Current as ledger_class;
            if (objct != null)
            {
                using (IDbConnection db_con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
                {
                    if (db_con.State == ConnectionState.Closed)
                        db_con.Open();
                    
                    /* Storing the object id_reparatie from ledger_class in order to be sent to the stored procedure as a parameter. */
                    int obiect_ReparatieID = objct.id_reparatie;
                    List<ledgerPrint_class> list = db_con.Query<ledgerPrint_class>("PrintInregistrare", new { obiect_ReparatieID }, commandType: CommandType.StoredProcedure).ToList();
                    using (print_form form = new print_form(objct, list))
                    {
                        form.ShowDialog();
                    };
                }
            }
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
                using (SqlConnection DatabaseConnection = new SqlConnection(connectionString))
                {
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

        private void btnDescarca_Click(object sender, EventArgs e)
        {      
            if (dataGridLedger.Rows.Count > 0)
            {
                copyAlltoClipboard();
                /* A MissingValue type object (empty object) created which will be passed as a parameter to the Workbook. */
                object misValue = System.Reflection.Missing.Value;
                
                Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                Excel.Visible = true;

                /* Creates a new workbook, which becomes the active workbook. */
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook = Excel.Workbooks.Add(misValue);
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
        private void copyAlltoClipboard()
        {
            dataGridLedger.RowHeadersVisible = false;

            /* Includes the headers of the dataGridLedger. */
            //dataGridLedger.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            //dataGridLedger.MultiSelect = true;

            dataGridLedger.SelectAll();
            DataObject dataGridViewData = dataGridLedger.GetClipboardContent();
            if (dataGridViewData != null)
                Clipboard.SetDataObject(dataGridViewData);
        }
        #endregion

        /* Click event to select the id of the registration upon click. */
        private void dataGridLedger_Click(object sender, EventArgs e)
        {
            if (dataGridLedger.Rows.Count > 0)
            if (dataGridLedger.CurrentRow.Index != -1)
            {
                ReparatieID = Convert.ToInt32(dataGridLedger.CurrentRow.Cells[0].Value.ToString());
            }
        }
    }
}