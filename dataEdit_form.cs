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
    public partial class dataEdit_form : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=BLUE;Initial Catalog=baza_date;Integrated Security=True;");
        int ClientID = 0;
        int TelefonID = 0;
        int ReparatieID = 0;
        string ID = "";
        public dataEdit_form()
        {
            InitializeComponent();
            checkStateGarantie();
            readOnly_TextBoxes();
        }

        private void dataGridViewEdit_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewEdit.CurrentRow.Index != -1)
            {
                if (ID == "id_client")
                {
                    ClientID = Convert.ToInt32(dataGridViewEdit.CurrentRow.Cells[0].Value.ToString());
                    txtNume.Text = dataGridViewEdit.CurrentRow.Cells[1].Value.ToString();
                    txtPrenume.Text = dataGridViewEdit.CurrentRow.Cells[2].Value.ToString();
                    txtNrTelefon.Text = dataGridViewEdit.CurrentRow.Cells[3].Value.ToString();
                    btnModificaClient.Text = "Modifica";
                    readOnly_DateClient();
                }

                if (ID == "id_telefon")
                {
                    TelefonID = Convert.ToInt32(dataGridViewEdit.CurrentRow.Cells[0].Value.ToString());
                    txtTipTelefon.Text = dataGridViewEdit.CurrentRow.Cells[1].Value.ToString();
                    txtModel.Text = dataGridViewEdit.CurrentRow.Cells[2].Value.ToString();
                    txtCuloare.Text = dataGridViewEdit.CurrentRow.Cells[3].Value.ToString();
                    txtIMEI.Text = dataGridViewEdit.CurrentRow.Cells[4].Value.ToString();
                    txtCodTelefon.Text = dataGridViewEdit.CurrentRow.Cells[5].Value.ToString();
                    checkboxGarantie.Checked = Convert.ToBoolean(dataGridViewEdit.CurrentRow.Cells[6].Value);
                    btnModificaTelefon.Text = "Modifica";
                    readOnly_DateTelefon();
                }

                if (ID == "id_reparatie")
                {
                    ReparatieID = Convert.ToInt32(dataGridViewEdit.CurrentRow.Cells[0].Value.ToString());
                    dateDataPrimirii.Value = System.Convert.ToDateTime(dataGridViewEdit.CurrentRow.Cells[1].Value);
                    dateDataPredarii.Value = System.Convert.ToDateTime(dataGridViewEdit.CurrentRow.Cells[2].Value);
                    txtDefectConstatat.Text = dataGridViewEdit.CurrentRow.Cells[3].Value.ToString();
                    txtPieseInlocuite.Text = dataGridViewEdit.CurrentRow.Cells[4].Value.ToString();
                    txtObservatii.Text = dataGridViewEdit.CurrentRow.Cells[5].Value.ToString();
                    txtTermenRezolvare.Text = dataGridViewEdit.CurrentRow.Cells[6].Value.ToString();
                    txtTermenGarantie.Text = dataGridViewEdit.CurrentRow.Cells[7].Value.ToString();
                    txtPretEstimativ.Text = dataGridViewEdit.CurrentRow.Cells[8].Value.ToString();
                    txtPretAvans.Text = dataGridViewEdit.CurrentRow.Cells[9].Value.ToString();
                    txtPretAchitat.Text = dataGridViewEdit.CurrentRow.Cells[10].Value.ToString();
                    btnModificaReparatie.Text = "Modifica";
                    readOnly_DateReparatie();
                }
            }
        }


        void FillDataGridView(string StoredProc, string Param1, string Param2, TextBox TextBox)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection DatabaseConnection = new SqlConnection(connectionString))
            {
                if (DatabaseConnection.State == ConnectionState.Closed)
                    DatabaseConnection.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter(StoredProc, DatabaseConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue(Param1, TextBox.Text.Trim());
                sqlDa.SelectCommand.Parameters.AddWithValue(Param2, "Cauta");

                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridViewEdit.DataSource = dtbl;
                dataGridViewEdit.Columns[0].Visible = false;

                DatabaseConnection.Close();
                }
        }

        private void btnModificaClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                if (btnModificaClient.Text == "Cauta")
                {
                    FillDataGridView("ModificaClient", "@Cautare_client", "@Mod_buton", txtCautaClient);
                    ID = "id_client";
                }
                else if (btnModificaClient.Text == "Modifica")
                {
                    
                    SqlCommand sqlCmd = new SqlCommand("ModificaClient", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Mod_buton", "Modifica");
                    sqlCmd.Parameters.AddWithValue("@ClientID", ClientID);
                    sqlCmd.Parameters.AddWithValue("@Nume", txtNume.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Prenume", txtPrenume.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Nr_telefon", txtNrTelefon.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Datele clientului au fost modificate.");
                    btnModificaClient.Text = "Cauta";
                    readOnly_DateClient();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare de conexiune a bazei de date.");
            }
        }

        private void btnModificaTelefon_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                if (btnModificaTelefon.Text == "Cauta")
                {
                    FillDataGridView("ModificaTelefon", "@Cautare_telefon", "@Mod_buton", txtCautaTelefon);
                    ID = "id_telefon";
                }
                else if (btnModificaTelefon.Text == "Modifica")
                {

                    SqlCommand sqlCmd = new SqlCommand("ModificaTelefon", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Mod_buton", "Modifica");
                    sqlCmd.Parameters.AddWithValue("@TelefonID", TelefonID);
                    sqlCmd.Parameters.AddWithValue("@Tip_telefon", txtTipTelefon.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model", txtModel.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Culoare", txtCuloare.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@IMEI", txtIMEI.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Cod_telefon", txtCodTelefon.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Garantie", checkboxGarantie.Checked);
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Datele telefonului au fost modificate!");
                    btnModificaTelefon.Text = "Cauta";
                    readOnly_DateTelefon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare de conexiune a bazei de date.");
            }
        }

        private void btnModificaReparatie_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                if (btnModificaReparatie.Text == "Cauta")
                {
                    FillDataGridView("ModificaReparatie", "@Cautare_reparatie", "Mod_buton", txtCautaReparatie);
                    ID = "id_reparatie";
                }
                else if (btnModificaReparatie.Text == "Modifica")
                {
                    SqlCommand sqlCmd = new SqlCommand("ModificaReparatie", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Mod_buton", "Modifica");
                    sqlCmd.Parameters.AddWithValue("@ReparatieID", ReparatieID);
                    sqlCmd.Parameters.AddWithValue("@Data_primirii", dateDataPrimirii.Value);
                    sqlCmd.Parameters.AddWithValue("@Data_predarii", dateDataPredarii.Value);
                    sqlCmd.Parameters.AddWithValue("@Defect_constatat", txtDefectConstatat.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Piese_inlocuite", txtPieseInlocuite.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Observatii", txtObservatii.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Termen_rezolvare", txtTermenRezolvare.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Termen_garantie", txtTermenGarantie.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Pret_estimativ", txtPretEstimativ.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Pret_avans", txtPretAvans.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Pret_achitat", txtPretAchitat.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Datele telefonului au fost modificate!");
                    btnModificaReparatie.Text = "Cauta";
                    readOnly_DateReparatie();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare de conexiune a bazei de date.");
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

        private void checkStateGarantie()
        {
            if (checkboxGarantie.CheckState == CheckState.Checked)
                checkboxGarantie.Text = "Da";
            else if (checkboxGarantie.CheckState == CheckState.Unchecked)
                checkboxGarantie.Text = "Nu";
            else
                checkboxGarantie.Text = "Eroare";
        }

        private void checkboxGarantie_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkboxGarantie.CheckState == CheckState.Checked)
                checkboxGarantie.Text = "Da";
            else if (checkboxGarantie.CheckState == CheckState.Unchecked)
                checkboxGarantie.Text = "Nu";
            else
                checkboxGarantie.Text = "Eroare";
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            btnModificaClient.Text = "Cauta";
            btnModificaTelefon.Text = "Cauta";
            btnModificaReparatie.Text = "Cauta";
            readOnly_TextBoxes();
        }

        private void readOnly_TextBoxes()
        {
            Action<Control.ControlCollection> clear_func = null;

            clear_func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).ReadOnly = true;
                    else
                        clear_func(control.Controls);

            };
            clear_func(Controls);
            txtCautaClient.ReadOnly = false;
            txtCautaReparatie.ReadOnly = false;
            txtCautaTelefon.ReadOnly = false;
        }

        private void readOnly_DateClient ()
        {
            if (btnModificaClient.Text == "Modifica")
            {
                txtNume.ReadOnly = false;
                txtPrenume.ReadOnly = false;
                txtNrTelefon.ReadOnly = false;
            }
            else if(btnModificaClient.Text == "Cauta")
            {
                txtNume.ReadOnly = true;
                txtPrenume.ReadOnly = true;
                txtNrTelefon.ReadOnly = true;
            }
        }

        private void readOnly_DateTelefon()
        {
            if (btnModificaTelefon.Text == "Modifica")
            {
                txtTipTelefon.ReadOnly = false;
                txtModel.ReadOnly = false;
                txtCuloare.ReadOnly = false;
                txtIMEI.ReadOnly = false;
                txtCodTelefon.ReadOnly = false;
            }
            else if (btnModificaTelefon.Text == "Cauta")
            {
                txtTipTelefon.ReadOnly = true;
                txtModel.ReadOnly = true;
                txtCuloare.ReadOnly = true;
                txtIMEI.ReadOnly = true;
                txtCodTelefon.ReadOnly = true;
            }
        }

        private void readOnly_DateReparatie()
        {
            if (btnModificaReparatie.Text == "Modifica")
            {
                txtDefectConstatat.ReadOnly = false;
                txtPieseInlocuite.ReadOnly = false;
                txtObservatii.ReadOnly = false;
                txtTermenRezolvare.ReadOnly = false;
                txtTermenGarantie.ReadOnly = false;
                txtPretEstimativ.ReadOnly = false;
                txtPretAvans.ReadOnly = false;
                txtPretAchitat.ReadOnly = false;
            }
            else if (btnModificaReparatie.Text == "Cauta")
            {
                txtDefectConstatat.ReadOnly = true;
                txtPieseInlocuite.ReadOnly = true;
                txtObservatii.ReadOnly = true;
                txtTermenRezolvare.ReadOnly = true;
                txtTermenGarantie.ReadOnly = true;
                txtPretEstimativ.ReadOnly = true;
                txtPretAvans.ReadOnly = true;
                txtPretAchitat.ReadOnly = true;
            }
        }
    }
}
