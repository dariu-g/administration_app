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
    public partial class status_WIP_form : Form
    {
        /* Global Variables */
        string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        int ReparatieID = 0;

        public status_WIP_form()
        {
            InitializeComponent();
            FillDataGridView();
            checkStateReparat(checkBoxVerdictReparatie);
        }

        #region MainButtons
        private void btnAfiseaza_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare afisare");
            }
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            using (SqlConnection DatabaseConnection = new SqlConnection(connectionString))
            {
                DatabaseConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("ConcluzionareReparatie", DatabaseConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                /* Date reparatie. */
                sqlCmd.Parameters.AddWithValue("@Reparatie_id", ReparatieID);
                if (dateTimeDataPredarii.Checked == true)
                    sqlCmd.Parameters.AddWithValue("@Data_predarii", dateTimeDataPredarii.Value);
                sqlCmd.Parameters.AddWithValue("@Piese_inlocuite", txtPieseInlocuite.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Termen_garantie", txtTermenGarantie.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Pret_achitat", txtPretAchitat.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Verdict_reparatie", checkBoxVerdictReparatie.Checked);

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Reparatie concluzionata!");
            }
            FillDataGridView();
            connection_class.ClearTextBoxes(this.Controls);
        }

        #endregion

        #region LocalFunctions
        void FillDataGridView()
        {
            using (SqlConnection DatabaseConnection = new SqlConnection(connectionString))
            {
                if (DatabaseConnection.State == ConnectionState.Closed)
                    DatabaseConnection.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter("AfisareTelefoaneInLucru", DatabaseConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridViewReparatii.DataSource = dtbl;

                DatabaseConnection.Close();
            }
        }

        private void checkStateReparat(CheckBox checkBox)
        {
            if (checkBox.CheckState == CheckState.Checked)
                checkBox.Text = "Reparat";
            else if (checkBox.CheckState == CheckState.Unchecked)
                checkBox.Text = "Nereparat";
            else
                checkBox.Text = "Eroare";
        }
        #endregion

        /* Click event to select the id of the registration upon click. */
        private void dataGridViewReparatii_Click(object sender, EventArgs e)
        {
            if (dataGridViewReparatii.CurrentRow.Index != -1)
            {
                ReparatieID = Convert.ToInt32(dataGridViewReparatii.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void checkBoxVerdictReparatie_CheckStateChanged(object sender, EventArgs e)
        {
            checkStateReparat(checkBoxVerdictReparatie);
        }
    }
}
