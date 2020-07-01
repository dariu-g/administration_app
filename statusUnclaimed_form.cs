using System;
using System.Collections.Generic;
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
    public partial class statusUnclaimed_form : Form
    {
        /* Class scope members. */
        private static int ReparatieID = 0;
        private static int ReparatieID_6M = 0;
        
        public statusUnclaimed_form()
        {
            InitializeComponent();
            dataGridCurrent.DoubleBufferedDataGridView(true);
            dataGridGreaterThan6m.DoubleBufferedDataGridView(true);
            connection_class.FillDataGridView("AfisareTelefoaneNeridicate", dataGridCurrent);
            connection_class.FillDataGridView("AfisareTelefoaneNeridicateSaseLuni", dataGridGreaterThan6m);
        }

        #region MainButtons
        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            DialogResult DialogBox = MessageBox.Show("Doresti sa concluzionezi aceasta reparatie?", "Atentionare", MessageBoxButtons.YesNo);
            if (DialogBox == DialogResult.Yes)
            {
                using (SqlConnection DatabaseConnection = new SqlConnection(connection_class.connectionString))
                {
                    DatabaseConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("PredareReparatie", DatabaseConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    /* Date reparatie. */
                    sqlCmd.Parameters.AddWithValue("@Reparatie_id", ReparatieID);
                    sqlCmd.Parameters.AddWithValue("@Data_predarii", dateTimeDataPredarii.Value);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Reparatie concluzionata!");
                    connection_class.ClearTextBoxes(this.Controls);
                }
            }
            else if (DialogBox == DialogResult.No)
            {
            }
            connection_class.FillDataGridView("AfisareTelefoaneNeridicate", dataGridCurrent);
        }


        private void btnCaseaza_Click(object sender, EventArgs e)
        {
            DialogResult DialogBox = MessageBox.Show("Doresti sa casezi aceasta reparatie?", "Atentionare", MessageBoxButtons.YesNo);
            if (DialogBox == DialogResult.Yes)
            {
                using (SqlConnection DatabaseConnection = new SqlConnection(connection_class.connectionString))
                {
                    DatabaseConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("CasareReparatie", DatabaseConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    /* Date reparatie. */
                    sqlCmd.Parameters.AddWithValue("@Reparatie_id", ReparatieID_6M);
                    sqlCmd.Parameters.AddWithValue("@Data_predarii", dateTimeDataPredarii.Value);
                    sqlCmd.Parameters.AddWithValue("@Observatii", txtObservatii.Text.Trim());

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Reparatie casata!");
                    connection_class.ClearTextBoxes(this.Controls);
                }
            }
            else if (DialogBox == DialogResult.No)
            {
            }
            connection_class.FillDataGridView("AfisareTelefoaneNeridicateSaseLuni", dataGridGreaterThan6m);

        }
        #endregion
        
        private void dataGridCurrent_Click(object sender, EventArgs e)
        {
            if (dataGridCurrent.Rows.Count > 0 && dataGridCurrent.CurrentRow.Index != -1)
            {
                ReparatieID = Convert.ToInt32(dataGridCurrent.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void dataGridGreaterThan6m_Click(object sender, EventArgs e)
        {
            if (dataGridGreaterThan6m.Rows.Count > 0 && dataGridGreaterThan6m.CurrentRow.Index != -1)
            {
                ReparatieID_6M = Convert.ToInt32(dataGridGreaterThan6m.CurrentRow.Cells[0].Value.ToString());
            }
        }
    }
}
