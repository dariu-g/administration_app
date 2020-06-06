using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

                    //Date client
                    sqlCmd.Parameters.AddWithValue("@Nume", txtNume.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Prenume", txtPrenume.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Nr_telefon", txtNrTelefon.Text.Trim());

                    //Date telefon
                    sqlCmd.Parameters.AddWithValue("@Tip_telefon", txtTipTelefon.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model", txtModel.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Culoare", txtCuloare.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Garantie", checkboxGarantie.Checked);
                    sqlCmd.Parameters.AddWithValue("@IMEI", txtIMEI.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Cod_telefon", txtCodTelefon.Text.Trim());

                    //Date reparatie
                    sqlCmd.Parameters.AddWithValue("@Data_primirii", dateDataPrimirii.Value);
                    sqlCmd.Parameters.AddWithValue("@Defect_constatat", txtDefectConstatat.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Observatii", txtObservatii.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Termen_rezolvare", txtTermenRezolvare.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Pret_estimativ", txtPretEstimativ.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Pret_avans", txtPretAvans.Text.Trim());

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Reparatie inregistrata!");
                    ClearTextBoxes();
                }
            }
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> clear_func = null;

            clear_func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        clear_func(control.Controls);
            };

            clear_func(Controls);
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
                MessageBox.Show(ex.Message, "Eroare baza de date.");
            }
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        #region TextBoxesFormatting
        private void CapitalizeFirstLetter(TextBox InputTextBox)
        {
            if (InputTextBox.Text.Length <= 0) return;
            string first_character = InputTextBox.Text.Substring(0, 1);
            if (first_character != first_character.ToUpper())
            {
                int Start = InputTextBox.SelectionStart;
                int Length = InputTextBox.SelectionLength;
                InputTextBox.SelectionStart = 0;
                InputTextBox.SelectionLength = 1;
                InputTextBox.SelectedText = first_character.ToUpper();
                InputTextBox.SelectionStart = Start;
                InputTextBox.SelectionLength = Length;
            }
        }

        private void txtNume_TextChanged(object sender, EventArgs e)
        {
            txtNume.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtNume.Text);
            txtNume.Select(txtNume.Text.Length, 0);
        }

        private void txtPrenume_TextChanged(object sender, EventArgs e)
        {
            txtPrenume.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtPrenume.Text);
            txtPrenume.Select(txtPrenume.Text.Length, 0);
        }

        private void txtTipTelefon_TextChanged(object sender, EventArgs e)
        {
            CapitalizeFirstLetter(txtTipTelefon);
        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            CapitalizeFirstLetter(txtModel);
        }

        private void txtCuloare_TextChanged(object sender, EventArgs e)
        {
            CapitalizeFirstLetter(txtCuloare);
        }

        private void txtDefectConstatat_TextChanged(object sender, EventArgs e)
        {
            CapitalizeFirstLetter(txtDefectConstatat);
        }

        private void txtObservatii_TextChanged(object sender, EventArgs e)
        {
            CapitalizeFirstLetter(txtObservatii);
        }

        private void txtIMEI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPretEstimativ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPretAvans_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion


    }
}
