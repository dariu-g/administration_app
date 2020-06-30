using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace AplicatieDisertatie
{
    public partial class print_form : Form
    {
        /* Global variables. */
        ledger_class _param;
        List<ledgerPrint_class> _list = new List<ledgerPrint_class>();

        public print_form(ledger_class param, List<ledgerPrint_class> list)
        {
            InitializeComponent();
            _param = param;
            _list = list;
        }

        private void print_form_Load(object sender, EventArgs e)
        {
            ledgerPrintclassBindingSource.DataSource = _list;
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("pid_reparatie", _param.id_reparatie.ToString()),

                new ReportParameter("pnume", _param.nume.ToString()),
                new ReportParameter("pprenume", _param.prenume.ToString()),
                new ReportParameter("pnr_telefon", _param.nr_telefon.ToString()),

                new ReportParameter("p_tip_telefon", _param.tip_telefon.ToString()),
                new ReportParameter("pmodel", _param.model.ToString()),
                new ReportParameter("pimei", _param.imei.ToString()),
                new ReportParameter("pgarantie", _param.garantie.ToString()),
                new ReportParameter("pculoare", _param.culoare.ToString()),
                new ReportParameter("pcod_telefon", _param.cod_telefon.ToString()),

                new ReportParameter("pdefect_constatat", _param.defect_constatat.ToString()),
                new ReportParameter("pobservatii", _param.observatii.ToString()),
                new ReportParameter("pdata_primirii", _param.data_primirii.ToString("dd/MM/yyyy")),
                new ReportParameter("ppret_estimativ", _param.pret_estimativ.ToString()),
                new ReportParameter("ppret_avans", _param.pret_avans.ToString()),
                new ReportParameter("ppretachitat", _param.pret_achitat.ToString()),
                new ReportParameter("ptermen_rezolvare", _param.termen_rezolvare.ToString())
            };
            this.reportViewer.LocalReport.SetParameters(parameters);
            this.reportViewer.RefreshReport();
        }
    }
}
