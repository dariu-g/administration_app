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
            if (checkboxGarantie.CheckState == CheckState.Checked)
                checkboxGarantie.Text = "Da";
            else if (checkboxGarantie.CheckState == CheckState.Unchecked)
                checkboxGarantie.Text = "Nu";
            else
                checkboxGarantie.Text = "Eroare";
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
                    sqlCmd.Parameters.AddWithValue("@Nr_telefon", txtNrTelefon.Text.Trim());

                    sqlCmd.Parameters.AddWithValue("@Tip_telefon", txtTipTelefon.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model", txtModel.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Culoare", txtCuloare.Text.Trim());
                    //sqlCmd.Parameters.AddWithValue("@Garantie", checkboxGarantie);
                    sqlCmd.Parameters.AddWithValue("@IMEI", txtIMEI.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Cod_telefon", txtCodTelefon.Text.Trim());

                    //sqlCmd.Parameters.AddWithValue("@Data_primirii", dateDataPrimirii.Value);
                    sqlCmd.Parameters.AddWithValue("@Defect_constatat", txtDefectConstatat.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Observatii", txtObservatii.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Termen_rezolvare", txtTermenRezolvare.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Pret_estimativ", txtPretEstimativ.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Pret_avans", txtPretAvans.Text.Trim());

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Reparatie inregistrata!");
                }
            }
        }

        private void checkboxGarantie_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkboxGarantie.CheckState == CheckState.Checked)
                checkboxGarantie.Text = "Da";
            else if (checkboxGarantie.CheckState == CheckState.Unchecked)
                checkboxGarantie.Text = "Nu";
            else
                checkboxGarantie.Text = "Eroare";

        }

        void FillDataGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection DatabaseConnection = new SqlConnection(connectionString))
            {
                if (DatabaseConnection.State == ConnectionState.Closed)
                    DatabaseConnection.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter("Cauta", DatabaseConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@nume", txtCauta.Text.Trim());
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                dataGridView1.Columns[0].Visible = false;

                DatabaseConnection.Close();
            }
        }

        private void btnCauta_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }
    }
}
