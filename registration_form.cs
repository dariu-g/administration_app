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
using Dapper;

namespace AplicatieDisertatie
{
    public partial class registration_form : Form
    {
        public registration_form()
        {
            InitializeComponent();
            checkStateGarantie();
            checkStateClientExistent();
            checkStateTelefonExistent();
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

        #region checkBoxState
        private void checkboxGarantie_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkboxGarantie.CheckState == CheckState.Checked)
                checkboxGarantie.Text = "Da";
            else if (checkboxGarantie.CheckState == CheckState.Unchecked)
                checkboxGarantie.Text = "Nu";
            else
                checkboxGarantie.Text = "Eroare";
        }

        /* function that is called in the component initializer to place the default name of "Nu" to the checkbox */
        private void checkStateGarantie()
        {
            if (checkboxGarantie.CheckState == CheckState.Checked)
                checkboxGarantie.Text = "Da";
            else if (checkboxGarantie.CheckState == CheckState.Unchecked)
                checkboxGarantie.Text = "Nu";
            else
                checkboxGarantie.Text = "Eroare";
        }

        private void checkBoxClientExistent_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClientExistent.CheckState == CheckState.Checked)
                checkBoxClientExistent.Text = "Existent";
            else if (checkBoxClientExistent.CheckState == CheckState.Unchecked)
                checkBoxClientExistent.Text = "Nou";
            else
                checkBoxClientExistent.Text = "Eroare";
        }

        private void checkStateClientExistent()
        {
            if (checkBoxClientExistent.CheckState == CheckState.Checked)
                checkBoxClientExistent.Text = "Existent";
            else if (checkBoxClientExistent.CheckState == CheckState.Unchecked)
                checkBoxClientExistent.Text = "Nou";
            else
                checkBoxClientExistent.Text = "Eroare";
        }

        private void checkBoxTelefonExistent_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTelefonExistent.CheckState == CheckState.Checked)
                checkBoxTelefonExistent.Text = "Existent";
            else if (checkBoxTelefonExistent.CheckState == CheckState.Unchecked)
                checkBoxTelefonExistent.Text = "Nou";
            else
                checkBoxTelefonExistent.Text = "Eroare";
        }

        private void checkStateTelefonExistent()
        {
            if (checkBoxTelefonExistent.CheckState == CheckState.Checked)
                checkBoxTelefonExistent.Text = "Existent";
            else if (checkBoxTelefonExistent.CheckState == CheckState.Unchecked)
                checkBoxTelefonExistent.Text = "Nou";
            else
                checkBoxTelefonExistent.Text = "Eroare";
        }
        #endregion

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
                dataGridViewRegistration.DataSource = dtbl;
                //dataGridView1.Columns[0].Visible = false;

                DatabaseConnection.Close();
            }
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        #region TextBoxesFormatting
        private void ToTitleCase_textBoxFormat (TextBox textBox_parameter)
        {
            textBox_parameter.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(textBox_parameter.Text);
            textBox_parameter.Select(textBox_parameter.Text.Length, 0);
        }
        private void txtNume_TextChanged(object sender, EventArgs e)
        {
            ToTitleCase_textBoxFormat(txtNume);
        }

        private void txtPrenume_TextChanged(object sender, EventArgs e)
        {
            ToTitleCase_textBoxFormat(txtPrenume);
        }

        private void CapitalizeFirstLetter_textBoxFormat(TextBox InputTextBox)
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

        private void txtTipTelefon_TextChanged(object sender, EventArgs e)
        {
            CapitalizeFirstLetter_textBoxFormat(txtTipTelefon);
        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            CapitalizeFirstLetter_textBoxFormat(txtModel);
        }

        private void txtCuloare_TextChanged(object sender, EventArgs e)
        {
            CapitalizeFirstLetter_textBoxFormat(txtCuloare);
        }

        private void txtDefectConstatat_TextChanged(object sender, EventArgs e)
        {
            CapitalizeFirstLetter_textBoxFormat(txtDefectConstatat);
        }

        private void txtObservatii_TextChanged(object sender, EventArgs e)
        {
            CapitalizeFirstLetter_textBoxFormat(txtObservatii);
        }

        private void NumberOnly_textBoxFormat(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtIMEI_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberOnly_textBoxFormat(e);
        }

        private void txtPretEstimativ_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberOnly_textBoxFormat(e);
        }

        private void txtPretAvans_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberOnly_textBoxFormat(e);
        }
        #endregion
        private void last_Registration()
        {
            using (IDbConnection db_con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
            {
                if (db_con.State == ConnectionState.Closed)
                {
                    db_con.Open();
                }
                string query = "SELECT TOP (1) r.id_reparatie, c.nume, c.prenume, c.nr_telefon, t.tip_telefon, t.model, t.imei, t.garantie, t.cod_telefon, t.culoare, r.data_primirii, r.data_predarii, r.defect_constatat, r.observatii, r.piese_inlocuite, r.pret_achitat, r.pret_estimativ, r.pret_avans, r.termen_rezolvare FROM Date_reparatie r " +
                               "JOIN Date_client c ON r.id_client = c.id " +
                               "JOIN Date_telefon t ON r.id_telefon = t.id " +
                               $"ORDER BY id_reparatie DESC";

                ledgerclassBindingSource.DataSource = db_con.Query<ledger_class>(query, commandType: CommandType.Text);
            }
        }
        private void btnCauta_Click(object sender, EventArgs e)
        {
            using (IDbConnection db_con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
            {
                if (db_con.State == ConnectionState.Closed)
                {
                    db_con.Open();
                }
                string query = "SELECT TOP (1) r.id_reparatie, c.nume, c.prenume, c.nr_telefon, t.tip_telefon, t.model, t.imei, t.garantie, t.cod_telefon, t.culoare, r.data_primirii, r.data_predarii, r.defect_constatat, r.observatii, r.piese_inlocuite, r.pret_achitat, r.pret_estimativ, r.pret_avans, r.termen_rezolvare FROM Date_reparatie r " +
                               "JOIN Date_client c ON r.id_client = c.id " +
                               "JOIN Date_telefon t ON r.id_telefon = t.id " +
                               $"ORDER BY id_reparatie DESC";

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
                    string query = "SELECT r.id_reparatie, c.nume, c.prenume, c.nr_telefon, t.tip_telefon, t.model, t.imei, t.garantie, t.cod_telefon, t.culoare, r.data_primirii, r.data_predarii, r.defect_constatat, r.observatii, r.piese_inlocuite, r.pret_achitat, r.pret_estimativ, r.pret_avans, r.termen_rezolvare FROM Date_reparatie r " +
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
    }
}
