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
    public partial class RealStateProcessHistory :Form
    {
        public RealStateProcessHistory()
        {
            InitializeComponent();
        }
        DataView DVPay = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        private void RealStateProcessHistory_Load(object sender, EventArgs e)
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
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            DVPay = SQLCMD.SQLdata($"RealStatePaymentHistory_SPL 3,0").DefaultView;
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grdPayments.DataSource = DVPay;
            _summary();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }
        private void _summary()
        {

            decimal _totalpaid = 0;
            
            if (grdPayments.RowCount > 0)
            {
                for (int R1 = 0; R1 <= grdPayments.RowCount - 1; R1++)
                {
                    _totalpaid = _totalpaid + decimal.Parse(grdPayments.Rows[R1].Cells["amount"].Value.ToString());
                }
            }
            txtTotalPaid.Text = _totalpaid.ToString("#,##0.00");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (grdPayments.RowCount < 1) { return; }
            string Info = "Amount = " + grdPayments.CurrentRow.Cells["Amount"].Value.ToString() + "\n" +
                    "Process No. = " + grdPayments.CurrentRow.Cells["processno"].Value.ToString();
            if (MessageBox.Show("Confirm Cancel Process \n\n" + Info, "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            try
            {
                string sqlquery = $"RealStatePaymentHistory_SPM 1,@ProcessCode={grdPayments.CurrentRow.Cells["processno"].Value.ToString()},@UserID={General.Globalvariables.guserid}";
                DVPay = SQLCMD.SQLdata(sqlquery).DefaultView;
                _fillgrid();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void RealStateProcessHistory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.Close(); }
        }

        private void radGroupBox5_Click(object sender, EventArgs e)
        {

        }
        /*=====================================================================================================*/
    }
}
