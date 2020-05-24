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

    //create a class for database connection create in which we have 2 functions database open/close connection 
    public partial class create_user : Form
    {
        //string connectionString = @"Data Source=BLUE;Initial Catalog=baza_date;Integrated Security=True";
        public create_user()
        {
            InitializeComponent();
        }

        private void btnInregistrare_Click(object sender, EventArgs e)
        {
            if (txtUtilizator.Text == "" || txtParola.Text == "" || txtTipUtilizator.Text == "")
            {
                MessageBox.Show("Completati campurile obligatorii.");
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
                    SqlCommand sqlCmd = new SqlCommand("InregistrareUtilizator", DatabaseConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Nume", txtNume.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Prenume", txtPrenume.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Utilizator", txtUtilizator.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Tip_Utilizator", txtTipUtilizator.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Parola", txtParola.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Utilzatorul a fost inregistrat cu succes!");
                    Clear();
                }
            }
            this.Hide();
            login loginform = new login();
            loginform.Show();
        }
        
        void Clear()
        {
            txtNume.Text = txtPrenume.Text = txtUtilizator.Text = txtTipUtilizator.Text = txtParola.Text = txtConfirmareParola.Text =  "";
        }

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

        private void labelCatreAutentificare_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginform = new login();
            loginform.Show();
        }
    }
}
