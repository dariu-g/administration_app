using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicatieDisertatie
{
    public partial class status_unclaimed_form : Form
    {
        public status_unclaimed_form()
        {
            InitializeComponent();
            dataGridCurrent.DoubleBufferedDataGridView(true);
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            DialogResult DialogBox = MessageBox.Show("Doresti sa concluzionezi aceasta reparatie?", "Atentionare", MessageBoxButtons.YesNo);
            if (DialogBox == DialogResult.Yes)
            {

            }
            else if (DialogBox == DialogResult.No)
            {

            }
        }

        private void dataGridCurrent_Click(object sender, EventArgs e)
        {

        }

        private void dataGridGreaterThan6m_Click(object sender, EventArgs e)
        {

        }
    }
}
