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
                string query = "SELECT r.id_reparatie, c.nume, c.prenume, c.nr_telefon, t.tip_telefon, t.model, t.imei, r.data_primirii, r.data_predarii, r.defect_constatat, r.observatii, r.piese_inlocuite, r.pret_achitat FROM Date_reparatie r " +
                                "JOIN Date_client c ON r.id_client = c.id " +
                                "JOIN Date_telefon t ON r.id_telefon = t.id " +
                               $"WHERE r.data_primirii between '{dateTimeDin.Value}' and '{dateTimePana.Value}'";

                ledgerclassBindingSource.DataSource = db_con.Query<ledger_class>(query, commandType: CommandType.Text);
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
                    {
                        db_con.Open();
                    }
                    string query = "SELECT r.id_reparatie, c.nume, c.prenume, c.nr_telefon, t.tip_telefon, t.model, t.imei, r.data_primirii, r.data_predarii, r.defect_constatat, r.observatii, r.piese_inlocuite, r.pret_achitat FROM Date_reparatie r " +
                                    "JOIN Date_client c ON r.id_client = c.id " +
                                    "JOIN Date_telefon t ON r.id_telefon = t.id " +
                                   $"WHERE r.id_reparatie = '{objct.id_reparatie}'";

                    List<ledgerPrint_class> list = db_con.Query<ledgerPrint_class>(query, commandType: CommandType.Text).ToList();
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