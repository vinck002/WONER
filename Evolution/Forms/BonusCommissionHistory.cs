using Evolution.General;
using Evolution.Models;
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
    public partial class BonusCommissionHistory : Form
    {
        Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
        List<BonusCommissionModel> BonusCommissionModel = new List<BonusCommissionModel>();
        IBonusCommissioner _Caller;
        //List<BonusCommssionDetailModel> BonusCommissionDetailModel = new List<BonusCommssionDetailModel>();

        DataTable BonusCommisionControl = new DataTable();
        public BonusCommissionHistory()
        {
            InitializeComponent();
            DateTime DateTex = DateTime.Now;
            Contractdate1.Text = DateTex.AddMonths(-1).ToString("MM-dd-yyyy") ;
            Contractdate2.Text = DateTex.ToString("MM-dd-yyyy");
            ControlButton();
            //Globalvariables.UserPassword = "0000";  //pass
        }
        public BonusCommissionHistory(IBonusCommissioner Caller):
            this()
        {
            _Caller = Caller;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            FunctionBonusHistory(0);

        }

        void FunctionBonusHistory(int opc)
        {
            string SearchCommand = $"Sp_BONUSCOMMISSIONHISTORY {opc},'{(txtBonusCode.Text.Length > 0 ? txtBonusCode.Text : "0")}'," +
                $"'{(Contractdate1.Text == string.Empty ? "01-01-2021" : Contractdate1.Text)}','{(Contractdate2.Text == string.Empty ? DateTime.Now.ToString("MM-dd-yyyy") : Contractdate2.Text)}'" +
                $",'',0,0,{(opc == 3 || opc == 6 ? DTGBonusCommission.CurrentRow.Cells["BonusCommissionID"].Value:0)},{Globalvariables.guserid}";
            BonusCommissionModel = SQLCMD.SQLdata(SearchCommand)
                .AsEnumerable().Select(x => new BonusCommissionModel
                {
                    BonusCommissionID = Convert.ToInt64(x.Field<Int64>("BonusCommissionID")),
                    ContractQuantity = Convert.ToInt32(x.Field<int>("ContractQuantity")),
                    AgreementsIdBatch = x.Field<string>("AgreementsIdBatch"),
                    DateFrom = x.Field<DateTime>("DateFrom"),
                    DateTo = x.Field<DateTime>("DateTo"),
                    Code = x.Field<string>("Code"),
                    UserId = x.Field<Int64>("UserId"),
                    User = x.Field<string>("UserName"),
                    TotalPaidToContracts = Convert.ToDecimal(x.Field<decimal>("TotalPaidToContracts")),
                    CreationDate = x.Field<DateTime>("CreationDate"),
                    Processed = x.Field<int>("Processed")
                }).ToList();

            DTGBonusCommission.DataSource = BonusCommissionModel;
            DTGBonusCommission.Columns["DateFrom"].FormatString = "{0:yyyy/MM/dd}";
            DTGBonusCommission.Columns["DateTo"].FormatString = "{0:yyyy/MM/dd}";
            DTGBonusCommission.Columns["CreationDate"].FormatString = "{0:yyyy/MM/dd}";


        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            try
            {
                if (DTGBonusCommission != null)
                {
                    if (DTGBonusCommission.RowCount > 0 )
                    {
                        Authorization aauto = new Authorization();
                        if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            FunctionBonusHistory(3);
                            _Caller.TemplateBathAgreement(null, 0, 0, null, null, null);
                            MessageBox.Show("Done!");
                        }
                        else { return; }

                    }
                }
              
            }
            catch (Exception)
            {
            }
          
           
            
          
        }

        private void txtBonusCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bSearch.PerformClick();
            }
        }

        private void DTGBonusCommission_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                
                bUndo.PerformClick();
            }
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            txtBonusCode.Text = string.Empty;
            DTGBonusCommission.DataSource = null;
            DateTime DateTex = DateTime.Now;
            Contractdate1.Text = DateTex.AddMonths(-1).ToString("MM-dd-yyyy");
            Contractdate2.Text = DateTex.ToString("MM-dd-yyyy");
        }

        private void DTGBonusCommission_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            BonnusCommissionerSP BCS = new BonnusCommissionerSP();
            List<BonusCommissionerModel> ListCommisionerDetail = new List<BonusCommissionerModel>();
            DataTable ContractSeach = BCS.batchAgreements(1, string.Empty, string.Empty,e.Row.Cells["AgreementsIdBatch"].Value.ToString());
            //IBonusCommissioner ListCommissioner = this.Owner as IBonusCommissioner;

            ListCommisionerDetail = BCS.LoadCommissioner(1, Convert.ToInt64(e.Row.Cells["BonusCommissionID"].Value));

            if (ListCommisionerDetail != null)
                _Caller.TemplateBathAgreement(ContractSeach,Convert.ToInt32(e.Row.Cells["Processed"].Value), Convert.ToInt64(e.Row.Cells["BonusCommissionID"].Value)
                                                                            ,e.Row.Cells["DateFrom"].Value.ToString(),e.Row.Cells["DateTo"].Value.ToString()
                                                                            , e.Row.Cells["Code"].Value.ToString());
                _Caller.CommissionerInfo(ListCommisionerDetail);

            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            try
            {
                if (DTGBonusCommission != null)
                {
                    if (DTGBonusCommission.RowCount > 0 )
                    {
                       
                            Authorization aauto = new Authorization();
                            if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                FunctionBonusHistory(6);
                            //_Caller.CommissionerInfo(null);
                            _Caller.TemplateBathAgreement(null, 0, 0, null,null,null);
                            MessageBox.Show("Done!");
                            }
                            else { return; }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void ControlButton()
        {
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 471 && x.Field<int>("Value") == 1).Count() > 0)
            {
                btnRemove.Visible = true;
            }
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 472 && x.Field<int>("Value") == 1).Count() > 0)
            {
                bUndo.Visible = true;
            }

        }
    }
}
