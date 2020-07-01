using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace AplicatieDisertatie
{
    public partial class registrationAdd_form : Form
    {
        /* Class scope members. */
        static private int ClientID = 0;
        static private int TelefonID = 0;

        public registrationAdd_form()
        {
            InitializeComponent();
            connection_class.checkBoxStates(checkboxGarantie, "Da", "Nu");
            last_Registration();
            dataGridViewRegistration.DoubleBufferedDataGridView(true);
        }

        #region MainButtons
        private void btnInregistrare_Click(object sender, EventArgs e)
        {
            
            if (txtNrTelefon.Text == "" || txtNume.Text == "" || txtPrenume.Text == "" || 
                txtIMEI.Text == "" || txtTipTelefon.Text == "" || txtModel.Text == "" || txtCuloare.Text == "" || txtCodTelefon.Text == "" || 
                txtDefectConstatat.Text == "" || txtObservatii.Text == "" || txtTermenRezolvare.Text == "" ||   txtPretEstimativ.Text == "" || txtPretAvans.Text == "")
            {
                MessageBox.Show("Completati toate campurile.");
            }
            else
            {
                using (SqlConnection DatabaseConnection = new SqlConnection(connection_class.connectionString))
                {
                    if (DatabaseConnection.State == ConnectionState.Closed)
                        DatabaseConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("InregistrareReparatie", DatabaseConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    if (ClientID == 0)     /* Client does not exist in the database. */
                    {
                        sqlCmd.Parameters.AddWithValue("@Nume", txtNume.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Prenume", txtPrenume.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Nr_telefon", txtNrTelefon.Text.Trim());
                    }
                    else                   /* Client exists in the database. */
                    {
                        sqlCmd.Parameters.AddWithValue("@ID_ClientExistent", ClientID);
                    }

                    if (TelefonID == 0)    /* Phone does not exist in the database. */
                    {
                        sqlCmd.Parameters.AddWithValue("@Tip_telefon", txtTipTelefon.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Model", txtModel.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Culoare", txtCuloare.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Garantie", checkboxGarantie.Checked);
                        sqlCmd.Parameters.AddWithValue("@IMEI", txtIMEI.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Cod_telefon", txtCodTelefon.Text.Trim());
                    }
                    else                   /* Phone exists in the database. */
                    {
                        sqlCmd.Parameters.AddWithValue("@ID_TelefonExistent", TelefonID);
                    }

                    sqlCmd.Parameters.AddWithValue("@Defect_constatat", txtDefectConstatat.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Observatii", txtObservatii.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Termen_rezolvare", txtTermenRezolvare.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Pret_estimativ", txtPretEstimativ.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Pret_avans", txtPretAvans.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@UtilizatorID", userLogin_form.UtilizatorID);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Reparatie inregistrata!");
                    connection_class.ClearTextBoxes(this.Controls);
                    last_Registration();
                    ClientID = 0;
                    TelefonID = 0;
                    if (checkBoxTiparire.Checked)
                    {
                        btnPrint.PerformClick();
                    }
                }
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
                        db_con.Open();

                    int obiect_ReparatieID = objct.id_reparatie;
                    List<ledgerPrint_class> list = db_con.Query<ledgerPrint_class>("PrintInregistrare", new { obiect_ReparatieID }, commandType: CommandType.StoredProcedure).ToList();
                    using (print_form form = new print_form(objct, list))
                    {
                        form.ShowDialog();
                    };
                }
            }
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            connection_class.ClearTextBoxes(this.Controls);
            ClientID = 0;
            TelefonID = 0;
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region LocalMethods
        private void last_Registration()
        {
            using (IDbConnection db_con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
            {
                if (db_con.State == ConnectionState.Closed)
                    db_con.Open();

                ledgerclassBindingSource.DataSource = db_con.Query<ledger_class>("UltimaInregistrare", commandType: CommandType.StoredProcedure);
            }
        }
        #endregion

        #region TextBoxesFormatting
        /* TextBoxes client. */
        private void txtNume_TextChanged(object sender, EventArgs e)
        {
            connection_class.ToTitleCase_textBoxFormat(txtNume);
        }

        private void txtPrenume_TextChanged(object sender, EventArgs e)
        {
            connection_class.ToTitleCase_textBoxFormat(txtPrenume);
        }

        /* Reads the field txtNrTelefon, if it is found in the database the ClientID will be stored in the static variable
         * ClientID and the textBoxes txtNume and txtPrenume will be filled with the data coresponding to txtNrTelefon. */
        private void txtNrTelefon_TextChanged(object sender, EventArgs e)
        {
            if (txtNrTelefon.Text != "" && txtNrTelefon.Text.Length > 9)
            {
                using (SqlConnection DatabaseConnection = new SqlConnection(connection_class.connectionString))
                {
                    if (DatabaseConnection.State == ConnectionState.Closed)
                        DatabaseConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("AutocompleteazaClient", DatabaseConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Nr_telefon", txtNrTelefon.Text.Trim());

                    SqlDataReader dataReader = sqlCmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ClientID = Convert.ToInt32(dataReader.GetValue(0));
                        txtNume.Text = dataReader.GetValue(1).ToString();
                        txtPrenume.Text = dataReader.GetValue(2).ToString();
                    }
                    DatabaseConnection.Close();
                }
            }
        }

        /* TextBoxes telefon. */
        private void txtTipTelefon_TextChanged(object sender, EventArgs e)
        {
            connection_class.CapitalizeFirstLetter_textBoxFormat(txtTipTelefon);
        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            connection_class.CapitalizeFirstLetter_textBoxFormat(txtModel);
        }

        private void txtCuloare_TextChanged(object sender, EventArgs e)
        {
            connection_class.CapitalizeFirstLetter_textBoxFormat(txtCuloare);
        }

        private void txtIMEI_KeyPress(object sender, KeyPressEventArgs e)
        {
            connection_class.NumberOnly_textBoxFormat(e);
        }

        /* Reads the field txtIMEI, if it is found in the database, the TelefonID will be stored in the static variable 
         * TelefonID and all other Date_telefon textBoxes will be filled with the data coresponding to txtIMEI. */
        private void txtIMEI_TextChanged(object sender, EventArgs e)
        {
            if (txtIMEI.Text != "" && txtIMEI.Text.Length > 14)
            {
                using (SqlConnection DatabaseConnection = new SqlConnection(connection_class.connectionString))
                {
                    if (DatabaseConnection.State == ConnectionState.Closed)
                        DatabaseConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("AutocompleteazaTelefon", DatabaseConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IMEI", txtIMEI.Text.Trim());

                    SqlDataReader dataReader = sqlCmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        TelefonID = Convert.ToInt32(dataReader.GetValue(0));
                        txtTipTelefon.Text = dataReader.GetValue(1).ToString();
                        txtModel.Text = dataReader.GetValue(2).ToString();
                        txtCuloare.Text = dataReader.GetValue(3).ToString();
                        txtCodTelefon.Text = dataReader.GetValue(4).ToString();
                        checkboxGarantie.Checked = Convert.ToBoolean(dataReader.GetValue(5));
                    }
                    DatabaseConnection.Close();
                }
            }
        }
        /* TextBoxes reparatie. */
        private void txtDefectConstatat_TextChanged(object sender, EventArgs e)
        {
            connection_class.CapitalizeFirstLetter_textBoxFormat(txtDefectConstatat);
        }

        private void txtObservatii_TextChanged(object sender, EventArgs e)
        {
            connection_class.CapitalizeFirstLetter_textBoxFormat(txtObservatii);
        }

        private void txtPretEstimativ_KeyPress(object sender, KeyPressEventArgs e)
        {
            connection_class.NumberOnly_textBoxFormat(e);
        }

        private void txtPretAvans_KeyPress(object sender, KeyPressEventArgs e)
        {
            connection_class.NumberOnly_textBoxFormat(e);
        }

        private void checkboxGarantie_CheckStateChanged(object sender, EventArgs e)
        {
            connection_class.checkBoxStates(checkboxGarantie, "Da", "Nu");
        }
        #endregion
    }
}
