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
    public partial class HoldSettlement : Form
    {
        public HoldSettlement()
        {
            InitializeComponent();
        }
        public string agreementid,agreementnumber,membername;
        DataView contractview = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        string currentdate = DateTime.Now.ToShortDateString();
        private void bApply_Click(object sender, EventArgs e)
        {
            int status = 0;
            /*---------------------------------------------------------------------------------*/
            if (transactionshold.RowCount >0)
           { 
            if (bHold.IsChecked == true & transactionshold.Rows[0].Cells["status"].Value.ToString().Trim() == "HOLD") { MessageBox.Show("This Contract is Hold", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (bRelease.IsChecked == true & transactionshold.Rows[0].Cells["status"].Value.ToString().Trim() == "RELEASED") { MessageBox.Show("This Contract is Released", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
           }
            /*----------------------------------------------------------------------------------*/
            if (Comment.Text.Trim() == "") { MessageBox.Show("Type A Reference", "OWNER", MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            if (Transactiondate.Text.Trim() == "") { MessageBox.Show("Select Application Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (DateTime.Parse(Transactiondate.Text) > DateTime.Parse(currentdate)) { MessageBox.Show("Date is Bigger Than Current Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (bHold.IsChecked == true) { status = 1; }else { status = 0; }
            contractview = SQLCMD.SQLdata("LS_HOLDSETTLEMENT_M2 0,0," + agreementid + ","+General.Globalvariables.guserid+","+
               status  +",'"+Comment.Text+"','"+Transactiondate.Text+"'").DefaultView;
            FillGrid();
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void HoldSettlement_Activated(object sender, EventArgs e)
        {
            Transactiondate.SetToNullValue();
        }

        private void HoldSettlement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void HoldSettlement_Load(object sender, EventArgs e)
        {
            AgreementNumber.Text = agreementnumber;
            Membername.Text = membername;
           
            FillGrid();
        }
        private void FillGrid()
        {
            contractview = SQLCMD.SQLdata("LS_HOLDSETTLEMENT_L2 " + agreementid + "").DefaultView;
            
            if (contractview.Count < 1) { return; }
            transactionshold.DataSource = contractview;
        }
        /*----------------------------------------------------------------------------------------*/
    }
}
