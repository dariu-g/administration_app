using System;
using System.CodeDom.Compiler;
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
using System.Security.Cryptography;
using System.Security.Policy;
using System.Runtime.InteropServices.WindowsRuntime;

namespace AplicatieDisertatie
{
    public partial class user_form : Form
    {
        /* Global variables. */
        string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        public user_form()
        {
            InitializeComponent();
        }

        #region MainButtons
        private void btnInregistrare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUtilizator.Text) || string.IsNullOrEmpty(txtParola.Text))
            {
                MessageBox.Show("Completati campurile obligatorii.");
            }
            else if (txtTipUtilizator.SelectedIndex != 0 && txtTipUtilizator.SelectedIndex != 1)
            {
                MessageBox.Show("Selectati tipul de utilizator.");
            }
            else if (txtParola.Text != txtConfirmareParola.Text)
            {
                MessageBox.Show("Campurile parolei trebuie sa coincida!");
            }
            else
            {
                using (SqlConnection DatabaseConnection = new SqlConnection(connectionString))
                {
                    DatabaseConnection.Open();

                    SqlCommand checkUser = new SqlCommand("VerificareUtilizatorUnic", DatabaseConnection);
                    checkUser.CommandType = CommandType.StoredProcedure;
                    checkUser.Parameters.AddWithValue("@utilizator", txtUtilizator.Text.Trim());
                    int UserExists = (int)checkUser.ExecuteScalar();
                    if (UserExists > 0)
                    {
                        /* User already exists. */
                        MessageBox.Show("Numele de utilizator exista deja!");
                        return;
                    }
                    else
                    {
                        SqlCommand sqlCmd = new SqlCommand("InregistrareUtilizator", DatabaseConnection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@Utilizator", txtUtilizator.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Tip_Utilizator", txtTipUtilizator.SelectedItem);
                        sqlCmd.Parameters.AddWithValue("@Nume", txtNume.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Prenume", txtPrenume.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Parola", connection_class.PasswordEncrypt(txtParola.Text.Trim()));
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Utilzatorul a fost inregistrat cu succes!");
                        DatabaseConnection.Close();
                        connection_class.ClearTextBoxes(this.Controls);
                        this.Hide();
                        login_form loginform = new login_form();
                        loginform.Show();
                    }

                }
            }
        }

        private void labelCatreAutentificare_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_form loginform = new login_form();
            loginform.Show();
        }
        #endregion

        #region Design
        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelExit_MouseEnter(object sender, EventArgs e)
        {
            labelExit.ForeColor = Color.White;
        }

        private void labelExit_MouseLeave(object sender, EventArgs e)
        {
            labelExit.ForeColor = Color.Black;
        }

        private void labelCatreAutentificare_MouseEnter(object sender, EventArgs e)
        {
            labelCatreAutentificare.ForeColor = Color.Yellow;
        }

        private void labelCatreAutentificare_MouseLeave(object sender, EventArgs e)
        {
            labelCatreAutentificare.ForeColor = Color.White;
        }
        #endregion

        #region TextBoxesFormatting
        private void txtNume_TextChanged(object sender, EventArgs e)
        {
            connection_class.ToTitleCase_textBoxFormat(txtNume);
        }

        private void txtPrenume_TextChanged(object sender, EventArgs e)
        {
            connection_class.ToTitleCase_textBoxFormat(txtPrenume);
        }
        #endregion
    }
}
