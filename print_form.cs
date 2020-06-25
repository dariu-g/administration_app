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
    public partial class print_form : Form
    {

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
            Microsoft.Reporting.WinForms.ReportParameter[] parameters = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pid_reparatie", _param.id_reparatie.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pnume", _param.nume.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pprenume", _param.prenume.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pnr_telefon", _param.nr_telefon.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("p_tip_telefon", _param.tip_telefon.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pmodel", _param.model.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pimei", _param.imei.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pdefect_constatat", _param.defect_constatat.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pobservatii", _param.observatii.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pdata_primirii", _param.data_primirii.ToString("dd/MM/yyyy")),
                new Microsoft.Reporting.WinForms.ReportParameter("pdata_predarii", _param.data_predarii.ToString("dd/MM/yyyy")),
                new Microsoft.Reporting.WinForms.ReportParameter("ppiese_inlocuite", _param.piese_inlocuite.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("ppretachitat", _param.pret_achitat.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pgarantie", _param.garantie.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pculoare", _param.culoare.ToString())
            };
            this.reportViewer.LocalReport.SetParameters(parameters);
            this.reportViewer.RefreshReport();
        }
    }
}
