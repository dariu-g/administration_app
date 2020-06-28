using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace AplicatieDisertatie
{
    public static class connection_class
    {
        /* Initial method of establishing the connection to the database. */ 
        //public static string connectionString = "Data Source=BLUE;Initial Catalog=baza_date;Integrated Security=True;";
        public static string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        public static DataTable executeSQL(string sql)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataAdapter adapter = default(SqlDataAdapter);
            DataTable dataTable = new DataTable();

            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dataTable);

                connection.Close();
                connection = null;
                return dataTable;
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("A aparut o eroare:" + ex.Message, "Conexiunea la baza de date a esuat.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataTable = null;
            }
            return dataTable;
        }

        public static string PasswordEncrypt(string password)
        {
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = sha256.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(data);
            }
        }

        public static void checkStateGarantie(CheckBox checkBox)
        {
            if (checkBox.CheckState == CheckState.Checked)
                checkBox.Text = "Da";
            else if (checkBox.CheckState == CheckState.Unchecked)
                checkBox.Text = "Nu";
            else
                checkBox.Text = "Eroare";
        }

        #region TextBoxes formatting
        public static void ToTitleCase_textBoxFormat(TextBox textBox_parameter)
        {
            textBox_parameter.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(textBox_parameter.Text);
            textBox_parameter.Select(textBox_parameter.Text.Length, 0);
        }

        public static void CapitalizeFirstLetter_textBoxFormat(TextBox InputTextBox)
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

        public static void NumberOnly_textBoxFormat(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void ClearTextBoxes(Control.ControlCollection Controls)
        {
            foreach (Control control in Controls)
            {
                if (control is TextBoxBase)
                {
                    control.Text = String.Empty;
                }
                else
                {
                    ClearTextBoxes(control.Controls);
                }
            }
        }
        #endregion
    }
}
