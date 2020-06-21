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
    public partial class login_form : Form
    {
        connection_class hash = new connection_class();
        public login_form()
        {
            InitializeComponent();
        }

        private void labelCatreInregistrareUtilizator_Click(object sender, EventArgs e)
        {
            this.Hide();
            user_form registerform = new user_form();
            registerform.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAutentificare_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUtilizator.Text) && !string.IsNullOrEmpty(txtParola.Text))
            {
                string login_check = string.Empty;

                login_check += "SELECT * FROM Utilizatori ";
                login_check += "WHERE utilizator = '" + txtUtilizator.Text + "' ";
                login_check += "AND parola = '" + hash.PasswordEncrypt(txtParola.Text) + "' ";

                DataTable Utilizatori = connection_class.executeSQL(login_check);

                if(Utilizatori.Rows.Count > 0)
                {
                    txtUtilizator.Clear();
                    txtParola.Clear();

                    this.Hide();
                    main_form formMain = new main_form();
                    formMain.ShowDialog();
                    formMain = null;
                    //this.txtUtilizator.Select();
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

        #region Design
        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
