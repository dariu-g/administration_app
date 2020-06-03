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
    public partial class main_form : Form
    {
        public main_form()
        {
            InitializeComponent();
            customizeDesign();
        }

        /* hides the submenu panel */
        private void customizeDesign()
        {
            panelInregistrareSubmenu.Visible = false;
            panelStatusReparatiiSubmenu.Visible = false;
            panelStatisticiSubmenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelInregistrareSubmenu.Visible == true)
                panelInregistrareSubmenu.Visible = false;
            if (panelStatusReparatiiSubmenu.Visible == true)
                panelStatusReparatiiSubmenu.Visible = false;
            if (panelStatisticiSubmenu.Visible == true)
                panelStatisticiSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        #region InregistrareSubmenu
        private void btnInregistrare_Click(object sender, EventArgs e)
        {
            showSubMenu(panelInregistrareSubmenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new FormInregistrare());
            /* buton din meniul Inregistrare */
            /* cod.. */
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /* buton din meniul Inregistrare */
            /* cod.. */
            hideSubMenu();
        }
        #endregion

        #region StatusReparatiiSubmenu
        private void btnStatusReparatii_Click(object sender, EventArgs e)
        {
            showSubMenu(panelStatusReparatiiSubmenu);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /* buton din meniul Status reparatii */
            /* cod.. */
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /* buton din meniul Status reparatii */
            /* cod.. */
            hideSubMenu();
        }
        #endregion

        #region StatisticiSubmenu
        private void btnStatistici_Click(object sender, EventArgs e)
        {
            showSubMenu(panelStatisticiSubmenu);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            /* buton din meniul Status reparatii */
            /* cod.. */
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            /* buton din meniul Statistici */
            /* cod.. */
            hideSubMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            /* buton din meniul Statistici */
            /* cod.. */
            hideSubMenu();
        }
        #endregion
        private void btnInformatii_Click(object sender, EventArgs e)
        {
            openChildForm(new FormInformatii());
            /* cod.. */
            hideSubMenu();
        }

        private Form activeForm = null;             // the child form needs to be stored apart from the main form
        private void openChildForm(Form childForm)  // this method works for only 1 child form being open in the main form (see 13:50 for multiple forms)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
