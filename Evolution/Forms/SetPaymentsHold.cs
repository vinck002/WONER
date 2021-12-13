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
    public partial class SetPaymentsHold : Form
    {
        public SetPaymentsHold()
        {
            InitializeComponent();
        }
        DataView ContractView = new DataView();
        DataView PayHold = new DataView();
        General.Sqlcommandexecuter SqlCmd = new General.Sqlcommandexecuter();
        string currentdate = DateTime.Now.ToShortDateString();
      
        private void bApplyHold_Click(object sender, EventArgs e)
        {
          
            if (ContractList.RowCount < 1) { return; }
            Wait frmwait = new Wait();
            string SqlQuery = "";
             try
            {

                frmwait.Show(); frmwait.Refresh();
               for(int record=0; record <= ContractList.RowCount -1; record++)
                {/*------------------------------------------------------------------------------------------------------------------------------------------------*/
                    if (int.Parse(ContractList.Rows[record].Cells["Select"].Value.ToString()) == 1)
                    {
                        SqlQuery = SqlQuery + " " + "EXEC LS_SETPAYMENTSHOLD_M "+ int.Parse(ContractList.Rows[record].Cells["agreementid"].Value.ToString()) + "";
                    }
                    /*------------------------------------------------------------------------------------------------------------------------------------------------*/
                }
                /*------------------------------------------------------------------------------------------------------------------------------------------------*/
                if (SqlQuery == "") { MessageBox.Show("Not Contracts Selected", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if ( MessageBox.Show("Confirm Apply Hold", "OWNER", MessageBoxButtons.YesNo , MessageBoxIcon.Question )== DialogResult.No ) { return; }
                PayHold = SqlCmd.SQLdata(SqlQuery).DefaultView;
                bSearch.PerformClick();
                MessageBox.Show("Done", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information );
                /*------------------------------------------------------------------------------------------------------------------------------------------------*/
            }
            catch (Exception exc) { MessageBox.Show(exc.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { frmwait.Close(); }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
          
          
            if (Salesfloorid.Text.Trim() == "") { MessageBox.Show("Missing Sales Floor","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning ); Salesfloorid.Focus(); return; }
           if (DateTime.Parse(Contractdate2.Text) > DateTime.Parse(currentdate)) { MessageBox.Show("Date is Bigger Than Current Date", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                radLabel1.Visible = false;
                Found.Visible = false;

                Wait wwt = new Wait();
                bgwSearch.RunWorkerAsync();
                wwt.ShowDialog();
               
            }
            catch (Exception exc) { MessageBox.Show(exc.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void FillGridView()
        {
            ContractList.DataSource = ContractView;
           if ( ContractView.Count < 1) { MessageBox.Show("Not Record Found", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Information ); return; }
            Found.Text = ContractView.Count.ToString();
            radLabel1.Visible = true ;
            Found.Visible = true;
        }

        private void SetPaymentsHold_Load(object sender, EventArgs e)
        {

        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetPaymentsHold_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
            Contractdate1.SetToNullValue();
            Contractdate2.Value = Convert.ToDateTime(currentdate);
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            Salesfloorid.Text = "";
            Propertyid.Text = "";
            Agreementnumber1.Text = "";
            Agreementnumber2.Text = "";
            Contractdate1.SetToNullValue();
            Contractdate2.Value = Convert.ToDateTime(currentdate);
            Salesfloorid.Focus();

        }

        private void Salesfloorid_TextChanged(object sender, EventArgs e)
        {
            if (Salesfloorid.TextLength >= 2)
            {
                Salesfloorid.Text = Salesfloorid.Text; Propertyid.SelectionStart = 0;
                Propertyid.SelectionLength = Propertyid.Text.Length; Propertyid.Focus(); 
            }
        }

        private void Propertyid_TextChanged(object sender, EventArgs e)
        {
            if (Propertyid.TextLength >= 2)
            { Propertyid.Text = Propertyid.Text; Agreementnumber1.Focus();  }
        }

        private void Agreementnumber1_TextChanged(object sender, EventArgs e)
        {
            Agreementnumber2.Text = Agreementnumber1.Text;
        }

        private void Salesfloorid_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Propertyid_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Agreementnumber1_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Agreementnumber2_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Checkall1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
           
        }

        private void ContractList_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {if(ContractList.RowCount < 1) { return; }
            PaymentDetail paydetail = new PaymentDetail();
            decimal totalpaid1 = 0;
            paydetail.datecreate = Contractdate2.Text;
            totalpaid1 = 0;
            paydetail.Controls["radGroupBox2"].Controls["AgreementNumber"].Text = ContractList.CurrentRow.Cells["agreementnumber"].Value.ToString();
            paydetail.Controls["radGroupBox2"].Controls["Membername"].Text = "";
            paydetail.Controls["radGroupBox2"].Controls["TotalPaid1"].Text = totalpaid1.ToString("#,##0.00");
            paydetail.agreementid = ContractList.CurrentRow.Cells["agreementid"].Value.ToString();
            paydetail.Option = "1";
            paydetail.ShowDialog();

        }

        private void Checkall1_CheckStateChanged(object sender, EventArgs e)
        {
            if (ContractList.RowCount < 1) { return; }
            for (int record = 0; record <= ContractList.Rows.Count - 1; record++)
            {
                ContractList.Rows[record].Cells["Select"].Value = ((Checkall1.CheckState == CheckState.Checked)? 1 : 0);
            }
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            ContractView = SqlCmd.SQLdata("LS_SETPAYMENTSHOLD_L " + Salesfloorid.Text + "," + ((Propertyid.Text == "") ? "Null" : Propertyid.Text) + "," +
                    ((Agreementnumber1.Text == "") ? "1" : Agreementnumber1.Text) + "," + ((Agreementnumber2.Text == "") ? "999999999" : Agreementnumber2.Text) + ",'" +
                    ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text) + "','" + Contractdate2.Text + "'").DefaultView;
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillGridView();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }
        /*-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
