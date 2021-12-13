using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;
namespace Evolution.Forms
{
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
        }
        public string reportpath = "";
        public DataView Inforeport = new DataView();
        public bool Exportar = true;
        private void ReportViewer_Load(object sender, EventArgs e)
        {
            /*-----------------------------------------------------------------------*/
             try
            {
                string ruta = Path.Combine(Application.StartupPath, reportpath);
                ReportDocument repo = new ReportDocument();
                ParameterFields pf = new ParameterFields();
             
                repo.Load(ruta);
                repo.SetDataSource(Inforeport);
                crystalReportViewer2.ReportSource = repo;
                crystalReportViewer2.Refresh();
                crystalReportViewer2.ShowExportButton = Exportar;

            }
            catch (Exception ecx) { this.Name = ecx.Message; }
        }

        private void ReportViewer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void ReportViewer_Activated(object sender, EventArgs e)
        {
          
        }
    }
}
