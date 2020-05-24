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

namespace AplicatieDisertatie
{
    public partial class FormInregistrare : Form
    {
        public FormInregistrare()
        {
            InitializeComponent();
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInregistrare_Load(object sender, EventArgs e)
        {

        }

        private void btnInregistrare_Click(object sender, EventArgs e)
        {
            /*
            if (txtTipTelefon.Text == "" || txtDefectConstatat.Text == "" || txtObservatii.Text == "" || txtTermenRezolvare.Text == ""
                || txtNume.Text == "" || txtPrenume.Text == "" || txtNrTelefon.Text == "" || txtModel.Text == "" || txtCuloare.Text == ""
                || txtIMEI.Text == "" || txtCodTelefon.Text == "" || txtPieseInlocuite.Text == "" || txtPretEstimativ.Text == "")
            */
            if (txtNume.Text == "" || txtPrenume.Text == "" || txtModel.Text == "" || txtPretEstimativ.Text == "")
            {
                MessageBox.Show("Completati toate campurile.");
            }
            else
            {      
                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
                using (SqlConnection DatabaseConnection = new SqlConnection(connectionString))
                {
                    DatabaseConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("InregistrareReparatie", DatabaseConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Nume", txtNume.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Prenume", txtPrenume.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Pret_estimativ", txtPretEstimativ.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Telefon", txtModel.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Reparatie inregistrata!");
                }
            }
        }
    }
}
