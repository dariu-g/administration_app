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
    public partial class statusWorking_form : Form
    {
        /* Class scope variables. */
        private static int ReparatieID = 0;

        public statusWorking_form()
        {
            InitializeComponent();
            connection_class.FillDataGridView("AfisareTelefoaneInLucru", dataGridViewReparatii);
            connection_class.checkBoxStates(checkBoxVerdictReparatie, "Reparat", "Nereparat");
            dataGridViewReparatii.DoubleBufferedDataGridView(true);
        }

        #region MainButtons
        private void btnAfiseaza_Click(object sender, EventArgs e)
        {
            try
            {
                connection_class.FillDataGridView("AfisareTelefoaneInLucru", dataGridViewReparatii);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare afisare");
            }
        }

        /* Updates the data typed in the textBoxes in table Date_reparatie. */
        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            if (txtPieseInlocuite.Text == "" || txtPretAchitat.Text == "" || txtTermenGarantie.Text == "")
            {
                MessageBox.Show("Completati toate campurile.");
            }
            else
            {
                DialogResult DialogBox = new DialogResult();
                if (dateTimeDataPredarii.Checked == true)
                {
                    DialogBox = MessageBox.Show("Doresti sa concluzionezi aceasta reparatie?", "Atentionare", MessageBoxButtons.YesNo);
                }
                else
                {
                    DialogBox = MessageBox.Show("Doresti sa modifici aceasta reparatie?", "Atentionare", MessageBoxButtons.YesNo);
                }
                if (DialogBox == DialogResult.Yes)
                {
                    using (SqlConnection DatabaseConnection = new SqlConnection(connection_class.connectionString))
                    {
                        DatabaseConnection.Open();
                        SqlCommand sqlCmd = new SqlCommand("ConcluzionareReparatie", DatabaseConnection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        /* Date reparatie. */
                        sqlCmd.Parameters.AddWithValue("@Reparatie_id", ReparatieID);
                        /* Adding this condition the registration can be completed without data_predarii, thus effectively
                         * marking the phone reparation completed, but the phone is yet to be received by the customer. */
                        if (dateTimeDataPredarii.Checked == true)
                            sqlCmd.Parameters.AddWithValue("@Data_predarii", dateTimeDataPredarii.Value);
                        sqlCmd.Parameters.AddWithValue("@Piese_inlocuite", txtPieseInlocuite.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Termen_garantie", txtTermenGarantie.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Pret_achitat", txtPretAchitat.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Verdict_reparatie", checkBoxVerdictReparatie.Checked);

                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Reparatie concluzionata!");
                        connection_class.ClearTextBoxes(this.Controls);
                    }
                }
                else if (DialogResult == DialogResult.No)
                {
                }
                connection_class.FillDataGridView("AfisareTelefoaneInLucru", dataGridViewReparatii);
            }
        }
        #endregion

        /* Click event to store Nr_inreg in the variable ReparatieID upon clicking a registration. */
        private void dataGridViewReparatii_Click(object sender, EventArgs e)
        {
            if (dataGridViewReparatii.CurrentRow.Index != -1)
            {
                ReparatieID = Convert.ToInt32(dataGridViewReparatii.CurrentRow.Cells[0].Value.ToString());
                connection_class.ClearTextBoxes(this.Controls);
            }
        }

        private void checkBoxVerdictReparatie_CheckStateChanged(object sender, EventArgs e)
        {
            connection_class.checkBoxStates(checkBoxVerdictReparatie, "Reparat", "Nereparat");
        }

        #region TextBoxesFormatting
        private void txtPieseInlocuite_TextChanged(object sender, EventArgs e)
        {
            connection_class.CapitalizeFirstLetter_textBoxFormat(txtPieseInlocuite);
        }

        private void txtPieseInlocuite_KeyPress(object sender, KeyPressEventArgs e)
        {
            connection_class.NumbersLettersPunctuations_textBoxFormat(e);
        }

        private void txtTermenGarantie_KeyPress(object sender, KeyPressEventArgs e)
        {
            connection_class.NumbersLettersPunctuations_textBoxFormat(e);
        }

        private void txtPretAchitat_KeyPress(object sender, KeyPressEventArgs e)
        {
            connection_class.NumberOnly_textBoxFormat(e);
        }
        #endregion

        private void statusWorking_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReparatieID = 0;
        }
    }
}
