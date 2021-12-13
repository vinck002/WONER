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
    public partial class MemberCommisionDevolution : Form
    {
        public MemberCommisionDevolution()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DVSearch = new DataView();
        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MemberCommisionDevolution_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DVSearch = SQLCMD.SQLdata("LS_MemberPaymentDevolution_L").DefaultView;
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void SumCommision()
        {
            if (DVSearch.Count < 1) { TotalToBePaid.Text = "0.00"; TotalPaid.Text = "0.00"; return; }
            decimal Topay = 0, Paid = 0;
            for (int record = 0; record <= ContractList.RowCount - 1; record++)
            {
                Topay = Topay + decimal.Parse(ContractList.Rows[record].Cells["ToPay"].Value.ToString());
                Paid = Paid + decimal.Parse(ContractList.Rows[record].Cells["CommisionPaid"].Value.ToString());
            }
            TotalToBePaid.Text = Topay.ToString("#,##0.00");
            TotalPaid.Text = Paid.ToString("#,##0.00");
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ContractList.DataSource = DVSearch;
            Found.Text = DVSearch.Count.ToString();
            SumCommision();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }

        private void MemberCommisionDevolution_Load(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            backgroundWorker2.RunWorkerAsync();
            wwt.ShowDialog();
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            if (ContractList.RowCount < 1) { return; }
            Wait wwt = new Wait();
            try
            {
                wwt.Show(); wwt.Refresh();
                if (DVSearch.Count < 1) { return; }
                General.ExportMemberCommision exportar = new General.ExportMemberCommision();
                exportar.ExportToExcel(DVSearch);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }
    }
}
