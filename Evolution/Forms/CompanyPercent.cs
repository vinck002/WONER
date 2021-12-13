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
    public partial class CompanyPercent : Form
    {
        public CompanyPercent()
        {
            InitializeComponent();
        }
        int option = 0;
        long CompanyPercentID = 0,DistPercentID=0,SumDistribution=0;
        DataView DVCompany = new DataView();
        DataView DVCompanyLoad = new DataView();
        DataView CC = new DataView();
        DataView DvPercent = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();

        private void LoadCompany()
        {
            DVCompanyLoad = SQLCMD.SQLdata("Ls_CompanyPercent_L").DefaultView;
            CompanyList.DataSource = DVCompanyLoad;
        }
        private void Btnnew_Click(object sender, EventArgs e)
        {
            CompanyName.Text = "";
            StartDate.Text= DateTime.Now.ToShortDateString(); 
            Company_Percent.Value = 0;
            PayAfter.Value = 0;
            ClosingPercent.Value = 0;
            TaxPercent.Value = 0;
            Sales.Checked = false;
            ClosingCost.Checked = false;
            Tax.Checked = false;
            option = 0;
            FromPercent.Value = 0; Pay.Value = 0;
            PercentList.Rows.Clear();
            radGroupBox4.Enabled =  true;
            PercentList.Enabled =  true;
            PayComplete.Checked = true;
            PercentList.Rows.Clear();
            CompanyName.Focus();
        }

        private void Btnsave_Click(object sender, EventArgs e)
        { /*-----------Validation-----------------------------------------------*/
            if (CompanyName.Text.Trim() == "") { MessageBox.Show("Missing Field Company Name","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); CompanyName.Focus(); return; }
            if (StartDate.Text.Trim() == "") { MessageBox.Show("Missing Field Start Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); StartDate.Focus(); return; }
            if (decimal.Parse(PayAfter.Value.ToString()) <= 0) { MessageBox.Show("Missing Field Pay After", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); PayAfter.Focus(); return; }
            if (decimal.Parse(PayAfter.Value.ToString()) > 100) { MessageBox.Show("Pay After Is Greater Than 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); PayAfter.Focus(); return; }
            if (decimal.Parse(Company_Percent.Value.ToString()) <=0) { MessageBox.Show("Missing Field Sales Percent", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning);  return; }
            if (decimal.Parse(Company_Percent.Value.ToString()) > 100) { MessageBox.Show("Sales Percent Is Greater Than 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning);  return; }
           if(Sales.Checked == false) { MessageBox.Show("Missing Field Sales Percent", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); Sales.Focus(); return; }
           /*---------------------------------------------------------------------------*/
            if (ClosingCost.Checked == true)
            {
                if (decimal.Parse(ClosingPercent.Value.ToString()) <= 0) { MessageBox.Show("Missing Field closing Percent", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (decimal.Parse(ClosingPercent.Value.ToString()) > 100) { MessageBox.Show("Closing Percent Is Greater Than 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                
            }
            /*------------------------------------------------------------------------*/
            if (Tax.Checked == true)
            {
                if (decimal.Parse(TaxPercent.Value.ToString()) <= 0) { MessageBox.Show("Missing Field Tax Percent", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (decimal.Parse(TaxPercent.Value.ToString()) > 100) { MessageBox.Show("Tax Percent Is Greater Than 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            }
    
            /*------------------------------------------------------------------------------------------------------------------------------------------------*/
            DVCompany = SQLCMD.SQLdata("LS_CompanyPercent_M "+option+","+CompanyPercentID+",'"+CompanyName.Text+"','"+StartDate.Value+"',"+Company_Percent.Value+","+
             PayAfter.Value +","+ Company_Percent.Value + ","+((ClosingCost.Checked==true)? ClosingPercent.Value : 0) +","+
             ((Tax.Checked == true) ? TaxPercent.Value : 0) + ","+ General.Globalvariables.guserid + ","+((PayComplete.Checked ==true)? 1 : 0)+"").DefaultView;
            /*-------------------------------------------------------------------------------------------------------------*/
            LoadCompany();
            Btnnew.PerformClick();
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*------------------------------------------------------------------------------------------------------------------------------------------------*/
        }

        private void CompanyPercent_Load(object sender, EventArgs e)
        {
            
        }

        private void CompanyPercent_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
            LoadCompany();
            StartDate.Text = "";
            CompanyName.Focus();
        }

        private void CompanyList_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(CompanyList.Rows.Count < 1) { return; }
            option = 1;
            CompanyPercentID = long.Parse(CompanyList.CurrentRow.Cells["CompanyPercentID"].Value.ToString());
            CompanyName.Text = CompanyList.CurrentRow.Cells["companyname"].Value.ToString();
            StartDate.Text = CompanyList.CurrentRow.Cells["startdate"].Value.ToString();
            Company_Percent.Value = decimal.Parse(CompanyList.CurrentRow.Cells["percent"].Value.ToString());
            PayAfter.Value = decimal.Parse(CompanyList.CurrentRow.Cells["payafter"].Value.ToString());
            Sales.Checked = true;
            ClosingCost.Checked = ((decimal.Parse(CompanyList.CurrentRow.Cells["closingcost"].Value.ToString()) <=0)? false : true);
            Tax.Checked = ((decimal.Parse(CompanyList.CurrentRow.Cells["tax"].Value.ToString()) <= 0) ? false : true);
            ClosingPercent.Value = ((decimal.Parse(CompanyList.CurrentRow.Cells["closingcost"].Value.ToString()) <= 0) ? 0 : decimal.Parse(CompanyList.CurrentRow.Cells["closingcost"].Value.ToString()));
            TaxPercent.Value = ((decimal.Parse(CompanyList.CurrentRow.Cells["tax"].Value.ToString()) <= 0) ? 0 : decimal.Parse(CompanyList.CurrentRow.Cells["tax"].Value.ToString()));
           // FillGridDistrinution();/*Lenar distribucion*/
            PayComplete.Checked = ((int.Parse(CompanyList.CurrentRow.Cells["PayWithDistribution"].Value.ToString()) == 1)? true :false);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {/*---------------------------------------------------------------------*/
            if (CompanyList.Rows.Count < 1) { return; }
            if(CompanyPercentID <= 0) { MessageBox.Show("Please Select A Company", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*------------------------------------------------------------------------------------------------------------------------------------------------*/
            if(MessageBox.Show("Confirm Deletion", "OWNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No){ return; }
            DVCompany = SQLCMD.SQLdata("LS_CompanyPercent_M 2," + CompanyPercentID + ",'" + CompanyName.Text + "','" + StartDate.Value + "'," + Company_Percent.Value + "," +
             PayAfter.Value + "," + Company_Percent.Value + "," + ((ClosingCost.Checked == true) ? Company_Percent.Value : 0) + "," +
             ((Tax.Checked == true) ? Company_Percent.Value : 0) + "," + General.Globalvariables.guserid + ",0").DefaultView;
            /*---------------------------------*/
            LoadCompany();
            Btnnew.PerformClick();
            MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*------------------------------------------------------------------------------------------------------------------------------------------------*/
        }

        private void Sales_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Company_Percent.Enabled = ((Sales.Checked == true)? true : false);
        }

        private void ClosingCost_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            ClosingPercent.Enabled = ((ClosingCost.Checked == true)? true : false);
        }

        private void Tax_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            TaxPercent.Enabled = ((Tax.Checked == true)? true : false);
        }

        private void PercentList_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            FromPercent.Value = PercentList.CurrentRow.Cells["from"].Value.ToString();
            Pay.Value = PercentList.CurrentRow.Cells["Pay"].Value.ToString();
            DistPercentID = ((int.Parse(PercentList.CurrentRow.Cells["ID"].Value.ToString()) == 0) ? 1 : int.Parse(PercentList.CurrentRow.Cells["ID"].Value.ToString()));
        }

        private void PayComplete_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            
            radGroupBox4.Enabled = ((PayComplete.Checked==true)?false: true);
            PercentList.Enabled = ((PayComplete.Checked == true) ? false : true);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            /*------------------Validar-------------------------------------*/
            if (decimal.Parse(PayAfter.Value.ToString()) <= 0) { MessageBox.Show("Missing Field Pay After", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); PayAfter.Focus(); return; }
            if (decimal.Parse(Company_Percent.Value.ToString()) <=0) { MessageBox.Show("Missing Field Company Percent", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Company_Percent.Focus(); return; }
            if (decimal.Parse(FromPercent.Value.ToString()) <=0) { MessageBox.Show("Type From Percent", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); FromPercent.Focus(); return; }
            if (decimal.Parse(FromPercent.Value.ToString()) <= 0 || decimal.Parse(FromPercent.Value.ToString()) > 100) { MessageBox.Show("From Percent Must Be Between 0% And 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); FromPercent.Focus(); return; }
            if (decimal.Parse(Pay.Value.ToString()) <= 0) { MessageBox.Show("Type Pay Percent", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Pay.Focus(); return; }
            if (decimal.Parse(Pay.Value.ToString()) <= 0 || decimal.Parse(Pay.Value.ToString()) > 100) { MessageBox.Show("Pay Percent Must Be Between 0% And 100%", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Pay.Focus(); return; }
   

            /*--------------------------------------------------------------------------------------------------------*/
            if (DistPercentID == 0)
            {
                PercentList.Rows.Add(FromPercent.Value, Pay.Value, DistPercentID);
                FromPercent.Value = 0; Pay.Value = 0;
                DistPercentID = 0;
                FromPercent.Focus();
            }else
            {
                PercentList.CurrentRow.Cells["from"].Value = FromPercent.Value;
                PercentList.CurrentRow.Cells["Pay"].Value = Pay.Value;
                FromPercent.Value = 0; Pay.Value = 0;
                DistPercentID = 0;
                FromPercent.Focus();
            }
            /*---------------------------------------------------------------------------------------------------------*/
        }
        private void SumPercentDistribution()
        {
            if(PercentList.RowCount < 1) { return; }
            SumDistribution = 0;
            for (int Record=0; Record <= PercentList.RowCount -1; Record++)
            {
                SumDistribution = SumDistribution + long.Parse(PercentList.Rows[Record].Cells["Pay"].Value.ToString());
            }
            /*-------------------------------------------------------------------------*/
        }
        private void FillGridDistrinution()
        {
            PercentList.Rows.Clear();
            DvPercent = SQLCMD.SQLdata("LS_CompanyPercentDistribution_L "+CompanyPercentID+"").DefaultView;
            if(DvPercent.Count < 1) { return; }
            foreach(DataRowView DV in DvPercent)
            {
                PercentList.Rows.Add(DV["Since"], DV["PayPercent"], DV["CompanyPercentDistributionID"]);
            }
            PercentList.Rows[0].IsCurrent = true;
            /*--------------------------------------------------------------------------------------*/
        }
        /*==================================================FIN================================================================================================================================*/
    }
}
