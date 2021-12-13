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
    public partial class HoldCanceledContract :Form
    {
        public HoldCanceledContract()
        {
            InitializeComponent();
        }
        public List<ContractsCanceled> ContractoCancelado = new List<ContractsCanceled>();
        DataView DvSave = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        private void HoldCanceledContract_Load(object sender, EventArgs e)
        {
            ApplicationDate.Text = General.Globalvariables.Systemdate.ToShortDateString();
            ApplicationDate.MaxDate = General.Globalvariables.Systemdate;
            GRDContractList.DataSource = ContractoCancelado;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void HoldCanceledContract_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.DialogResult = DialogResult.Cancel; }
        }
        public  class ContractsCanceled 
        {
            public int Selected { get; set; }
            public string ContractNo { get; set; }
            public string Status { get; set; }
            public double BalanceDue { get; set; }
            public long AgreementID { get; set; }
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            if(GRDContractList.RowCount < 1) { return; }
            if (Remarks.Text.Trim() =="") { MessageBox.Show("Missing Remarks","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); Remarks.Focus(); return; }
            StringBuilder SqlQuery = new StringBuilder();
            StringBuilder Sqlhold = new StringBuilder();
            try 
            {
                for (int Rw=0; Rw <= GRDContractList.RowCount -1; Rw++) 
                {
                    if (int.Parse(GRDContractList.Rows[Rw].Cells["Selected"].Value.ToString()) ==1) 
                    {
                        Sqlhold.Append("Exec LS_HOLDSETTLEMENT_M2 0,0," + GRDContractList.Rows[Rw].Cells["AgreementID"].Value.ToString() + "," + 
                            General.Globalvariables.guserid + ",1,'" + Remarks.Text.Trim().Replace("'","") + "','" + ApplicationDate.Text + "'"+" ");
                        /*--------------------------------------------*/
                        SqlQuery.Append("Exec LS_DOCUMENTTRANSACTION_M2 0,3," + GRDContractList.Rows[Rw].Cells["AgreementID"].Value.ToString() + ",'" +
                   Remarks.Text.Trim().Replace("'", "") + "','" + ApplicationDate.Text + "'," + General.Globalvariables.guserid + "," +
                   double.Parse(GRDContractList.Rows[Rw].Cells["BalanceDue"].Value.ToString()) + ""+" ");
                    }
                }
                /*------------------------------------------------------------------------*/
                if (SqlQuery.Length <=0) { MessageBox.Show("No Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if(MessageBox.Show("Confirm Set Hold with Cancelation Credit Note", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                /*------------------------------------------------------------------------*/
                DvSave = SQLCMD.SQLdata(SqlQuery.ToString()).DefaultView;
                DvSave = SQLCMD.SQLdata(Sqlhold.ToString()).DefaultView;
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
