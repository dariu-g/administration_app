using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
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

        private void btnDescarca_Click(object sender, EventArgs e)
        {
            /*
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);*/

            saveFileDialog1.InitialDirectory = "C:";
            saveFileDialog1.Title = "Save as Excel File";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";

            if(saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);

                //ExcelApp.Columns.ColumnWidth = 20;

                for (int i = 1; i <dataGridLedger.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dataGridLedger.Columns[i - 1].HeaderText;
                }

                for (int i = 1; i < dataGridLedger.Rows.Count + 1; i++)
                {
                    for (int j = 1; j < dataGridLedger.Columns.Count + 1; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dataGridLedger.Rows[i].Cells[j].Value.ToString();
                    }
                }

                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();
            }
        }

        private void copyAlltoClipboard()
        {
            dataGridLedger.SelectAll();
            DataObject dataObj = dataGridLedger.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
    }
}