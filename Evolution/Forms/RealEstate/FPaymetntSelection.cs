using Evolution.General;
using Persistence.DataBase.RealEstateMoldels;
using Services.RealEstate.Owner.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution.Forms.RealEstate
{
    public partial class FPaymetntSelection : Form
    {
        List<PaymentSelectionDto> PaymentSelection;
        private List<FuturesPmtPlanDto> _futuresPlans;
        private Int64 FPaymentID;
        decimal _totalAmount;
        decimal tempamount = 0;
        public List<RealEstatePmtTransactionModel> TransactionSelected = new List<RealEstatePmtTransactionModel>();
        public FPaymetntSelection()
        {
            InitializeComponent();
        }


        public FPaymetntSelection(decimal totalAmount, Int64 FPaymentID, List<FuturesPmtPlanDto> FuturesPlans,string _Description )
            :this()
        {
            _totalAmount = totalAmount;
            tempamount = _totalAmount;
            this.FPaymentID = FPaymentID;
            _futuresPlans = FuturesPlans;

            PaymentSelection = new List<PaymentSelectionDto>();
            foreach (var item in _futuresPlans.Where(x => x.Paid == false))
            {
                PaymentSelection.Add(new PaymentSelectionDto
                {
                    FuturesPmtPlanID = item.FuturesPmtPlanID
                    ,Amount = item.Amount - item.AmountPaid
                    ,Paying = item.FuturesPmtPlanID == FPaymentID? item.Amount- item.AmountPaid : 0
                   ,Check = item.FuturesPmtPlanID == FPaymentID
                   ,Date = item.Date
                   ,description = item.FuturesPmtPlanID != FPaymentID? "Partial Payment" : _Description 

                });
            }

            gvFuturePayment.DataSource = PaymentSelection;
            CalculateSelection(true);
        }

        private void CalculateSelection(bool firstTime = false) {

            decimal SumCheckedAmount = 0;
            gvFuturePayment.Rows.AsEnumerable().Where(x => Convert.ToBoolean(x.Cells["Check"].Value)).ToList()
                .ForEach(s =>
                {
                    SumCheckedAmount += Convert.ToDecimal(s.Cells["Paying"].Value);
                });
            if (firstTime)
            {
                tempamount -= SumCheckedAmount;
            }
            else
            {
              tempamount = _totalAmount - SumCheckedAmount;
            }
            lblTotalAmount.Text = (_totalAmount - SumCheckedAmount).ToString("C2");
            //UnCheckNoPayin();

        }

        void UnCheckNoPayin()
        {
            int cantidadChecked = 0;
            foreach (var item in gvFuturePayment.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Check"].Value))
                {
                    cantidadChecked++;

                }

            }
         
            if(cantidadChecked == gvFuturePayment.RowCount)
            {
                ChCheckUncheck.Checked = true;
            }
            else
            {
                ChCheckUncheck.Checked = false;
            }

        }

        private void gvFuturePayment_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                
                if (e.Row.Cells["Check"].Value != null)
                {
                    e.Row.Cells["Check"].Value = !(bool)e.Row.Cells["Check"].Value;

                    if (Convert.ToBoolean(e.Row.Cells["Check"].Value))
                    {
                        if (tempamount > Convert.ToDecimal(e.Row.Cells["Amount"].Value))
                        {
                            e.Row.Cells["Paying"].Value = e.Row.Cells["Amount"].Value;
                            tempamount -= Convert.ToDecimal(e.Row.Cells["Paying"].Value);
                        }
                        else
                        {
                            e.Row.Cells["Paying"].Value = tempamount;

                        }
                    }
                    else
                    {
                        e.Row.Cells["Paying"].Value = 0;
                    }

                    CalculateSelection();
                      
                }
                if (Convert.ToDecimal(e.Row.Cells["Paying"].Value) == 0)
                {
                    e.Row.Cells["Check"].Value = false;
                }

            }
      
            UnCheckNoPayin();
        }
       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

       

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (tempamount > 0)
            {
                MessageBox.Show("Still have remaining amount to spend");
                return;
            }
            foreach (var x in PaymentSelection.Where(x => x.Paying > 0).ToList())
            {
                TransactionSelected.Add(new RealEstatePmtTransactionModel
                {
                    Active = 1,
                    Amount = x.Paying
                    ,RealEstateFPaymentPlanID = x.FuturesPmtPlanID
                    ,ApplicationDate = x.Date
                    ,TransDate = DateTime.Today
                    ,Description = x.description
                });

            }
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ChCheckUncheck_Click(object sender, EventArgs e)
        {
            //ChCheckUncheck.Checked = !ChCheckUncheck.Checked;
            if (ChCheckUncheck.Checked)
            {

                    tempamount = _totalAmount;
                    for (int i = 0; i < gvFuturePayment.RowCount; i++)
                    {
                        if (tempamount > Convert.ToDecimal(gvFuturePayment.Rows[i].Cells["Amount"].Value))
                        {
                            gvFuturePayment.Rows[i].Cells["Paying"].Value = gvFuturePayment.Rows[i].Cells["Amount"].Value;
                            gvFuturePayment.Rows[i].Cells["Check"].Value = true;
                            tempamount -= Convert.ToDecimal(gvFuturePayment.Rows[i].Cells["Paying"].Value);
                        }
                        else
                        {
                            if (tempamount > 0)
                            {
                                gvFuturePayment.Rows[i].Cells["Check"].Value = true;
                                gvFuturePayment.Rows[i].Cells["Paying"].Value = tempamount;
                                tempamount -= tempamount;
                            }
                            else
                            {
                                gvFuturePayment.Rows[i].Cells["Paying"].Value = 0;
                                gvFuturePayment.Rows[i].Cells["Check"].Value = false;

                            }

                        }

                    }
            }
            else
            {
                tempamount = _totalAmount;
                for (int i = 0; i < gvFuturePayment.RowCount; i++)
                {
                    gvFuturePayment.Rows[i].Cells["Paying"].Value = 0;
                    gvFuturePayment.Rows[i].Cells["Check"].Value = false;
                }
            }
            
                //CalculateSelection();
            lblTotalAmount.Text = tempamount.ToString("C2");


        }

        private void ChCheckUncheck_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
