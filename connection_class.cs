using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AplicatieDisertatie
{
    public static class connection_class
    {
        /* Method of establishing the connection to the database. */
        public static string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        /* Provides password encryption using SHA256 algorithm. */
        public static string PasswordEncrypt(string password)
        {
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = sha256.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(data);
            }
        }

        public static void FillDataGridView(string StoredProc, DataGridView dataGridName)
        {
            using (SqlConnection DatabaseConnection = new SqlConnection(connectionString))
            {
                if (DatabaseConnection.State == ConnectionState.Closed)
                    DatabaseConnection.Open();

                SqlDataAdapter sqlData = new SqlDataAdapter(StoredProc, DatabaseConnection);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);
                dataGridName.DataSource = dataTable;

                DatabaseConnection.Close();
            }
        }

        /* Removes the glitches when scrolling horizontally in the data grid view by settting the property 
         * Double buffered to the data grid view. */
        public static void DoubleBufferedDataGridView(this DataGridView dataGridView, bool setting)
        {
            Type dataGridViewType = dataGridView.GetType();
            PropertyInfo propertyInfo = dataGridViewType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            propertyInfo.SetValue(dataGridView, setting, null);
        }

        #region Boxes formatting methods
        /* Changes the displayed text when the checkbox is checked or unchecked. */
        public static void checkBoxStates(CheckBox checkBox, string checkBoxChecked, string checkBoxUnchecked)
        {
            if (checkBox.CheckState == CheckState.Checked)
                checkBox.Text = checkBoxChecked;
            else if (checkBox.CheckState == CheckState.Unchecked)
                checkBox.Text = checkBoxUnchecked;
            else
                checkBox.Text = "Eroare";
        }

        /* Capitalizes the first letter of every word. */
        public static void ToTitleCase_textBoxFormat(TextBox textBox_parameter)
        {
            textBox_parameter.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(textBox_parameter.Text);
            textBox_parameter.Select(textBox_parameter.Text.Length, 0);
        }

        /* Capitalizes the first letter of the first word written. */
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

        /* Allows only numbers to be written. */
        public static void NumberOnly_textBoxFormat(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /* Clears all text boxes from a form. */
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
