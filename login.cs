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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void labelCatreInregistrareUtilizator_Click(object sender, EventArgs e)
        {
            this.Hide();
            create_user registerform = new create_user();
            registerform.Show();
        }

        private void labelExit_MouseEnter(object sender, EventArgs e)
        {
            labelExit.ForeColor = Color.Black;
        }

        private void labelExit_MouseLeave(object sender, EventArgs e)
        {
            labelExit.ForeColor = Color.White;
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelCatreInregistrareUtilizator_MouseEnter(object sender, EventArgs e)
        {
            labelCatreInregistrareUtilizator.ForeColor = Color.Yellow;
        }

        private void labelCatreInregistrareUtilizator_MouseLeave(object sender, EventArgs e)
        {
            labelCatreInregistrareUtilizator.ForeColor = Color.White;
        }

        private void btnAutentificare_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUtilizator.Text) && !string.IsNullOrEmpty(txtParola.Text))
            {
                string msSQL = string.Empty;

                msSQL += "SELECT * FROM Utilizatori ";
                msSQL += "WHERE utilizator = '" + txtUtilizator.Text + "' ";
                msSQL += "AND parola = '" + txtParola.Text + "' ";

                DataTable Utilizatori = db_connection.executeSQL(msSQL);

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
    }
}
