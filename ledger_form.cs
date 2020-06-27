using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;


namespace AplicatieDisertatie
{
    public partial class ledger_form : Form
    {
        int ReparatieID = 0;
        public ledger_form()
        {
            InitializeComponent();
        }

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

        private void dataGridLedger_Click(object sender, EventArgs e)
        {
            if (dataGridLedger.CurrentRow.Index != -1)
            {
                ReparatieID = Convert.ToInt32(dataGridLedger.CurrentRow.Cells[0].Value.ToString());
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
    }
}