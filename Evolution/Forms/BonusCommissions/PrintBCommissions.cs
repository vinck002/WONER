using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Evolution.Models;

namespace Evolution.Forms.BonusCommissions
{
    public class PrintBCommissions
    {
        public void PrintCrystal(DataTable BathAgreement, DataTable BonusCommissionDetail,DataTable MainBonusCommission, bool pdf = false)
        {
            BonusCommissionReport bComR = new BonusCommissionReport();
            ReportDocument DocRep = new ReportDocument();
           
            string ruta = Path.Combine(Application.StartupPath, @"Reports\BonusCommissionerMainReport.rpt");

            DocRep.Load(ruta);
            DocRep.SetDataSource(MainBonusCommission);
            DocRep.OpenSubreport("BonusCommisioner");
            DocRep.OpenSubreport("Sub_BonusCommissioner");
            DocRep.Subreports[0].SetDataSource(BonusCommissionDetail);
            DocRep.Subreports[1].SetDataSource(BathAgreement);

            bComR.crystalReportViewer1.ReportSource = DocRep;
      
            //DocRep.SetDatabaseLogon("", "");
            bComR.ShowDialog();
           
            if (pdf)
            {
                DocRep.ExportToDisk(ExportFormatType.PortableDocFormat, Path.Combine(Application.StartupPath, @"Docs\Commissioner.pdf"));
            }
           
        }

        public void PrintExcel()
        {

        }

    }
}
