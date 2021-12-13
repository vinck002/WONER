using Evolution.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Evolution.Forms
{
    public partial class TravelAgentCommission : Form
    {
        GridViewFilter gridfilter = new GridViewFilter();
        public TravelAgentCommission()
        {
            InitializeComponent();
        }
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        DataView DV = new DataView();
        DataView DvSave = new DataView();
        List<string> lstTravelAgent;
        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            bgwSearch.RunWorkerAsync();
            wwt.ShowDialog();
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
           
            //var a = Convert.ToInt32(CBTravelAgent.SelectedValue);

            DV = SQLCMD.SQLdata($"LS_TravelAgentCommission_SPR {((rdbAll.IsChecked==true)?"NULL" : (rdbPaid.IsChecked==true)?"1" : "0")},"+
            $"{((SalesfloorID.Text.Trim()=="")? "Null" : SalesfloorID.Text.Trim())},"+
            $"{((PropertyID.Text.Trim() == "")? "Null" : "'"+ PropertyID.Text.Trim() +"'") },"+
            $"'{((Contractdate1.Text =="")?"01-01-1990" : Contractdate1.Text)}','{((Contractdate2.Text == "") ? "01-01-3000" : Contractdate2.Text)}',"+
            $"{((Contract1.Text == "") ? "1" : Contract1.Text)},{((Contract2.Text == "") ? "9999999999" : Contract2.Text)}," +
            $"{ ((CBTravelAgent.SelectedIndex) > -1 ? Convert.ToInt32(CBTravelAgent.SelectedValue) : 0)}").DefaultView;

            //var tmp = myCollection.GroupBy(x => x.Id)
            //          .Select(y => new {
            //              Id = y.Key,
            //              Quantity = y.Sum(x => x.Quantity)
            //          });

            //lstTravelAgent = DV.Table.AsEnumerable().GroupBy(x => x.Field<string>("AgentName"))
            //    .Select(y => y.Key).ToList();
           
            //foreach (var item in lstTravelAgent)
            //{
            //    CBTravelAgent.Items.Add(item);
            //}
            //CBTravelAgent.SelectedIndex = -1;
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grdCommission.DataSource = DV;
            _Summary();
            lblFound.Text = DV.Count.ToString();
            var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.Name == "Wait");
            frm.Close();
        }
        private void _Summary()
        {
            if (grdCommission.RowCount <= 0) { txtTotaltobepaid.Text = "0.00"; return; }
            decimal _grandtotal = 0;
            for (int row = 0; row <= grdCommission.RowCount - 1; row++)
            {
                if (int.Parse(grdCommission.Rows[row].Cells["Selected"].Value.ToString()) == 1)
                { 
                     _grandtotal = _grandtotal + decimal.Parse(grdCommission.Rows[row].Cells["ToPay"].Value.ToString());
                    
                }
                grdCommission.Rows[row].Cells["Selected"].ReadOnly = ((decimal.Parse(grdCommission.Rows[row].Cells["ToPay"].Value.ToString()) <= 0) ? true : false);
                grdCommission.Rows[row].Cells["ToPay"].Style.ForeColor = Color.Red;
            }
            txtTotaltobepaid.Text = _grandtotal.ToString("#,##0.00");
        }
        private void TravelAgentCommission_Load(object sender, EventArgs e)
        {
            
            Btnclear.PerformClick();

            CBTravelAgent.DataSource = SQLCMD.SQLdata($"sp_GetAllTravelAgentSources");
            CBTravelAgent.DisplayMember = "name";
            CBTravelAgent.ValueMember = "TravelAgentSourcesId";
            CBTravelAgent.SelectedIndex = -1;
            
            CBTravelAgent.AutoCompleteMode = AutoCompleteMode.Suggest;
            CBTravelAgent.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
        }
        private bool FilterTravelAgent(RadListDataItem item)
        {

            if (item.Text.Contains(CBTravelAgent.Text))
            {
                return true;
            }
            return false;
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            SalesfloorID.Text = ""; PropertyID.Text = ""; rdbNoPaid.IsChecked = true;
            Contract1.Text = ""; Contract2.Text = "";
            Contractdate1.Text = General.Globalvariables.Systemdate.AddDays(-8).ToShortDateString();
            Contractdate2.Text = General.Globalvariables.Systemdate.ToShortDateString();
            SalesfloorID.Focus();
            CBTravelAgent.SelectedIndex = -1;
        }

        private void bProccess_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdCommission.RowCount <= 0 || decimal.Parse(txtTotaltobepaid.Text) <= 0) { MessageBox.Show("Nothing To Pay", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                TravelAgentProcessHistory _process = new TravelAgentProcessHistory();
                _process.Text = "Travel Agent Process";
                _process.Controls["grbInfo"].Controls["Amount"].Text = txtTotaltobepaid.Text;
                _process.Controls["grbButton"].Controls["bUndo"].Visible = false;
                _process.Controls["grbButton"].Controls["btnExport"].Visible = false;
                _process.Controls["grbButton"].Controls["bApply"].Location = new Point(_process.Controls["grbButton"].Controls["bExit"].Location.X -100, _process.Controls["grbButton"].Controls["bApply"].Location.Y);
                _process.Height = 250;
                _process.Width = 450;
                /*-------------------------------------------------------------*/
                if (_process.ShowDialog() != DialogResult.OK) { return; }
                /*-------------------------------------------------------------*/
                StringBuilder _sqlquery = new StringBuilder();
                _sqlquery.Append("Set nocount on Declare @ID bigint=0" + " ");
                _sqlquery.Append($"Exec LS_TravelAgentCommission_SPM 0,0,'{General.Globalvariables.Systemdate.ToShortDateString()}','{ _process.Controls["grbInfo"].Controls["txtReference"].Text.Trim().Replace("'", "''")}'," +
                    $"{General.Globalvariables.guserid},@ID output" + " ");
                for (int row = 0; row <= grdCommission.RowCount - 1; row++)
                {
                    if (int.Parse(grdCommission.Rows[row].Cells["Selected"].Value.ToString()) == 1)
                    {
                        _sqlquery.Append($"Exec LS_TravelAgentCommissionDetail_SPM 0,0,{grdCommission.Rows[row].Cells["AgreementID"].Value.ToString()}," +
                        $"@ID,{decimal.Parse(grdCommission.Rows[row].Cells["ToPay"].Value.ToString())},{General.Globalvariables.guserid}" + " ");
                    }
                }
                _sqlquery.Append("Select ID=@ID");
                /*-----------------------------------------------------*/
                if (MessageBox.Show("Confirm Process", "Owner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                DvSave = SQLCMD.SQLdata(_sqlquery.ToString()).DefaultView;
                if (long.Parse(DvSave.Table.Rows[0]["ID"].ToString()) <= 0) { MessageBox.Show("Could Not Process Data", "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                bSearch.PerformClick();
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "Owner", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void grdCommission_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==0) { _Summary(); }
        }

        private void bHistory_Click(object sender, EventArgs e)
        {
            TravelAgentProcessHistory _process = new TravelAgentProcessHistory();
            _process.Text = "Travel Agent Process History";
            _process.Controls["grbInfo"].Visible = false;
            _process.Controls["grdHistory"].Visible = true;
            _process.Controls["grdCommission"].Visible = true;
            _process.Controls["grbButton"].Controls["bApply"].Visible = false;
            _process.FillGridHistory();
            _process.Height = 535;
            _process.Width = 575;
            _process.ShowDialog();
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            Wait wwt = new Wait();
            try
            {
                if (grdCommission.RowCount < 1) { return; }
                wwt.Show(); wwt.Refresh();
                General.TravelAgentCommissionExport exportar = new General.TravelAgentCommissionExport();
                exportar.ExportarGridview(grdCommission,1);
            }
            catch (Exception ecx) { MessageBox.Show(ecx.Message, "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { wwt.Close(); }
        }

        private void TravelAgentCommission_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void Contract1_TextChanged(object sender, EventArgs e)
        {
            Contract2.Text = Contract1.Text;
        }

        private void SalesfloorID_TextChanged(object sender, EventArgs e)
        {
            if (SalesfloorID.Text.Trim().Length >=2) { PropertyID.Focus(); }
        }

        private void PropertyID_TextChanged(object sender, EventArgs e)
        {
            if (PropertyID.Text.Trim().Length >= 2) { Contract1.Focus(); }
        }

        private void CBTravelAgent_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {                
            //DV.Table.DefaultView.RowFilter = $"AgentName= '{ CBTravelAgent.Text}' ";
        }

        private void CBTravelAgent_TextChanged(object sender, EventArgs e)
        {
          
            //if (CBTravelAgent.Text.Length == 0)
            //{
            //    //DV.Table.DefaultView.RowFilter = DV
            //}
        }
        /*================================================================================================================*/
    }
}
