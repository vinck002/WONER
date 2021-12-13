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
    public partial class RealStatePaymentHistory : Form
    {
        public RealStatePaymentHistory()
        {
            InitializeComponent();
        }
        public long RealStateRegistryID = 0;
        DataView DVFee = new DataView();
        DataView DVPay = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        private void RealStatePaymentHistory_Load(object sender, EventArgs e)
        {
            _fillgrid();
            General.GlobalAccess acceso = new General.GlobalAccess();
            acceso.groubox(radGroupBox5);
        }
        private void _fillgrid()
        {
            Wait wwt = new Wait();
            bgwSearch.RunWorkerAsync();
            wwt.ShowDialog();
        }
        private void RealStatePaymentHistory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.Close(); }
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            DVFee = SQLCMD.SQLdata($"RealStatePaymentHistory_SPL 1,{RealStateRegistryID}").DefaultView;
            DVPay = SQLCMD.SQLdata($"RealStatePaymentHistory_SPL 2,{RealStateRegistryID}").DefaultView;
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grdFee.DataSource = DVFee;
            grdPayments.DataSource = DVPay;
            _summary();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }
        private void _summary()
        {
            
            decimal _totalpaid = 0, _totalgenerated = 0;
            if (grdFee.RowCount > 0)
            {
                for (int R1 = 0; R1 <= grdFee.RowCount - 1; R1++)
                {
                    _totalgenerated = _totalgenerated + decimal.Parse(grdFee.Rows[R1].Cells["amount"].Value.ToString());
                }
            }
            if (grdPayments.RowCount > 0)
            {
                for (int R1 = 0; R1 <= grdPayments.RowCount - 1; R1++)
                {
                    _totalpaid = _totalpaid + decimal.Parse(grdPayments.Rows[R1].Cells["amount"].Value.ToString());
                }
            }
            txtTotalFeeGenerated.Text = _totalgenerated.ToString("#,##0.00");
            txtTotalPaid.Text = _totalpaid.ToString("#,##0.00");

        }

        private void btnInactive_Click(object sender, EventArgs e)
        {
            if (grdPayments.RowCount < 1) { return; }
            string Info = "Amount = " + grdPayments.CurrentRow.Cells["Amount"].Value.ToString() +"\n"+
                    "Process No. = " + grdPayments.CurrentRow.Cells["processno"].Value.ToString();
            if (MessageBox.Show("Confirm Inactive Payment \n\n"+Info, "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            try
            {
                string sqlquery = $"RealStatePaymentHistory_SPM 2,{grdPayments.CurrentRow.Cells["RealStatePaymentHistoryID"].Value.ToString()},@UserID={General.Globalvariables.guserid}";
                DVPay = SQLCMD.SQLdata(sqlquery).DefaultView;
                _fillgrid();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
