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

namespace AplicatieDisertatie
{

    //create a class for database connection create in which we have 2 functions database open/close connection 
    public partial class user_form : Form
    {
        //string connectionString = @"Data Source=BLUE;Initial Catalog=baza_date;Integrated Security=True";
        public user_form()
        {
            InitializeComponent();
        }

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
                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
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
                        sqlCmd.Parameters.AddWithValue("@Parola", txtParola.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Utilzatorul a fost inregistrat cu succes!");
                        DatabaseConnection.Close();
                        Clear();
                        this.Hide();
                        login_form loginform = new login_form();
                        loginform.Show();
                    }

                }
            }
        }

        void Clear()
        {
            txtNume.Text = txtPrenume.Text = txtUtilizator.Text = txtTipUtilizator.Text = txtParola.Text = txtConfirmareParola.Text =  "";
        }

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

        private void labelCatreAutentificare_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_form loginform = new login_form();
            loginform.Show();
        }

        #region TextBoxesFormatting
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
        #endregion
    }
}
