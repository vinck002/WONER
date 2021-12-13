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
    public partial class ContractInfoView : Form
    {
        public ContractInfoView()
        {
            InitializeComponent();
        }
        DataView DVContractInfo = new DataView();
        DataView DVContractPay = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        private void Btnsearch_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            try
            {   if(SalesfloorID.Text.Trim() == "")
                {
                    if(MessageBox.Show("Search All Contracts ?", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                }
                wwt.Show(); wwt.Refresh();
                DVContractInfo = SQLCMD.SQLdata("LS_ContractInfoView_L "+((SalesfloorID.Text.Trim()=="")?"null" : SalesfloorID.Text.Trim())+","+ ((PropertyID.Text.Trim() == "") ? "null" : "'"+PropertyID.Text.Trim()+"'") + ","+
                 ((Contract1.Text.Trim() == "") ? "1" : Contract1.Text.Trim()) + ","+ ((Contract2.Text.Trim() == "") ? "9999999999" : Contract2.Text.Trim()) + ",'"+
                ((CreationDate1.Text.Trim() == "") ? "01-01-1990" : CreationDate1.Text.Trim()) + "','"+ ((CreationDate2.Text.Trim() == "") ? "01-01-3000" : CreationDate2.Text.Trim()) + "'").DefaultView;
                FillGridInfo();
            }
            catch(Exception ecx) { MessageBox.Show(ecx.Message,"OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { wwt.Close(); }

        }
        private void FillGridInfo()
        {
            ContractList.Rows.Clear();
            //ContractPaying.Rows.Clear();
            TotalContracts.Rows.Clear();
            if (DVContractInfo.Count < 1) { MessageBox.Show("No Record Found", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            int R1 = 0;
            string AgreementNumber = "";
            decimal TotalContract = 0, DistPrice = 0, DistClosing = 0, DistTax = 0, NetTotal = 0;
            foreach (DataRowView DV in DVContractInfo)
            {/*--------------------------------------------------------------------------------------------------*/

                TotalContract = decimal.Parse(DV["price"].ToString()) + decimal.Parse(DV["closingcost"].ToString()) + decimal.Parse(DV["tax"].ToString());
                DistPrice = decimal.Parse(DV["pricedist"].ToString());
                DistClosing = decimal.Parse(DV["closingdist"].ToString());
                DistTax = decimal.Parse(DV["taxdist"].ToString());
                NetTotal = TotalContract - (DistPrice + DistClosing + DistTax);
                /*--------------------------------------------------------------------------------------------------*/
                ContractList.Rows.Add(DV["Company"], DV["agreementnumber"], DV["price"], DV["closingcost"], DV["tax"], DV["payafter"], DV["pricepercent"], DV["closingpercent"],
                    DV["taxpercent"], DV["pricedist"], DV["closingdist"], DV["taxdist"], DV["totalDist"], DV["SALES_SETTLED"], DV["Closing_SETTLEd"], DV["TAX_SETTLEd"], DV["PayoffAmount"], DV["PayoffPercent"]);
                if (decimal.Parse(DV["closingpercent"].ToString()) > 100) { ContractList.Rows[R1].Cells["ClosingPercent"].Style.ForeColor = Color.Red; }
                if (decimal.Parse(DV["Taxpercent"].ToString()) > 100){ ContractList.Rows[R1].Cells["TaxPercent"].Style.ForeColor = Color.Red; }
                R1 = R1 + 1;
                /*--------------------------------------------------------------------------------------*/
              //  ContractPaying.Rows.Add(DV["Company"], DV["agreementnumber"], DV["SALES_SETTLED"], DV["Closing_SETTLEd"], DV["TAX_SETTLEd"]);
                /*---------------------------------------------------------------------------------------*/
                if (R1 == 1) { TotalContracts.Rows.Add(DV["agreementnumber"], TotalContract, DistPrice, DistClosing, DistTax, NetTotal); }
                if (R1 > 1)
                {
                    if (AgreementNumber == DV["agreementnumber"].ToString())
                    {
                        TotalContracts.CurrentRow.Cells["totalmembership"].Value = decimal.Parse(TotalContracts.CurrentRow.Cells["totalmembership"].Value.ToString()) + DistPrice;
                        TotalContracts.CurrentRow.Cells["totalclosing"].Value = decimal.Parse(TotalContracts.CurrentRow.Cells["totalclosing"].Value.ToString()) + DistClosing;
                        TotalContracts.CurrentRow.Cells["totaltax"].Value = decimal.Parse(TotalContracts.CurrentRow.Cells["totaltax"].Value.ToString()) + DistTax;
                        TotalContracts.CurrentRow.Cells["nettotal"].Value = TotalContract - (/**/decimal.Parse(TotalContracts.CurrentRow.Cells["totalmembership"].Value.ToString()) +
                         decimal.Parse(TotalContracts.CurrentRow.Cells["totalclosing"].Value.ToString()) + decimal.Parse(TotalContracts.CurrentRow.Cells["totaltax"].Value.ToString()) /**/);
                    }
                    else
                    { TotalContracts.Rows.Add(DV["agreementnumber"], TotalContract, DistPrice, DistClosing, DistTax, NetTotal); }

                }
                AgreementNumber = DV["agreementnumber"].ToString();
                /*--------------------------------------------------------------------------------------*/
                TotalContracts.CurrentRow.Cells["totalmembership"].Style.ForeColor = ((decimal.Parse(DV["price"].ToString()) < decimal.Parse(TotalContracts.CurrentRow.Cells["totalmembership"].Value.ToString())) ? Color.Red : Color.Black);
                TotalContracts.CurrentRow.Cells["totalclosing"].Style.ForeColor = ((decimal.Parse(DV["price"].ToString()) < decimal.Parse(TotalContracts.CurrentRow.Cells["totalclosing"].Value.ToString())) ? Color.Red : Color.Black);
                TotalContracts.CurrentRow.Cells["totaltax"].Style.ForeColor = ((decimal.Parse(DV["price"].ToString()) < decimal.Parse(TotalContracts.CurrentRow.Cells["totaltax"].Value.ToString())) ? Color.Red : Color.Black);
                TotalContracts.CurrentRow.Cells["nettotal"].Style.ForeColor = ((decimal.Parse(TotalContracts.CurrentRow.Cells["nettotal"].Value.ToString()) < 0) ? Color.Red : Color.Black);
                /*---------------------------------------------------------------------------------------*/
            }
            ContractPaying.DataSource = DVContractInfo;
            ContractList.Rows[0].IsCurrent = true;
           // ContractPaying.Rows[0].IsCurrent = true;
            TotalContracts.Rows[0].IsCurrent = true;
        }

        private void ContractInfoView_Load(object sender, EventArgs e)
        {
            CreationDate1.SetToNullValue();
            CreationDate2.Text = DateTime.Now.ToShortDateString();
        }

        private void ContractInfoView_Activated(object sender, EventArgs e)
        {
            SalesfloorID.Focus();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            CreationDate1.SetToNullValue();
            CreationDate2.Text = DateTime.Now.ToShortDateString();
            SalesfloorID.Text = "";
            PropertyID.Text = "";
            Contract1.Text = "";
            Contract2.Text = "";
            SalesfloorID.Focus();
        }

        private void ContractInfoView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void Contract2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { Btnsearch.PerformClick(); }
        }

        private void Contract1_KeyPress(object sender, KeyPressEventArgs e)
        { if (e.KeyChar == 13)
            {
                Contract2.SelectionStart = 0;
                Contract2.SelectionLength = Contract2.Text.Length; Contract2.Focus();
            }
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.TextLength >= 2)
            {
                SalesfloorID.Text = SalesfloorID.Text; PropertyID.SelectionStart = 0;
                PropertyID.SelectionLength = PropertyID.Text.Length; PropertyID.Focus();
            }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.TextLength >= 2)
            { PropertyID.Text = PropertyID.Text; Contract1.Focus();  }
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            //Wait wwt = new Wait();
            //try
            //{
            //    if (ContractList.RowCount < 1) { return; }
            //    wwt.Show(); wwt.Refresh();
                General.ContractsCommission ContractsCommission = new General.ContractsCommission();
                ContractsCommission.ExportContractCommission(ContractList,TotalContracts);
            //}
            //catch (Exception ecx)
            //{ MessageBox.Show(ecx.Message,"OWNER",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            //finally { wwt.Close(); }
        }
        /*---------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
