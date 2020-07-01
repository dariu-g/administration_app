using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicatieDisertatie
{
    public partial class userLogin_form : Form
    {
        /* Class scope members. */
        static public int UtilizatorID = 0;

        public userLogin_form()
        {
            InitializeComponent();
        }

        /* Redirects to user_form. */
        #region MainButtons
        private void labelCatreInregistrareUtilizator_Click(object sender, EventArgs e)
        {
            this.Hide();
            userRegistration_form registerform = new userRegistration_form();
            registerform.Show();
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAutentificare_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUtilizator.Text) && !string.IsNullOrEmpty(txtParola.Text))
            {

                DataTable Utilizatori = executeSQL("AutentificareUtilizator");
                /* Verifies if a username and password matched in the database. The table gains a Row if this is true. */
                if(Utilizatori != null && Utilizatori.Rows.Count > 0)
                {
                    txtUtilizator.Clear();
                    txtParola.Clear();

                    this.Hide();
                    main_form formMain = new main_form();
                    formMain.ShowDialog();
                    formMain = null;
                }
                else
                {
                    MessageBox.Show("Utilizatorul sau parola sunt incorecte. Incearca din nou.");
                    txtUtilizator.Focus();
                    txtUtilizator.SelectAll();
                }    
            }
            else
            {
                MessageBox.Show("Introduce-ti utilizatorul si parola.");
                txtUtilizator.Select();
            }
        }
        #endregion

        #region LocalMethods

        /* Returns the user in a DataTable, if there is a match for user/password. */
        private DataTable executeSQL(string StoredProc)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection DatabaseConnection = new SqlConnection(connection_class.connectionString))
                {
                    if (DatabaseConnection.State == ConnectionState.Closed)
                        DatabaseConnection.Open();

                    SqlCommand sqlCmd = new SqlCommand(StoredProc, DatabaseConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.AddWithValue("@utilizator", txtUtilizator.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@parola", connection_class.PasswordEncrypt(txtParola.Text.Trim()));

                    adapter.SelectCommand = sqlCmd;
                    adapter.Fill(dataTable);

                    /* Fetches UtilizatorID from the dataTable position [0][0]. */
                    if (dataTable != null)
                        UtilizatorID = Convert.ToInt32(dataTable.Rows[0][0]);


                    DatabaseConnection.Close();
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                if (dataTable == null)
                    MessageBox.Show("A aparut o eroare. Contactati administratorul." + ex.Message, "Posibila eroare de conexiune la baza de date.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataTable = null;
            }
            return dataTable;
        }
        #endregion
        
        #region Design
        private void labelExit_MouseEnter(object sender, EventArgs e)
        {
            labelExit.ForeColor = Color.Black;
        }

        private void labelExit_MouseLeave(object sender, EventArgs e)
        {
            labelExit.ForeColor = Color.White;
        }

        private void labelCatreInregistrareUtilizator_MouseEnter(object sender, EventArgs e)
        {
            labelCatreInregistrareUtilizator.ForeColor = Color.Yellow;
        }

        private void labelCatreInregistrareUtilizator_MouseLeave(object sender, EventArgs e)
        {
            labelCatreInregistrareUtilizator.ForeColor = Color.White;
        }
        #endregion
    }
}
