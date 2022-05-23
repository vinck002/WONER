using Evolution.General;
using Evolution.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Evolution.Forms
{
    public partial class BonusCommisioner : Form
    {

        Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
        //DataTable CommissionerInfo = new DataTable();
        List<BonusCommissionerModel> ListCommissionerInfo = new List<BonusCommissionerModel>();
        BonusCommissionerModel CommissionerInfo;
        decimal SelectedRowAmount = 0;
        BonnusCommissionerSP LoadCom = new BonnusCommissionerSP();
        //Globalvariables.guserid 
        public BonusCommisioner()
        {
            InitializeComponent();
            LoadData();
        }

        void CountRows()
        {


            SelectedRowAmount = 0;
            foreach (var rowField in DTGCommisionerInfo.Rows)
            {
                if (Convert.ToBoolean(rowField.Cells["Selected"].Value))
                {
                    SelectedRowAmount += Convert.ToDecimal(rowField.Cells["Amount"].Value);
                }

            }
            txtContractFound.Text = DTGCommisionerInfo.RowCount.ToString();
            lblSumAmount.Text = SelectedRowAmount.ToString("C2");
        }


        private void LoadCommissioner()
        {

            ListCommissionerInfo = LoadCom.LoadCommissioner();


            if (ListCommissionerInfo.Count > 0)
            {
                DTGCommisionerInfo.DataSource = ListCommissionerInfo;
                //for (int i = 0; i < DTGCommisionerInfo.RowCount; i++)
                //{
                //    DTGCommisionerInfo.Rows[i].Cells["Selected"].Value = 1;
                //}

            }
        }


        private void bDone_Click(object sender, EventArgs e)
        {
            StringBuilder SelectedCommissionerLis = new StringBuilder();

            if (SelectedRowAmount > 300)
            {
                MessageBox.Show("The Selected Commissioner Amount Exceeds US$300");
                return;
            }
            try
            {
                List<BonusCommissionerModel> TMPLisbonusCommissionerModel = new List<BonusCommissionerModel>();

                TMPLisbonusCommissionerModel = DTGCommisionerInfo.Rows.AsEnumerable().Select(x => new BonusCommissionerModel
                {
                    CommissionerID = Convert.ToInt64(x.Cells["CommissionerID"].Value),
                    FullName = x.Cells["FullName"].Value.ToString(),
                    Amount = Convert.ToDecimal(x.Cells["Amount"].Value),
                    Selected = Convert.ToInt32(x.Cells["Selected"].Value) 
                }).ToList();

                TMPLisbonusCommissionerModel.ForEach(x => SelectedCommissionerLis.Append($"exec Sp_BonusCommissioner 0," +
                                                    $"3,{x.CommissionerID},'',0.00,1,{x.Selected}; "));

                SQLCMD.SQLdata(SelectedCommissionerLis.ToString());
                IBonusCommissioner ListCommissioner = this.Owner as IBonusCommissioner;
                if (ListCommissioner != null)
                    ListCommissioner.CommissionerInfo(TMPLisbonusCommissionerModel.Where(x=>x.Selected == 1).ToList());


            }
            catch (Exception)
            {

            }

            this.Close();
        }

        private void Btnnew_Click(object sender, EventArgs e)
        {
            pCommissionerInfo.Visible = true;
            if (CommissionerInfo != null)
            {
                CommissionerInfo.CommissionerID = 0;
                txtAmount.Text = string.Empty;
                txtFullName.Text = string.Empty;
            }
            else
            {
                CommissionerInfo = new BonusCommissionerModel();
                CommissionerInfo.CommissionerID = 0;
                txtAmount.Text = string.Empty;
                txtFullName.Text = string.Empty;
            }
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            if (pCommissionerInfo.Visible == false)
            {
                return;
            }

            if (txtFullName.Text == string.Empty || txtAmount.Text == string.Empty)
            {
                MessageBox.Show("Empty Fields");
                return;
            }

            try
            {
                if (CommissionerInfo == null)
                {
                    return;
                }
                var Oldname = CommissionerInfo.FullName;
                var OldAmount = CommissionerInfo.Amount;
                CommissionerInfo.FullName = txtFullName.Text;
                CommissionerInfo.Amount = txtAmount.Text == string.Empty ? 0 : Convert.ToDecimal(txtAmount.Text.Replace("$", string.Empty));

                if (CommissionerInfo.CommissionerID != 0)
                {

                    DialogResult Result = MessageBox.Show($"Do you want to change the Name:[ {Oldname} ] to [ {txtFullName.Text}]? " +
                     $"And Amount {OldAmount} to {txtAmount.Text}", "Changes", MessageBoxButtons.YesNo);

                    if (Result == DialogResult.Yes)
                    {
                        ListCommissionerInfo = SQLCMD.SQLdata($"exec Sp_BonusCommissioner {Globalvariables.guserid},2," +
                                   $"{CommissionerInfo.CommissionerID},'{CommissionerInfo.FullName}',{CommissionerInfo.Amount}").AsEnumerable().Select(x => new BonusCommissionerModel()
                                   {
                                       CommissionerID = x.Field<Int64>("CommissionerID"),
                                       FullName = x.Field<string>("FullName"),
                                       Amount = x.Field<decimal>("Amount")
                                   }).ToList();
                    }
                    else
                    {
                        LoadData();
                        return;
                    }
                }
                else
                {

                    ListCommissionerInfo = SQLCMD.SQLdata($"exec Sp_BonusCommissioner {Globalvariables.guserid},1," +
                    $"{CommissionerInfo.CommissionerID},'{CommissionerInfo.FullName}',{CommissionerInfo.Amount}").AsEnumerable().Select(x => new BonusCommissionerModel()
                    {
                        CommissionerID = x.Field<Int64>("CommissionerID"),
                        FullName = x.Field<string>("FullName"),
                        Amount = x.Field<decimal>("Amount")
                    }).ToList();


                }

                LoadData();

                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        void LoadData()
        {
            LoadCommissioner();
            txtFullName.Text = string.Empty;
            txtAmount.Text = string.Empty;
            CommissionerInfo = null;
            pCommissionerInfo.Visible = false;
            CountRows();
        }
        private void DTGCommisionerInfo_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            CommissionerInfo = new BonusCommissionerModel();

            pCommissionerInfo.Visible = Visible;

            CommissionerInfo = ListCommissionerInfo.FirstOrDefault(x => x.CommissionerID == Convert.ToInt64(DTGCommisionerInfo.CurrentRow.Cells["CommissionerID"].Value));
            txtFullName.Text = CommissionerInfo.FullName;
            txtAmount.Text = CommissionerInfo.Amount.ToString("C2");
            txtFullName.Focus();
        }



        private void Btndelete_Click(object sender, EventArgs e)
        {

            if (DTGCommisionerInfo.CurrentRow.IsSelected)
            {
                CommissionerInfo = new BonusCommissionerModel();
                CommissionerInfo.CommissionerID = Convert.ToInt64(DTGCommisionerInfo.CurrentRow.Cells["CommissionerID"].Value);
                CommissionerInfo.FullName = DTGCommisionerInfo.CurrentRow.Cells["FullName"].Value.ToString();
                CommissionerInfo.Amount = Convert.ToDecimal(DTGCommisionerInfo.CurrentRow.Cells["Amount"].Value);
                DialogResult Result = MessageBox.Show("Sure?", "Delete a Commissioner", MessageBoxButtons.YesNo);

                if (Result == DialogResult.Yes)
                {
                    ListCommissionerInfo = SQLCMD.SQLdata($"exec Sp_BonusCommissioner {Globalvariables.guserid},2," +
                             $"{CommissionerInfo.CommissionerID},'{CommissionerInfo.FullName}',{CommissionerInfo.Amount},0").AsEnumerable().Select(x => new BonusCommissionerModel()
                             {
                                 CommissionerID = x.Field<Int64>("CommissionerID"),
                                 FullName = x.Field<string>("FullName"),
                                 Amount = x.Field<decimal>("Amount")
                             }).ToList();
                    LoadData();
                    MessageBox.Show("Done!");
                }
                else
                {
                    return;
                }

            }
            else
            {
                MessageBox.Show("No row Selected!");
                return;
            }
            CountRows();
        }

        private void BonusCommisioner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pCommissionerInfo.Visible = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                //this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void DTGCommisionerInfo_RowsChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {
            CountRows();
        }
    }
}
