using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution.Forms
{
    public partial class SelectReport : Form
    {
        public SelectReport()
        {
            InitializeComponent();
        }
        DataView reportview = new DataView();
        public DataView DVreport = new DataView();
        public string salesfloor,contractdate1,contractdate2,contract1,contract2,status, propertyid,paid,agreementid;

        private void SelectReport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.Close(); }
        }

        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bPrint_Click(object sender, EventArgs e)
        { if(contract1 == "") { contract1 = "0"; }
            if (contract2 == "") { contract2 = "0"; }
            if(contractdate1 == "") { contractdate1 = null; }
            if (salesfloor == "") { salesfloor = "null"; }
            if (propertyid == "") { propertyid = "null"; }
            ReportViewer repo = new ReportViewer();
            string path = "";
            Wait espera = new Wait();
            try
            {
                espera.Show(); espera.Refresh();
                /*-------------------------------------------------------------------------------------------------------------*/
                if (bsummary.IsChecked == true)
                {
                    path = "Reports\\SALES_SETTLEMENT.rpt";
                    repo.Inforeport = DVreport;
                }
                /*-------------------------------------------------------------------------------------------------------------*/
                if (bDetail.IsChecked == true)
                {
                    path = "Reports\\CUSTOMER_BALANCE.rpt";
                    reportview = SQLCMD.SQLdata("LS_SUMMARYPAYMENTREPORT_L " + salesfloor + ",'" + contractdate1 + "','" + contractdate2 + "'," + contract1 + "," +
                       contract2 + ",'" + status + "'," + propertyid + ","+paid+",'"+agreementid+"'").DefaultView;
                       repo.Inforeport = reportview;
                }
                /*-------------------------------------------------------------------------------------------------------------*/
                if (bOwnership.IsChecked == true)
                {
                    path = "Reports\\OWNERSHIP_SETTLEMENT.rpt";
                    reportview = SQLCMD.SQLdata("LS_LIQUIDACIONVENTAS_PROPIETARIA_L1 " + salesfloor + ",'" + contractdate1 + "','" + contractdate2 + "'," + contract1 + "," +
                        contract2 + ",'" + status + "'," + propertyid + "").DefaultView;
                    repo.Inforeport = reportview;
                }
                /*-------------------------------------------------------------------------------------------------------------*/
                repo.reportpath = path;
                repo.Show();
                if (bDetail.IsChecked == true & ExportToExcel.Checked == true)
                {
                    General.ExportPayments exportpayment = new General.ExportPayments();
                     exportpayment.ExportPaymentToExcel(reportview,contractdate1,contractdate2);
                }
            } catch(Exception ecx) { MessageBox.Show(ecx.Message,"OWNER"); }
            finally { espera.Close(); }
        }
    }
}
