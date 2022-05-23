using Evolution.Forms.FormControlTools;
using Evolution.Forms.RealEstate.ControlsFuntions;
using Evolution.Forms.RealEstate.Registry;
using Evolution.General;
using Persistence.DataBase.RealEstateMoldels;
using Persistence.DataBase.RealEstateMoldels.Dto;
using Services.RealEstate.Owner;
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
using Telerik.WinControls.Data;

namespace Evolution.Forms.RealEstate
{
    public partial class RealEstatePropertyModal : Form
    {

        private IPropertyBenefit _RegistryProperty;
        RealEstateRegistryModel _RealEstateRegistry;
        private List<RealEstatePropertyModel> lstRealEstateProperty;
        private List<RealEstateProjectTypeModel> lstRealEstateProjectType = new List<RealEstateProjectTypeModel>();
        private List<RealEstatePropertyTypeModel> lstRealEstatePropertyType= new List<RealEstatePropertyTypeModel>();
        private List<RealEstateBankTranferenceModel> lstrealEstateBankTranference;
        CompositeFilterDescriptor _compositeFilter;
        private PaymentMethodFrequency PaymentMethodFrequency;
        private PaymentMethodModel _PaymentMethodtranfer;
        private List<FuturesPmtPlanDto> FuturesPmtMadeDto = new List<FuturesPmtPlanDto>();
        DateTime _EfectiveDate;

        private int anualbenefitTempID = 0;

        public RealEstatePropertyModal()
        {
            InitializeComponent();
            loadInitialInfo();
            LoadMainInfo();
        }
        public RealEstatePropertyModal(RealEstateRegistryModel RealEstateRegistry) :this()
        {
            _RealEstateRegistry = RealEstateRegistry;
        }
        //-------------------METHOS AND FUNCT------------------------------------------------------------------
        #region DataFunction
        private void loadInitialInfo()
        {
            Owner OwnerBenefitPaymentInfo = new Owner();
            lstRealEstateProperty = OwnerBenefitPaymentInfo.GetPropertyAndType();
            cbPropertyMultyC.DataSource = lstRealEstateProperty;
            FilterPropertiesFind();

        }

        private void LoadMainInfo()
        {
            Owner _Owner = new Owner();
            lstRealEstateProperty = _Owner.GetPropertyAndType();
            PaymentMethodFrequency = _Owner.GetPaymentMethodFrequency();
            //--------------------------------------------Owner Benefits Area------------------------------------------
            cbPaymentMethod.ValueMember = "PaymentMethodID";
            cbPaymentMethod.DisplayMember = "Description";
            cbPaymentMethod.DataSource = PaymentMethodFrequency.PaymentMethod;
            //--------------------------------------------Owner Futures Area------------------------------------------
            cbFutureMethod.ValueMember = "PaymentMethodID";
            cbFutureMethod.DisplayMember = "Description";
            cbFutureMethod.DataSource = PaymentMethodFrequency.PaymentMethod;

            cbPaymentFrequency.ValueMember = "RealEstatePaymentFrecuencyID";
            cbPaymentFrequency.DisplayMember = "Description";
            cbPaymentFrequency.DataSource = PaymentMethodFrequency.RealEstatePaymentFrecuency.Where(x => x.Active == 1).OrderByDescending(o=>o.FrecuenceValue);
          
            dtpContractDate.Value = DateTime.Today;

            //--------------------------------------------Owner Property Area-----------------------------------------------------------------------//
            dtpStartDateHold.Value = DateTime.Today;


            FilterPropertiesFind(); // Filter to find cbPropertyMultyC
                
        }

        void FilterPropertiesFind()
        {
            cbPropertyMultyC.AutoFilter = true;
            _compositeFilter = new CompositeFilterDescriptor();
            FilterDescriptor filter2 = new FilterDescriptor("Description", FilterOperator.Contains, "");
            _compositeFilter.FilterDescriptors.Add(filter2);
            cbPropertyMultyC.EditorControl.FilterDescriptors.Add(_compositeFilter);
        }
        #endregion



        //-- -----------------------------------------------------------

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void RealEstatePropertyModal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void RealEstatePropertyModal_Load(object sender, EventArgs e)
        {

        }

        private void cbLocation_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
          
        
        }

        private void cbPropertyMultyC_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
        DialogResult MensageYesNo(string msg, string titulo)
        {
            return MessageBox.Show(msg, titulo, MessageBoxButtons.YesNo);
        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            _RegistryProperty = this.Owner as IPropertyBenefit;
            MainControls.ChangeColorByTag(this, new int[] { 255, 255, 192 }, 2);

            if (Convert.ToDecimal(txtAnnualBenefit.Text.Trim() == "" ? "0.00" : txtAnnualBenefit.Text) <= 0)
            {
                return;
            }

           

            if (Convert.ToInt64(cbPaymentMethod.SelectedValue) == 1 )
            {
                if (!_RealEstateRegistry.RealEstateBanksTransference.Any())
                {
                    //MessageBox.Show("There is no bank transfer information");
                    DialogResult msg2 = MensageYesNo("There is no transfer information, you want to create it?", "Add transfer information First?");
                    if (msg2 == DialogResult.Yes)
                    {

                        this.Close();
                 
                    }
                    else
                    {
                        return;
                    }
                    return;
                }

            }
           
            //UserModel _userModel = new UserModel {FirstName = Globalvariables.Userfullname };

            dtpContractDate.Value = DateTime.Today;
            _EfectiveDate = new DateTime(4000, 01, 01);
            if (_RealEstateRegistry == null)
            {
                DialogResult dialogResult = MessageBox.Show("Do you Want Create New Registry", "New Registry", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (_RealEstateRegistry.RealEstateAnualBenefit == null)
                    {
                        _RealEstateRegistry.RealEstateAnualBenefit = new List<RealEstateAnualBenefitModel>();
                    }
                }
                else
                {
                    return;
                }

                //controlar un mensaje para generar un nuevo registro
            }


            if (_RealEstateRegistry.RealEstateAnualBenefit.Any(p=>p.RealEstateProperty.RealEstatePropertyID == Convert.ToInt64(cbPropertyMultyC.MultiColumnComboBoxElement.Rows[cbPropertyMultyC.SelectedIndex].Cells[0].Value)))
            {
                MessageBox.Show("This property is already in use");
                return;
            }
            else
            {
                List<RealEstateHoldInstallment> holdInstallmentMod = new List<RealEstateHoldInstallment>();
                if (SwithcHold.Value)
                {
                    DateTime temp;
                    if (!(DateTime.TryParse(dtpStartDateHold.Value.ToShortDateString(),out temp)))
                    {
                        MessageBox.Show("Wrong or empty date format");
                        return;
                    }

                     holdInstallmentMod.Add(new RealEstateHoldInstallment()
                    {
                        StartingDate = dtpStartDateHold.Value,
                        FinalDate = DateTime.TryParse(dtpAndDateHold.Value.ToShortDateString(), out temp) ? new DateTime(DateTime.Today.Year, 12, 30) : dtpAndDateHold.Value,
                        Active = 1,
                        CreationDate = DateTime.Today,
                        UserID = Globalvariables.guserid

                    });

                }

                int PropertyID = Convert.ToInt32(cbPropertyMultyC.MultiColumnComboBoxElement.Rows[cbPropertyMultyC.SelectedIndex].Cells[0].Value);
                _RealEstateRegistry.RealEstateAnualBenefit.Add(new RealEstateAnualBenefitModel
                {
                    UserId = Globalvariables.guserid,
                    AnnualBenefit = txtAnnualBenefit.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtAnnualBenefit.Text),
                    Amount = txtBenefitAmount.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtBenefitAmount.Text.Replace("$", "")),
                    EfectiveDate = _EfectiveDate,
                    RealEstatePaymentFrecuencyID = Convert.ToInt64(cbPaymentFrequency.SelectedValue),
                    Active = 1,
                    PaymentMethodID = Convert.ToInt64(cbPaymentMethod.SelectedValue),
                    ContractDate = dtpContractDate.Value,
                    CreationDate = DateTime.Today,
                    RealEstateHoldInstallment = holdInstallmentMod.Count > 0 ? holdInstallmentMod : null,
                    RealEstatePropertyID = PropertyID,
                    RealEstateProperty = lstRealEstateProperty.Where(x => x.RealEstatePropertyID == Convert.ToInt64(cbPropertyMultyC.MultiColumnComboBoxElement.Rows[cbPropertyMultyC.SelectedIndex].Cells[0].Value)).FirstOrDefault()
                    ,
                    RealEstatePaymentFrecuency = PaymentMethodFrequency.RealEstatePaymentFrecuency.Where(x => x.RealEstatePaymentFrecuencyID == Convert.ToInt64(cbPaymentFrequency.SelectedValue)).FirstOrDefault()
                    //, PaymentMethod = PaymentMethodFrequency.PaymentMethod.Where(x => x.PaymentMethodID == Convert.ToInt64(cbPaymentMethod.SelectedValue)).FirstOrDefault()
                });

            }
            int PropertyID2 = Convert.ToInt32(cbPropertyMultyC.MultiColumnComboBoxElement.Rows[cbPropertyMultyC.SelectedIndex].Cells[0].Value);
            if (chPaymentPlan.Checked)
            {
                _RegistryProperty.SelectBenefit(_RealEstateRegistry, PropertyID2, FuturesPmtMadeDto);
            }
            else
            {
                _RegistryProperty.SelectBenefit(_RealEstateRegistry, PropertyID2);
            }
            FuturesPmtMadeDto = null;
            gvFuturePayment.DataSource = null;
            MainControls.ClearTextBox(pPaymentPlan);
            //this.Close();

        }

        private void cbProject_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //    if (cbProject.SelectedIndex < 0)
            //    {
            //        return;
            //    }
            //comboFilter();


        }


       

        private void cbPropertyMultyC_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbPropertyMultyC.DataSource != null)
            {
                if (cbPropertyMultyC.SelectedIndex == -1)
                {

                    return;
                }
            }
        }

        private void cbPropertyMultyC_Enter(object sender, EventArgs e)
        {
            FilterPropertiesFind();
        }

        private void cbLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        #region functions
        void AnnualBenefit()
        {
            if (txtAnnualBenefit.Text.Length > 0)
            {
                txtBenefitAmount.Text = (Convert.ToDecimal(txtAnnualBenefit.Text) / Convert.ToDecimal(PaymentMethodFrequency.RealEstatePaymentFrecuency.Where(x => x.RealEstatePaymentFrecuencyID == Convert.ToInt64(cbPaymentFrequency.SelectedValue)).FirstOrDefault().FrecuenceValue.ToString())).ToString("C2");
            }
        }
        #endregion

        private void txtAnnualBenefit_Leave(object sender, EventArgs e)
        {
            AnnualBenefit();
        }

        private void cbPaymentMethod_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cbPaymentMethod.Items.Count < 1)
            {
                return;
            }
            if (Convert.ToInt32(cbPaymentMethod.SelectedValue) ==  1)
            {
                cbWtranfer.Enabled = true;
                pAddWTranfer.Enabled = true;
            }
            else
            {
                cbWtranfer.Enabled =false;
                pAddWTranfer.Enabled = false;
            }
        }

        private void pAddWTranfer_Click(object sender, EventArgs e)
        {
            PaymentWtInfo PaymentWtInfo = new PaymentWtInfo();
            AddOwnedForm(PaymentWtInfo);
            PaymentWtInfo.ShowDialog();
        }

        private void cbPaymentFrequency_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cbPaymentFrequency.SelectedIndex >= 0)
            {
                AnnualBenefit();
            }
            
        }

        private void txtAnnualBenefit_KeyPress(object sender, KeyPressEventArgs e)
        {

            Functions.onleyDecimal(sender, e);
        }

        private void cbPaymentMethod_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void SwithcHold_ValueChanged(object sender, EventArgs e)
        {
            if (SwithcHold.Value)
            {
              
                dtpStartDateHold.Enabled = true;
                dtpAndDateHold.Enabled = true;
            }
            else
            {
                dtpStartDateHold.Enabled = false;
                dtpAndDateHold.Enabled = false;
            }
        }

        private void pAddWTranfer_ImageLoaded(object sender, EventArgs e)
        {

        }

        private void chPAddPPlan_ValueChanged(object sender, EventArgs e)
        {
            pPaymentPlan.Visible = chPAddPPlan.Value;
            if (!chPAddPPlan.Value)
            {
                this.Height = 189;
            }
            else
            {
                this.Height = 433;
            }
        }

        private void RealEstatePropertyModal_Shown(object sender, EventArgs e)
        {
            this.Height = 189;
        }

        private void btnSaveBenefit_Click(object sender, EventArgs e)
        {
            if (MainControls.ChangeColorByTag(pPaymentPlan, new int[] { 255, 255, 192 }, 2))
            {
                return;
            };
            anualbenefitTempID++;
            DateTime paymentDate = dtpStartDateFuture.Value;
            if (FuturesPmtMadeDto == null)
            {
                FuturesPmtMadeDto = new List<FuturesPmtPlanDto>();
            }
            for (int i = 0; i < Convert.ToInt32(txtmoth.Text); i++)
            {

                if (!gvFuturePayment.Rows.AsEnumerable().Any(x => Convert.ToDateTime(x.Cells["Date"].Value).Month == paymentDate.Month))
                {
                  
                    FuturesPmtMadeDto.Add(new FuturesPmtPlanDto
                    {
                        anualbenefitTempID = 0
                     ,
                        tempID = 0
                      ,PropertyID = Convert.ToInt64(cbPropertyMultyC.MultiColumnComboBoxElement.Rows[cbPropertyMultyC.SelectedIndex].Cells["RealEstatePropertyID"].Value)

                       , RealEstateAnualBenefitID = 0
                     ,
                        Paid = false
                     ,
                        Date = paymentDate
                     ,
                        Amount = Convert.ToDecimal(txtAmountFuture.Text)
                     ,
                        AmountPaid = 0
                     ,
                        PaymentMethod = cbFutureMethod.Text
                     ,PaymentMethodID = Convert.ToInt64(cbFutureMethod.SelectedValue)
                        ,
                        user = Globalvariables.Userfullname
                     ,
                        Undo = false
                        ,UserID =Globalvariables.guserid
                    });;

                    //insertamos los registros nuevos directo en el contexto de la entidad registry
                   
                }
                paymentDate = paymentDate.AddMonths(1);

            }
            LoadPaymentGrid();
            MainControls.ClearTextBox(pPaymentPlan);
        }
        void LoadPaymentGrid()
        {
            gvFuturePayment.DataSource = null;
            gvFuturePayment.DataSource = FuturesPmtMadeDto;
        }

        private void btundo_Click(object sender, EventArgs e)
        {
            try
            {
                if (FuturesPmtMadeDto != null)
                {
                FuturesPmtMadeDto.RemoveAll(x => x.Undo == true);

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Sorry,nothing changed!");
            }
            LoadPaymentGrid();
        }

        private void gvFuturePayment_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //************para los undo
            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                if (e.Row.Cells["Undo"].Value != null)
                {
                    e.Row.Cells["Undo"].Value = !(bool)e.Row.Cells["Undo"].Value;

                }
            }
        }

        private void chPaymentPlan_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
   

            pPaymentPlan.Visible = chPaymentPlan.Checked;
            if (!chPaymentPlan.Checked)
            {
                this.Height = 189;
            }
            else
            {
                this.Height = 433;
            }
        }
    }
}
