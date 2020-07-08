using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicatieDisertatie.Properties;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace AplicatieDisertatie
{
    public partial class main_form : Form
    {
        public main_form()
        {
            InitializeComponent();
            customizeDesign();
            labelUser.Text = userLogin_form.username;
        }

        #region NavigationMenu
        #region Show/HideSubmenu
        /* Hides the submenu panel */
        private void customizeDesign()
        {
            panelInregistrareSubmenu.Visible = true;
            panelStatusReparatiiSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
                subMenu.Visible = true;
            else
                subMenu.Visible = false;
        }
        #endregion

        #region InregistrariReparatiiSubmenu
        private void btnInregistrariReparatii_Click(object sender, EventArgs e)
        {
            showSubMenu(panelInregistrareSubmenu);
        }

        private void btnInregistrariAdauga_Click(object sender, EventArgs e)
        {
            openChildForm(new registrationAdd_form());
        }

        private void btnInregistrariIstoric_Click(object sender, EventArgs e)
        {
            openChildForm(new registrationLedger_form());
        }

        private void btnInregistrariModificari_Click(object sender, EventArgs e)
        {
            openChildForm(new registrationEdit_form());
        }
        #endregion

        #region StatusReparatiiSubmenu
        private void btnStatusReparatii_Click(object sender, EventArgs e)
        {
            showSubMenu(panelStatusReparatiiSubmenu);
        }

        private void btnStatusInLucru_Click(object sender, EventArgs e)
        {
            openChildForm(new statusWorking_form());

        }

        private void btnStatusNeridicate_Click(object sender, EventArgs e)
        {
            openChildForm(new statusUnclaimed_form());
        }
        #endregion

        #region StatisticiReparatiiSubmenu
        private void btnStatistici_Click(object sender, EventArgs e)
        {
            /* To be implemented. */
            //openChildForm(new statistics_form());
        }
        #endregion
        
        /* Opens the .chm project. */
        private void btnInformatii_Click(object sender, EventArgs e)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string UserManual_path = Directory.GetParent(workingDirectory).Parent.FullName + "\\UserManual\\UserManual.chm";
            Process UserManual = new Process();
            UserManual.StartInfo.FileName = UserManual_path;
            UserManual.Start();
        }

        /* User logout method. */
        private void btnIesire_Click(object sender, EventArgs e)
        {
            userLogin_form.UtilizatorID = 0;
            userLogin_form.username = "";
            this.Close();
            userLogin_form loginform = new userLogin_form();
            loginform.Show();
        }
        #endregion
        private Form activeForm = null;             // the child form needs to be stored apart from the main form
        private void openChildForm(Form childForm)  // this method works for only 1 child form being open in the main form
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

        #region MainFormButtons
        private void btnMainFormExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMainFormMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMainFormMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion
    }
}
