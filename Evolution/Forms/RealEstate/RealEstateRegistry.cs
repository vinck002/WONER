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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace Evolution.Forms.RealEstate
{
    public partial class RealEstateRegistry : Form, IPropertyBenefit, IOwnerRegistryInfo
    {

        //private List<RealEstateAnualBenefitModel> lstpropertyRemove = new List<RealEstateAnualBenefitModel>();
        //private OwneDbContext _OwneDbContext = new OwneDbContext();
        private RealEstateRegistryModel _RealEstateRegistry;
        private List<RealEstatePropertyModel> lstRealEstateProperty;
        private List<RealEstateContactTypeModel> lstRealEstateContactType;
        private List<BankTranferenceDto> lstBankTranferenceDto;
        private List<RealEstateRegOwneInfoModel> _realEstateRegOwneInfo;
        private List<RealEstateBankTranferenceModel> lstRealEstateBankTranference;
        private CompositeFilterDescriptor _compositeFilter;
        private RealEstatedBankModel _RealEstatedBank;
        private List<AnualBPropertiesDto> lstAnualBPropertiesDto;
        private List<ContactInfoDto> lstContactInfoDto;
        private List<UserModel> lstUsers;
        private PaymentMethodFrequency PaymentMethodFrequency;
        private RealEstateBankTranferenceModel _SelectedTransference;
        List<RealEstatePmtTransactionDto> TransactionDto;
        private Owner _Owner;
        private FormControl Onlydecimal;
        private OwnerInfoDto _OwnerInfoDto;
        private int Mode = 0; //0=New ; 1=Searching ; 3-Editing ; 3
        //DateTime _EfectiveDate;
        private int InfoBackNext = 0;
        private Int64 _SelectedOwAnBenId;
        private Int64 _RealEstatePropertyID = 0;
        private int _notSaveSecuence = 1;
        private object[] _PropertyID;
        private long _tempAccountNumber;
        //***********Payment Section"tab"
        int FirstTimeLoadPRopertyPayment = 0; //esta variable guarda las veces que ha ejecutado la funcion
        private int TempIdDto = 0;
        private int anualbenefitTempID = 0;
        private List<FuturesPmtPlanDto> FuturesPmtMadeDto = new List<FuturesPmtPlanDto>();
        List<RealEstatePmtTransactionModel> transactionPerAnualBenfit = new List<RealEstatePmtTransactionModel>();

        List<RealEstatePmtTransactionModel> TransactionSelected; //CAPTURA LAS TRANSACCIONES EN LA PANTALLA FPAYMENTSELECTIONS
        public List<RealEstatePmtTransactionModel> transactionSelected { get => TransactionSelected; set => TransactionSelected = value; }
        public object[] PropertyID { set => _PropertyID = value; get { return _PropertyID; } }


        public RealEstateRegistry()
        {
            InitializeComponent();

        }

        private void PgTransferSetup_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RealEstateRegistry_Load(object sender, EventArgs e)
        {
            LoadMainInfo();
            Onlydecimal = new FormControl();
            SpecialPermitValidations();
            LoadAllUsers();
        }


        private void LoadMainInfo()
        {
            Owner _Owner = new Owner();
            PaymentMethodFrequency = _Owner.GetPaymentMethodFrequency();
            //--------------------------------------------Owner Benefits Area------------------------------------------
            cbPaymentMethod.ValueMember = "PaymentMethodID";
            cbPaymentMethod.DisplayMember = "Description";
            cbPaymentMethod.DataSource = PaymentMethodFrequency.PaymentMethod.OrderByDescending(x => x.PaymentMethodID);
            cbPaymentMethod.SelectedIndex = -1;


            cbPaymentFrequency.ValueMember = "RealEstatePaymentFrecuencyID";
            cbPaymentFrequency.DisplayMember = "Description";
            cbPaymentFrequency.DataSource = PaymentMethodFrequency.RealEstatePaymentFrecuency.Where(x => x.Active == 1);
            cbPaymentFrequency.SelectedIndex = -1;

            //--------------------------------------------Payment Futures Area------------------------------------------
            cbFutureMethod.ValueMember = "PaymentMethodID";
            cbFutureMethod.DisplayMember = "Description";
            cbFutureMethod.DataSource = PaymentMethodFrequency.PaymentMethod.OrderByDescending(x => x.PaymentMethodID);

            cbPmtMethodFuture.ValueMember = "PaymentMethodID";
            cbPmtMethodFuture.DisplayMember = "Description";
            cbPmtMethodFuture.DataSource = PaymentMethodFrequency.PaymentMethod.Where(x=> x.PaymentMethodID != 2).OrderByDescending(x => x.PaymentMethodID);


            //-----------------------------CONTACT INFO
            cbContactType.DisplayMember = "Description";
            cbContactType.ValueMember = "RealEstateContactTypeID";
            cbContactType.DataSource = lstRealEstateContactType = PaymentMethodFrequency.RealEstateContactType;

            

        }

        private void radPictureBox1_Click(object sender, EventArgs e)
        {
            RealEstatePropertyModal RealEstateProperty = new RealEstatePropertyModal();
            AddOwnedForm(RealEstateProperty);
            RealEstateProperty.ShowDialog();
        }


        //************************************************************** METODO DE LA INTERFACE PARA CARGAR LOS DATOS DEl OWNER ANUAL BENEFIT
        public void SelectBenefit(RealEstateRegistryModel _owner, int PropID, List<FuturesPmtPlanDto> FuturesPmtPlanDto = null)
        {
            _RealEstateRegistry = null;
            _RealEstateRegistry = _owner;
            anualbenefitTempID++;
            //*****************************************************ASIGNACION DE ID TEMPORAL PARA OwNER BENEFIT************************************************

            _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(y => y.RealEstatePropertyID == PropID).TMPRealEstateAnualBenefitID = anualbenefitTempID;


            //*************************************************************************************************************************************************
            lstAnualBPropertiesDto = null;
            ChargeDtoAnualbenifitData(); //LISTA DE BENEFICIOS DE PROPIEDADES (lstAnualBPropertiesDto)
            AnualbenifitData();

            //----------------------------Payment
            cbTranferPmt.DisplayMember = "AccountName";
            cbTranferPmt.ValueMember = "AccountNumber";
            cbTranferPmt.DataSource = _RealEstateRegistry.RealEstateBanksTransference.Where(x => x.Active == 1);


            if (FuturesPmtPlanDto != null)
            {
                PaymentGeneradosModal(FuturesPmtPlanDto);
            }
            PaymentsArea();


        }
        //********************************************* Funcion que carga los pagos generados en el modal de agregar propiedades
        void PaymentGeneradosModal(List<FuturesPmtPlanDto> futuresPmtPlanDto)
        {


            futuresPmtPlanDto.ToList().ForEach(x =>
            {
                TempIdDto++;
                FuturesPmtMadeDto.Add(new FuturesPmtPlanDto
                {
                    anualbenefitTempID = anualbenefitTempID
                 ,
                    Description = x.Description
                    ,
                    tempID = TempIdDto
                  ,
                    RealEstateAnualBenefitID = 0
                 ,
                    Paid = false
                 ,
                    Date = x.Date
                 ,
                    Amount = x.Amount
                 ,
                    AmountPaid = 0
                 ,
                    PaymentMethod = x.PaymentMethod
                 ,
                    user = x.user
                 ,
                    Undo = x.Undo
                });

                //insertamos los registros nuevos directo en el contexto de la entidad registry
                _RealEstateRegistry.RealEstateAnualBenefit
                        .First(y => y.RealEstatePropertyID == x.PropertyID)
                        .RealEstateFPaymentPlan.Add(new RealEstateFPaymentPlanModel
                        {
                            Description = x.Description
                            ,
                            tempFPaymentPlanID = TempIdDto
                            ,
                            tempRealEstateAnualBenefitID = anualbenefitTempID
                            ,
                            RealEstateAnualBenefitID = 0
                            ,
                            UserID = x.UserID
                            ,
                            Active = 1
                            ,
                            Amount = x.Amount
                            ,
                            Date = x.Date
                            ,
                            PaymentMethodID = x.PaymentMethodID
                        });

            });
        }

        //**************************BOTON DE AGREGAR PROPIEDADES AL CONTRATO "BENEFIT"*********************************************
        private void btnAddContractProperty_Click(object sender, EventArgs e)
        {
            RealEstatePropertyModal RealEstateProperty = new RealEstatePropertyModal(_RealEstateRegistry);
            AddOwnedForm(RealEstateProperty);
            RealEstateProperty.ShowDialog();
        }
        //********************************Cargar los datos de grid de las propiedades
        private void AnualbenifitData()
        {
            gvAnualBenefits.DataSource = null;
            gvAnualBenefits.DataSource = lstAnualBPropertiesDto.Where(x => x.Active == 1);
            HabilitaDesPageView();

        }
        private void PaymentsArea() // area de pagos
        {
            MultyCSelectProperty.DataSource = lstAnualBPropertiesDto.Where(x => x.Active == 1 && x.Status >= 0);
            PaymentFuturePayment(_RealEstateRegistry.RealEstateAnualBenefit.ToList());
        }

        private void PaymentFuturePayment(List<RealEstateAnualBenefitModel> Ownerbenefit)
        {
            try
            {
                FuturesPmtMadeDto = null;
                FuturesPmtMadeDto = new List<FuturesPmtPlanDto>();
                Ownerbenefit.Where(z => z.Active == 1).ToList()
                    .ForEach(y => y.RealEstateFPaymentPlan
                    .Where(yy => yy.Active == 1).ToList()
                      .ForEach(FPaymentPlan =>
                      {
                          decimal amountPaid = SumFPlanAmountPaid(FPaymentPlan);
                          FuturesPmtMadeDto.Add(new FuturesPmtPlanDto
                          {
                              Description = FPaymentPlan.Description
                              ,
                              anualbenefitTempID = FPaymentPlan.tempRealEstateAnualBenefitID
                              ,
                              RealEstateAnualBenefitID = y.RealEstateAnualBenefitID
                             ,
                              FuturesPmtPlanID = FPaymentPlan.RealEstateFPaymentPlanID
                             ,
                              PaymentMethodID = FPaymentPlan.PaymentMethodID
                             ,
                              Amount = FPaymentPlan.Amount
                             ,
                              AmountPaid = amountPaid
                             ,
                              Date = FPaymentPlan.Date
                             ,
                              Paid = false
                              ,
                              tempID = 0
                              ,
                              user = $"{lstUsers.First(x => x.Id == FPaymentPlan.UserID).FirstName}  {lstUsers.First(x => x.Id == FPaymentPlan.UserID).LastName}"
                              ,
                              UserID = FPaymentPlan.UserID
                              ,
                              PaymentMethod = PaymentMethodFrequency.PaymentMethod.First(x => x.PaymentMethodID == FPaymentPlan.PaymentMethodID).Description
                          });
                      }
                        )
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            DysplayTransactionPerProperty();
        }

        private decimal SumFPlanAmountPaid(RealEstateFPaymentPlanModel Paymentmade)
        {
            var result = Paymentmade.RealEstatePmtTransaction.Where(x => x.Active == 1).Sum(y => y.Amount);
            return result;
        }
        private void txtAnnualBenefit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Functions.onleyDecimal(sender, e);

        }



        private void txtBenefitAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string Propert = MultyCSelectProperty.Text;
                if (_RealEstateRegistry == null)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you Want Create New Registry", "New Registry", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Btnnew.PerformClick();
                        return;
                    }
                    else
                    {
                        return;
                    }

                }

                if (txtFirstName.Text.Trim().Length == 0 || txtLastName.Text.Trim().Length == 0 || txtDocumentID.Text.Trim().Length == 0)
                {
                    MainControls.ChangeColorByTag(this.MainInfo, new int[] { 255, 255, 192 }, 2);
                    txtContractRef.BackColor = Color.White;
                    MessageBox.Show("Missing Fields");
                    pvInfo.SelectedPage = pvInfo.Pages["PgPersonalInfo"];
                    return;
                }

                if (Mode != 1)
                {

                    _RealEstateRegistry.Active = 1;
                    _RealEstateRegistry.CreationDate = DateTime.Today;
                    _RealEstateRegistry.Reference = txtContractRef.Text;
                    _RealEstateRegistry.RealEstateRegOwneInfo.FirstName = txtFirstName.Text;
                    _RealEstateRegistry.RealEstateRegOwneInfo.LastName = txtLastName.Text;
                    _RealEstateRegistry.RealEstateRegOwneInfo.DocumentID = txtDocumentID.Text;
                    _RealEstateRegistry.RealEstateRegOwneInfo.Address = txtPersonalAddress.Text;

                    _Owner = new Owner();
                    _Owner.InsertOrUpdate1(_RealEstateRegistry);

                    MessageBox.Show("Done!");
                    Mode = 3;
                    MessageModestate();
                }
                TempIdDto = 1; // reiniciar el contador temporal a 1 para los payments de futures 'F4'

                OwnerRegistryInfo(_RealEstateRegistry, _RealEstateRegistry.RealEstateAnualBenefit.First(x => x.RealEstateProperty.Description == Propert).RealEstateAnualBenefitID, true);
                ChargeDtoAnualbenifitData();
                ResultValanceDeu();
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
            }


        }

        private void txtDocumentID_TextChanged(object sender, EventArgs e)
        {

        }
        //***************************EVENTO ADD CONTACT TO CONTRACT *********************************
        private void btnContactAdd_Click(object sender, EventArgs e)
        {
            if (txtContatDescript.Text.Trim() == string.Empty)
            {
                txtContatDescript.Focus();
                txtContatDescript.BackColor = Color.FromArgb(255, 255, 192);
                return;
            }


            RealEstateContactInfoModel RealEstateContactInfo = new RealEstateContactInfoModel
            {
                Description = txtContatDescript.Text,
                Extension = txtExt.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(txtExt.Text),
                RealEstateContactTypeID = lstRealEstateContactType.Where(x => x.RealEstateContactTypeID == Convert.ToInt32(cbContactType.SelectedValue)).Select(x => x.RealEstateContactTypeID).FirstOrDefault(),
                Status = 1
            };
            _RealEstateRegistry.RealEstateContactInfo.Add(RealEstateContactInfo);
            lstContactInfoDto.Add(new ContactInfoDto
            {

                Description = RealEstateContactInfo.Description,
                Extension = RealEstateContactInfo.Extension,
                Type = cbContactType.Text,
                RealEstateContactInfoID = RealEstateContactInfo.RealEstateContactInfoID,
                RealEstateContactTypeID = RealEstateContactInfo.RealEstateContactTypeID

            });

            gvContactInfo.DataSource = null;
            gvContactInfo.DataSource = lstContactInfoDto;
        }

        //PESTAñA DE BANK TRANSFERENCE

        private void btnTranferAdd_Click(object sender, EventArgs e)
        {


        }
        void LimpiarTranferenceText()
        {
            foreach (var item in PanelWt.Controls)
            {
                if (item is RadTextBox)
                {
                    ((Control)item).Text = string.Empty;
                }
            }
        }
        void UpdateTranferenceGrid()
        {
            gvTranferSetup.DataSource = null;
            gvTranferSetup.DataSource = _RealEstateRegistry.RealEstateBanksTransference;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchByText();
        }
        void SearchByText()
        {

            _OwnerInfoDto = new OwnerInfoDto();
            _OwnerInfoDto.Name = txtFirstName.Text;
            _OwnerInfoDto.lastName = txtLastName.Text;
            _OwnerInfoDto.DocumentID = txtDocumentID.Text;
            _OwnerInfoDto.ContractReference = txtContractRef.Text;

            SearchRealEstate SearchinForm = new SearchRealEstate(_OwnerInfoDto);
            AddOwnedForm(SearchinForm);
            SearchinForm.ShowDialog();


        }
        ///****************************** RECIVIR INFORMACION DE BUSQUEDA
        public void OwnerRegistryInfo(RealEstateRegistryModel RealEstateRegistry, Int64 AnualBenID, bool ComingFromSave = false)
        {


            lstBankTranferenceDto = null;
            _RealEstateRegistry = null;

            Mode = 3;
            SetGridsAndTexboxToDefault();
            _RealEstateRegistry = RealEstateRegistry;
            //*****************************************************ASIGNACION DE ID TEMPORAL PARA OUNER BENEFIT************************************************
            _RealEstateRegistry.RealEstateAnualBenefit.ToList().ForEach(
                x =>
                    {
                        _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(y => y.RealEstateAnualBenefitID == x.RealEstateAnualBenefitID).TMPRealEstateAnualBenefitID = anualbenefitTempID++;
                    }
                );
            //*****************************************************************************************************
            DataOwner();
            MessageModestate();
            if (!ComingFromSave)
            {
                EditOwnerBenefit(AnualBenID);

            }

            lblOwnerName.Text = RealEstateRegistry.RealEstateRegOwneInfo.FirstName + " " + RealEstateRegistry.RealEstateRegOwneInfo.LastName;

            cbWtranfer.DisplayMember = "Description";
            cbWtranfer.ValueMember = "RealEstateBanksTransferenceID";
            cbWtranfer.DataSource = RealEstateRegistry.RealEstateBanksTransference;


            cbTranferPmt.DisplayMember = "Description";
            cbTranferPmt.ValueMember = "RealEstateBanksTransferenceID";
            cbTranferPmt.DataSource = RealEstateRegistry.RealEstateBanksTransference;
            PaymentsArea();
            LoadFuturePaymentInfo();

            cbTranferPmt.DisplayMember = "AccountName";
            cbTranferPmt.ValueMember = "AccountNumber";
            cbTranferPmt.DataSource = _RealEstateRegistry.RealEstateBanksTransference.Where(x => x.Active == 1);

        }



        #region DefaultValuesFunctions
        public void ClearallGrid()
        {
            gvAnualBenefits.DataSource = null;
            gvContactInfo.DataSource = null;
            gvTranferSetup.DataSource = null;
            gvPropertyHistory.DataSource = null;
            gvFuturePayment.DataSource = null;
            gvPaymentApplyed.DataSource = null;

        }
        void SetGridsAndTexboxToDefault()
        {
            MainControls.ClearTextBox(this);
            txtPersonalAddress.Text = string.Empty;
            cbFoundInfo.DataSource = null;
            cbFoundInfo.Text = "";

            if (!(Mode == 3))
            {
                ClearallGrid();

                //cbPaymentProperty.DataSource = null;
                MultyCSelectProperty.DataSource = null;
            }
            if (Mode == 2)
            {
                if (lstAnualBPropertiesDto == null)
                {
                    lstAnualBPropertiesDto = null;
                }

                lstAnualBPropertiesDto = new List<AnualBPropertiesDto>();
            }

        }

        void MessageModestate()
        {
            if (Mode == 0)
            {
                lblMessage.Visible = false;
            }
            else if (Mode == 1)
            {
                lblMessage.Text = "Searching...";
                lblMessage.Visible = true;
            }
            else if (Mode == 2)
            {
                lblMessage.Text = "Creating...";
                lblMessage.Visible = true;
            }
            else if (Mode == 3)
            {
                lblMessage.Text = "Editing...";
                lblMessage.Visible = true;
            }
        }

        #endregion




        void DataOwner()
        {
            try
            {
                if (_RealEstateRegistry.RealEstateRegOwneInfo != null)
                {

                    txtContractRef.Text = _RealEstateRegistry.Reference;
                    txtFirstName.Text = _RealEstateRegistry.RealEstateRegOwneInfo.FirstName;
                    txtLastName.Text = _RealEstateRegistry.RealEstateRegOwneInfo.LastName;
                    txtDocumentID.Text = _RealEstateRegistry.RealEstateRegOwneInfo.DocumentID;
                    txtPersonalAddress.Text = _RealEstateRegistry.RealEstateRegOwneInfo.Address;

                }
                else
                {
                    _RealEstateRegistry.RealEstateRegOwneInfo = new RealEstateRegOwneInfoModel();
                }

                if (_RealEstateRegistry.RealEstateContactInfo != null)
                {
                    lstContactInfoDto = _RealEstateRegistry.RealEstateContactInfo.Select(x => new ContactInfoDto
                    {
                        Description = x.Description,
                        Extension = x.Extension,
                        Type = x.RealEstateContactType.Description,
                        RealEstateContactInfoID = x.RealEstateContactInfoID,
                        RealEstateContactTypeID = x.RealEstateContactTypeID,
                        //RealEstateRegistryID = x.RealEstateRegistryID
                    }).ToList();
                    gvContactInfo.DataSource = lstContactInfoDto;

                }
                else
                {
                    _RealEstateRegistry.RealEstateContactInfo = new List<RealEstateContactInfoModel>();
                }

                if (_RealEstateRegistry.RealEstateAnualBenefit != null)
                {
                    ChargeDtoAnualbenifitData();

                }
                else
                {
                    _RealEstateRegistry.RealEstateAnualBenefit = new List<RealEstateAnualBenefitModel>();
                }

                if (_RealEstateRegistry.RealEstateBanksTransference != null)
                {
                    if (lstBankTranferenceDto == null)
                    {
                        lstBankTranferenceDto = new List<BankTranferenceDto>();
                    }
                    _RealEstateRegistry.RealEstateBanksTransference.ToList()
                        .ForEach(x => lstBankTranferenceDto.Add(new BankTranferenceDto
                        {
                            RealEstateBanksTransferenceID = x.RealEstateBanksTransferenceID,
                            AccountName = x.AccountName,
                            AccountNumber = x.AccountNumber,
                            BeneficiaryAddress = x.BeneficiaryAddress,
                            IntermediaryBank = x.IntermediaryBank,
                            BankName = x.BankName,
                            BankAddress = x.BankAddress,
                            RoutingCode = x.RoutingCode,
                            SwiftCode = x.SwiftCode,
                            Active = x.Active
                        }));

                    gvTranferSetup.DataSource = lstBankTranferenceDto.Where(x => x.Active == 1).ToList();
                }
                else
                {
                    _RealEstateRegistry.RealEstateBanksTransference = new List<RealEstateBankTranferenceModel>();

                }


                AnualbenifitData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        //METODO PARA CARGAR LOS DATOS DE LA LISTA DE BENEFICIOS DE PROPIEDADES (lstAnualBPropertiesDto)
        private void ChargeDtoAnualbenifitData()
        {
            lstAnualBPropertiesDto = new List<AnualBPropertiesDto>();
            int i = 1;
            lstAnualBPropertiesDto =
            _RealEstateRegistry.RealEstateAnualBenefit.Select(x => new AnualBPropertiesDto
            {
                TempAnualproID = i++,
                RealEstateAnualBenefitID = x.RealEstateAnualBenefitID,
                AnnualBenefit = x.AnnualBenefit,
                Amount = x.Amount,
                FrecuencyPayment = x.RealEstatePaymentFrecuency.description,
                PaymentMethodID = x.PaymentMethodID,
                PaymentMethod = PaymentMethodFrequency.PaymentMethod.First(r => r.PaymentMethodID == x.PaymentMethodID).Description,
                CreationDate = x.CreationDate,
                RealEstateProperty = x.RealEstateProperty.Description,
                ContractDate = x.ContractDate,
                EfectiveDate = x.EfectiveDate,
                RealEstatePropertyID = x.RealEstatePropertyID,
                Active = x.Active,
                CreatedBY = lstUsers.FirstOrDefault(u => u.Id == x.UserId) == null ? "" : lstUsers.First(u => u.Id == x.UserId).FirstName,
                CreationUserID = x.UserId,
                Status = x.Status,
                Secuence = x.Sequence,
                ModifiedUserID = x.ModifiedUserID,
                PrevieusAnualBenefitdID = x.PrevieusAnualBenefitdID,
                UpdatedBy = x.ModifiedUserName,
                hold = x.RealEstateHoldInstallment == null ? 0 : Convert.ToInt32(x.RealEstateHoldInstallment.Any(y => y.Active == 1 && (DateTime.Today >= y.StartingDate && DateTime.Today <= y.FinalDate)))
            }).ToList();
        }


        private void RealEstateRegistry_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.F)
            {
                MainControls.ChangeTextBoxColorByTag(this, new int[] { 255, 255, 192 }, 2);
                Mode = 1;
                SetGridsAndTexboxToDefault();
                MessageModestate();

                pvInfo.SelectedPage = pvInfo.Pages["PgPersonalInfo"];
                txtContractRef.Focus();
            }
            if (e.KeyCode == Keys.Enter && Mode == 1)
            {

                if (txtContractRef.ContainsFocus)
                {

                    SearchByText();
                }
                else
                {
                    this.SelectNextControl(ActiveControl, true, true, true, true);
                }

            }
            if (e.Control && e.KeyCode == Keys.N)
            {

                Btnnew.PerformClick();
            }
            if (_RealEstateRegistry != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        pvInfo.SelectedPage = pvInfo.Pages["PgPersonalInfo"];
                        break;
                    case Keys.F2:
                        pvInfo.SelectedPage = pvInfo.Pages["PgOwnerBenefits"];
                        break;
                    case Keys.F3:
                        pvInfo.SelectedPage = pvInfo.Pages["PgTransferSetup"];
                        break;
                    case Keys.F4:
                        pvInfo.SelectedPage = pvInfo.Pages["PgPaymentStatus"];
                        break;
                    case Keys.F5:
                        pvInfo.SelectedPage = pvInfo.Pages["PgPropertyAdministration"];
                        break;

                }
            }


        }


        private void txtContractRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (Mode == 2)
            {
                if (e.KeyCode == Keys.Enter)
                {

                    txtFirstName.Text = string.Empty;
                    txtLastName.Text = string.Empty;
                    txtDocumentID.Text = string.Empty;
                    txtPersonalAddress.Text = string.Empty;

                    InfoBackNext = 0;
                    if (_Owner == null)
                    {
                        _Owner = new Owner();
                    }
                    Sqlcommandexecuter sql = new Sqlcommandexecuter();
                    _realEstateRegOwneInfo = new List<RealEstateRegOwneInfoModel>();

                    _realEstateRegOwneInfo = sql.SQLdata($"SP_RealEstatePersonalInfo '{txtContractRef.Text}'").AsEnumerable()
                                            .Select(x => new RealEstateRegOwneInfoModel
                                            {
                                                FirstName = x.Field<string>("FirstName"),
                                                LastName = x.Field<string>("LastName"),
                                                DocumentID = x.Field<string>("DocumentID"),
                                                Address = x.Field<string>("Address"),


                                            }).ToList();

                    cbFoundInfo.DataSource = _realEstateRegOwneInfo.ToList();
                    GetOwnerMainInfo();


                }
            }
        }
        private void GetOwnerMainInfo(int index = 0)
        {
            if (cbFoundInfo.MultiColumnComboBoxElement.Rows.Count > 0)
            {
                cbFoundInfo.SelectedIndex = index;
                txtFirstName.Text = cbFoundInfo.MultiColumnComboBoxElement.Rows[index].Cells["FirstName"].Value.ToString();
                txtLastName.Text = cbFoundInfo.MultiColumnComboBoxElement.Rows[index].Cells["LastName"].Value.ToString();
                txtDocumentID.Text = cbFoundInfo.MultiColumnComboBoxElement.Rows[index].Cells["DocumentID"].Value.ToString();
                txtPersonalAddress.Text = cbFoundInfo.MultiColumnComboBoxElement.Rows[index].Cells["Address"].Value.ToString();

            }

        }

        void CreatenewOwner()//******************************************************REAL ESTATE INITIALIZATION************************************************
        {
            _RealEstateRegistry = new RealEstateRegistryModel();
            lstRealEstateProperty = new List<RealEstatePropertyModel>();
            lstContactInfoDto = new List<ContactInfoDto>();
        }
        private void Btnnew_Click(object sender, EventArgs e)
        {
            txtContractRef.Focus();
            _RealEstateRegistry = null;
            lblOwnerName.Text = "----------";
            //cbPaymentMethod.Enabled = true;
            //dtpContractDate.Enabled = true;
            //cbPaymentFrequency.Enabled = true;
            //SwithcHold.Enabled = true;
            //btnSaveBenefit.Enabled = true;
            Mode = 2;
            pvInfo.SelectedPage = pvInfo.Pages[0];
            SetGridsAndTexboxToDefault();
            CreatenewOwner();
            MessageModestate();
            LoadMainInfo();
            HabilitaDesPageView();
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {

        }

        private void txtAnnualBenefit_Leave(object sender, EventArgs e)
        {
            decimal transactionTotsl = 0;
            foreach (var AnualBen in _RealEstateRegistry.RealEstateAnualBenefit.Where(x => x.RealEstatePropertyID == _SelectedOwAnBenId && x.Active == 1))
            {
                AnualBen.RealEstateTransaction.Where(t => t.Active == 1 && t.RealEstateTransactionTypeID != 3 && t.RealEstateTransactionTypeID != 7 && t.ApplicationDate.Year == DateTime.Today.Year)
                                                .ToList().ForEach(x => transactionTotsl += x.Amount);
            }
            if (transactionTotsl > Convert.ToDecimal(txtAnnualBenefit.Text.Trim().Replace("$", "")))
            {
                MessageBox.Show("This amount exceeds the number of transactions processed in the contract");
                return;
            }
            AnnualBenefit();
        }

        private void btnRemoveProperty_Click(object sender, EventArgs e)
        {

            if (gvAnualBenefits.RowCount == 0)
            {
                return;
            }


            if (Convert.ToInt32(gvAnualBenefits.CurrentRow.Cells["RealEstateAnualBenefitID"].Value) != 0)
            {

                if (!AuthoritationKey())
                {
                    return;
                }

                RealEstateAnualBenefitModel Modifi = _RealEstateRegistry.RealEstateAnualBenefit
                .Where(x => x.RealEstatePropertyID == Convert.ToInt64(gvAnualBenefits.CurrentRow.Cells["RealEstatePropertyID"].Value))
                .FirstOrDefault();

                _RealEstateRegistry.RealEstateAnualBenefit.Remove(Modifi);
                Modifi.Active = 0;
                _RealEstateRegistry.RealEstateAnualBenefit.Add(Modifi);
            }
            else
            {
                _RealEstateRegistry.RealEstateAnualBenefit
                .Remove(_RealEstateRegistry.RealEstateAnualBenefit
                .First(x => x.RealEstatePropertyID == Convert.ToInt64(gvAnualBenefits.CurrentRow.Cells["RealEstatePropertyID"].Value) && x.RealEstateAnualBenefitID == 0));
            }

            AnualBPropertiesDto propertyRemoveDto = lstAnualBPropertiesDto.Find(x => x.RealEstatePropertyID == Convert.ToInt64(gvAnualBenefits.CurrentRow.Cells["RealEstatePropertyID"].Value));
            lstAnualBPropertiesDto.Remove(propertyRemoveDto);

            AnualbenifitData();

        }

        private bool AuthoritationKey()
        {
            FrmAuthorizationkey autority = new FrmAuthorizationkey();
            if (autority.ShowDialog() == DialogResult.OK)
            {
                if (autority.UserAuthorization == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                return false;
            }
        }
        private void txtAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Onlydecimal.OnlyDecimaltxt(sender, e);
        }

        private void btnTranferRemove_Click(object sender, EventArgs e)
        {
            if (!AuthoritationKey())
            {
                return;
            }

            if (gvTranferSetup.RowCount == 0)
            {
                return;
            }
            if (Convert.ToInt32(gvTranferSetup.CurrentRow.Cells["RealEstateBanksTransferenceID"].Value) != 0)
            {
                RealEstateBankTranferenceModel Transference = _RealEstateRegistry.RealEstateBanksTransference
               .Where(x => x.RealEstateBanksTransferenceID == Convert.ToInt64(gvTranferSetup.CurrentRow.Cells["RealEstateBanksTransferenceID"].Value))
               .FirstOrDefault();

                _RealEstateRegistry.RealEstateBanksTransference.Remove(Transference);
                Transference.Active = 0;
                _RealEstateRegistry.RealEstateBanksTransference.Add(Transference);

            }
            else
            {
                RealEstateBankTranferenceModel Transference = _RealEstateRegistry.RealEstateBanksTransference
              .Where(x => x.notSaveSecuence == Convert.ToInt64(gvTranferSetup.CurrentRow.Cells["notSaveSecuence"].Value))
              .FirstOrDefault();

                _RealEstateRegistry.RealEstateBanksTransference.Remove(Transference);

            }

            //lstBankTranferenceDto.RemoveAt(gvTranferSetup.CurrentRow.Index);

            UpdateTranferenceGrid();
            LimpiarTranferenceText();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Mode = 0;
            LoadMainInfo();
            SetGridsAndTexboxToDefault();

            MessageModestate();
            btnBackInfo.Visible = false;
            btnNextInfo.Visible = false;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (_Owner == null)
            {
                _Owner = new Owner();
            }
            if (true/*_Owner.HasUnsavedChange(_RealEstateRegistry)*/)
            {
                if (_RealEstateRegistry != null)
                {
                    if (CloseProgram())
                    {
                        if (MensageYesNo("Do you want to make them?", "Apply change") == DialogResult.Yes)
                        {
                            Btnsave.PerformClick();
                        }
                    }


                }
                //MensageYesNo("Do you want to make them?", "There is change to apply");

            }
            this.Close();

        }
        bool CloseProgram()
        {
            bool result = true;

            foreach (var control in MainInfo.Controls)
            {
                if (control is RadTextBox)
                {
                    if (((Control)control).Tag.ToString() == "2")
                    {
                        if (((Control)control).Text.Trim() == string.Empty)
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }

                }
            }
            if (gvAnualBenefits.RowCount > 0)
            {
                result = false;
            }
            return result;
        }

        private void btnNextInfo_Click(object sender, EventArgs e)
        {
            if (InfoBackNext < _realEstateRegOwneInfo.Count - 1)
            {
                InfoBackNext++;
            }
            GetOwnerMainInfo(InfoBackNext);
        }

        private void btnBackInfo_Click(object sender, EventArgs e)
        {
            if (InfoBackNext > 0)
            {
                InfoBackNext--;
            }
            GetOwnerMainInfo(InfoBackNext);
        }

        private void cbFoundInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOwnerMainInfo(cbFoundInfo.SelectedIndex);
        }

        private void txtContatDescript_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (cbContactType.Text.Trim() != "Email")
            //{
            //    if (e.KeyChar.ToString().Trim() == "-")
            //    {

            //    }
            //    else 
            //    {
            //        Onlydecimal.OnlyDecimaltxt(sender, e);
            //    }

            //}
        }

        private void txtContatDescript_KeyDown(object sender, KeyEventArgs e)
        {
            //if (cbContactType.Text.Trim() != "Email")
            //{
            //    if (e.KeyCode.ToString() == "-")
            //    {

            //    }
            //    Onlydecimal.OnlyDecimaltxt(sender, e);
            //}
        }

        private void txtExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Onlydecimal.OnlyDecimaltxt(sender, e);
        }


        #region Funciones

        void HabilitaDesPageView()
        {

            pvInfo.Pages[0].Enabled = _RealEstateRegistry != null;
            pvInfo.Pages[1].Enabled = _RealEstateRegistry != null;
            pvInfo.Pages[2].Enabled = _RealEstateRegistry != null;
            pvInfo.Pages[3].Enabled = _RealEstateRegistry != null;

        }


        void AnnualBenefit()
        {
            if (txtAnnualBenefit.Text.Length > 0)
            {
                if (txtAnnualBenefit.Text.Trim().Length > 0)
                {
                    if (cbPaymentFrequency.SelectedValue != null)
                    {
                        txtBenefitAmount.Text = (Convert.ToDecimal(txtAnnualBenefit.Text.Replace("$", "")) / Convert.ToDecimal(PaymentMethodFrequency.RealEstatePaymentFrecuency.Where(x => x.RealEstatePaymentFrecuencyID == Convert.ToInt64(cbPaymentFrequency.SelectedValue)).FirstOrDefault().FrecuenceValue.ToString())).ToString("C2");
                    }
                }
            }
        }

        #endregion
        void SpecialPermitValidations()
        {
            //groupbox de agregar contactos
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 473 && x.Field<int>("Value") == 1).Count() > 0)
            {
                GrbContactInfo.Enabled = true;
            }
            //add property
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 474 && x.Field<int>("Value") == 1).Count() > 0)
            {
                btnAddContractProperty.Visible = true;
            }

            //remove properties
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 475 && x.Field<int>("Value") == 1).Count() > 0)
            {
                btnRemoveProperty.Visible = true;
            }

            //panel payment
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 479 && x.Field<int>("Value") == 1).Count() > 0)
            {
                PanelWt.Enabled = true;
            }
            //boton guardar
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 476 && x.Field<int>("Value") == 1).Count() > 0)
            {
                Btnsave.Enabled = true;
            }
            //boton de crear nuevo
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 477 && x.Field<int>("Value") == 1).Count() > 0)
            {
                Btnnew.Enabled = true;
            }
            //boton de eliminar
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 478 && x.Field<int>("Value") == 1).Count() > 0)
            {
                Btndelete.Enabled = true;
            }
        }

        private void cbPaymentFrequency_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            AnnualBenefit();
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

        private void pAddWTranfer_Click(object sender, EventArgs e)
        {
            PaymentWtInfo wt = new PaymentWtInfo();
            AddOwnedForm(wt);
            wt.Show();
        }

        void LoadAllUsers()
        {
            _Owner = new Owner();
            lstUsers = _Owner.GetAllUsers();
        }

        private void gvAnualBenefits_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {

            EditOwnerBenefit(Convert.ToInt64(gvAnualBenefits.CurrentRow.Cells["RealEstateAnualBenefitID"].Value));
        }

        void ActiveAnualbenenefitField(bool activate)
        {
            btnSaveBenefit.Enabled = activate;
            btnRemoveProperty.Enabled = activate;
            SwithcHold.Enabled = activate;
            txtAnnualBenefit.Enabled = activate;
            cbPaymentFrequency.Enabled = activate;
            cbPaymentMethod.Enabled = activate;
        }
        void EditOwnerBenefit(Int64 OwAnBenId)
        {
            if (OwAnBenId == 0)
            {
                return;
            }
            if (_RealEstateRegistry.RealEstateAnualBenefit.Where(x => x.RealEstateAnualBenefitID == OwAnBenId).FirstOrDefault().Status != -1)
            {
                ActiveAnualbenenefitField(true);
            }
            else
            {
                ActiveAnualbenenefitField(false);
            }

            _SelectedOwAnBenId = OwAnBenId;

            RealEstateAnualBenefitModel owBen = _RealEstateRegistry.RealEstateAnualBenefit.Where(x => x.RealEstateAnualBenefitID == OwAnBenId).FirstOrDefault();
            if (owBen.Status != null)
            {
                txtProperty.Text = owBen.RealEstateProperty.Description;
                cbPaymentFrequency.SelectedValue = owBen.RealEstatePaymentFrecuencyID;
                txtAnnualBenefit.Text = owBen.AnnualBenefit.ToString("C2");
                txtBenefitAmount.Text = owBen.Amount.ToString("C2");
                cbPaymentMethod.SelectedValue = owBen.PaymentMethodID;
                dtpContractDate.Value = owBen.ContractDate;
                //SwithcHold.Value =  owBen.RealEstateHoldInstallment.Any(y => y.Active == 1 && (y.StartingDate >= DateTime.Today && DateTime.Today <= y.FinalDate));
                _RealEstatePropertyID = owBen.RealEstatePropertyID;

                RealEstateHoldInstallment HoldState = new RealEstateHoldInstallment();
                HoldState = owBen.RealEstateHoldInstallment.FirstOrDefault(y => y.Active == 1 && (DateTime.Today >= y.StartingDate && DateTime.Today <= y.FinalDate));

                if (HoldState != null)
                {
                    dtpStartDateHold.Text = HoldState.StartingDate.ToShortDateString();
                    dtpAndDateHold.Text = HoldState.FinalDate.ToShortDateString();
                    SwithcHold.Value = true;

                }
                else
                {
                    dtpStartDateHold.Text = string.Empty;
                    dtpAndDateHold.Text = string.Empty;
                    SwithcHold.Value = false;
                }


                //lblPropertyDesc.Text = owBen.RealEstateProperty.Description;
            }

        }

        private void cbPaymentMethod_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //if (Convert.ToInt32(cbPaymentMethod.SelectedValue) == 1)
            //{
            //    //cbWtranfer.Enabled = true;
            //}
            //else
            //{
            //    //cbWtranfer.Enabled = false;
            //}

        }
        DialogResult MensageYesNo(string msg, string titulo)
        {
            return MessageBox.Show(msg, titulo, MessageBoxButtons.YesNo);
        }
        private void btnSaveBenefit_Click(object sender, EventArgs e)
        {
            MainControls.ChangeColorByTag(this, new int[] { 255, 255, 192 }, 2);


            if (SwithcHold.Value)
            {
                if (dtpStartDateHold.Value < DateTime.Today && dtpStartDateHold.Value < dtpAndDateHold.Value)
                {
                    MessageBox.Show("End date must be greater than start date");
                    return;
                }
                if (dtpStartDateHold.Value >= dtpAndDateHold.Value)
                {
                    MessageBox.Show("Date Out of Range");
                    return;
                }
            }
            if (Convert.ToDecimal(txtAnnualBenefit.Text.Trim() == "" ? "0.00" : txtAnnualBenefit.Text.Replace("$", "")) <= 0)
            {
                return;
            }

            DialogResult msg = MensageYesNo("You are about to update information ", "ARE YOU SURE?");


            if (Convert.ToInt64(cbPaymentMethod.SelectedValue) == 1)
            {
                if (!_RealEstateRegistry.RealEstateBanksTransference.Any())
                {
                    //MessageBox.Show("There is no bank transfer information");
                    DialogResult msg2 = MensageYesNo("There is no transfer information, you want to create it?", "Add transfer information?");
                    if (msg2 == DialogResult.Yes)
                    {
                        pvInfo.SelectedPage = pvInfo.Pages[2];
                    }
                    else
                    {
                        return;
                    }
                    return;
                }

            }
            if (msg == DialogResult.No)
            {
                return;
            }



            RealEstateAnualBenefitModel Modified = _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateAnualBenefitID == _SelectedOwAnBenId);
            RealEstateAnualBenefitModel RemoveTempAnualBenefit = Modified;
            RealEstateHoldInstallment holdInstallmentMod;
            if (Modified.RealEstateHoldInstallment != null && Modified.RealEstateHoldInstallment.Any(x => x.Active == 1))
            {
                holdInstallmentMod = Modified.RealEstateHoldInstallment.Where(x => x.RealEstateAnualBenefitID == _SelectedOwAnBenId && (x.StartingDate >= DateTime.Today && DateTime.Today <= x.FinalDate) && x.Active == 1).FirstOrDefault();

            }
            else
            {
                holdInstallmentMod = new RealEstateHoldInstallment();
            }

            RealEstateAnualBenefitModel UpgradeBenefit = new RealEstateAnualBenefitModel();

            bool Holdinstallment = InstallmentIsHold(holdInstallmentMod);

            if (SwithcHold.Value != Holdinstallment)
            {
                if (Holdinstallment == false)
                {
                    if (SwithcHold.Value)
                    {
                        holdInstallmentMod = new RealEstateHoldInstallment()
                        {
                            StartingDate = dtpStartDateHold.Value,
                            FinalDate = dtpAndDateHold.Value,
                            Active = 1,
                            CreationDate = DateTime.Today,
                            RealEstateAnualBenefitID = Modified.RealEstateAnualBenefitID,
                            UserID = Globalvariables.guserid

                        };

                    }

                }
                else
                {
                    Modified.RealEstateHoldInstallment.Remove(holdInstallmentMod); //elimina el registro holdInd para modificar su estado de activo a 0 y lo agregamos nuevamente
                    holdInstallmentMod.DeactiveUserID = Globalvariables.guserid;
                    holdInstallmentMod.Active = Convert.ToInt32(!Holdinstallment); // Cambia el stus del hold estado
                }

                Modified.RealEstateHoldInstallment.Add(holdInstallmentMod);//agregamos estado del benefit actualizado              
            }
            else
            {
                if (Holdinstallment == true)
                {
                    //HOLDE QUE SE VA A DESCTIVAR POR CAMBIOS EN LA FECHA DEL HOLD
                    Modified.RealEstateHoldInstallment.Remove(holdInstallmentMod);
                    holdInstallmentMod.Active = 0;
                    holdInstallmentMod.DeactiveUserID = Globalvariables.guserid;
                    Modified.RealEstateHoldInstallment.Add(holdInstallmentMod);
                    //NUEVO REGISTRO DEL HOLD ACTIVO
                    RealEstateHoldInstallment NewHold = new RealEstateHoldInstallment
                    {
                        Active = 1,
                        StartingDate = dtpStartDateHold.Value,
                        FinalDate = dtpAndDateHold.Value,
                        CreationDate = DateTime.Today,
                        UserID = Globalvariables.guserid,
                        RealEstateAnualBenefitID = Modified.RealEstateAnualBenefitID
                    };


                    Modified.RealEstateHoldInstallment.Add(NewHold);
                }
            }


            if (Modified.AnnualBenefit != Convert.ToDecimal(txtAnnualBenefit.Text.Replace("$", ""))//NOTA: SI UNA DE ESTAS CONDICIONES SE CREA OTRO BENEFIT NUEVO
             || Modified.Amount != Convert.ToDecimal(txtBenefitAmount.Text.Replace("$", ""))
             || Modified.RealEstatePaymentFrecuencyID != Convert.ToInt64(cbPaymentFrequency.SelectedValue)
             || Modified.ContractDate != dtpContractDate.Value)
            {
                _RealEstateRegistry.RealEstateAnualBenefit.Remove(Modified);

                Modified.ModifiedUserName = Globalvariables.Userfullname;
                Modified.ModifiedUserID = Globalvariables.guserid;
                Modified.Status = -1;
                Modified.Sequence = 0;
                Modified.EfectiveDate = DateTime.Today;
                if (holdInstallmentMod != null)
                {
                    holdInstallmentMod.Active = 0; // estado desactivado
                                                   //SwithcHold.Value = false; // desactivo el Control Hold
                    Modified.RealEstateHoldInstallment.Add(holdInstallmentMod);
                }



                RealEstateHoldInstallment holdInstallmentMod2;
                if (Holdinstallment)
                {
                    holdInstallmentMod2 = new RealEstateHoldInstallment()
                    {
                        StartingDate = dtpStartDateHold.Value,
                        FinalDate = dtpAndDateHold.Value,
                        Active = 1,
                        CreationDate = DateTime.Today,
                        UserID = Globalvariables.guserid
                    };

                }
                else
                {
                    holdInstallmentMod2 = null;
                }

                _RealEstateRegistry.RealEstateAnualBenefit.Add(Modified);// insertamos el registro actualizado

                UpgradeBenefit.Active = 1;
                UpgradeBenefit.Amount = Convert.ToDecimal(txtBenefitAmount.Text.Replace("$", ""));
                UpgradeBenefit.AnnualBenefit = Convert.ToDecimal(txtAnnualBenefit.Text.Replace("$", ""));
                UpgradeBenefit.ContractDate = dtpContractDate.Value;
                UpgradeBenefit.CreationDate = DateTime.Today;
                UpgradeBenefit.EfectiveDate = new DateTime(4000, 01, 01);
                UpgradeBenefit.PaymentMethodID = Convert.ToInt64(cbPaymentMethod.SelectedValue);
                UpgradeBenefit.PrevieusAnualBenefitdID = Modified.RealEstateAnualBenefitID;
                UpgradeBenefit.RealEstatePaymentFrecuencyID = Convert.ToInt64(cbPaymentFrequency.SelectedValue);
                UpgradeBenefit.RealEstateProperty = Modified.RealEstateProperty;
                UpgradeBenefit.RealEstatePropertyID = Modified.RealEstatePropertyID;
                UpgradeBenefit.RealEstateRegistryID = Modified.RealEstateRegistryID;
                UpgradeBenefit.UserId = Globalvariables.guserid;
                UpgradeBenefit.Sequence = Modified.Sequence + 1;
                UpgradeBenefit.RealEstatePaymentFrecuency = PaymentMethodFrequency.RealEstatePaymentFrecuency.First(r => r.RealEstatePaymentFrecuencyID == Convert.ToInt64(cbPaymentFrequency.SelectedValue));
                UpgradeBenefit.User = Modified.User;
                UpgradeBenefit.ModifiedUserName = "";
                if (Holdinstallment)
                {
                    if (UpgradeBenefit.RealEstateHoldInstallment == null)
                    {
                        UpgradeBenefit.RealEstateHoldInstallment = new List<RealEstateHoldInstallment>();
                    }

                    UpgradeBenefit.RealEstateHoldInstallment.Add(holdInstallmentMod2);
                }

                _RealEstateRegistry.RealEstateAnualBenefit.Add(UpgradeBenefit);
            }
            else
            {
                _RealEstateRegistry.RealEstateAnualBenefit.Remove(RemoveTempAnualBenefit);
                _RealEstateRegistry.RealEstateAnualBenefit.Add(Modified);

            }

            lstAnualBPropertiesDto = null;
            ChargeDtoAnualbenifitData();
            AnualbenifitData();

            txtProperty.Text = string.Empty;

            txtAnnualBenefit.Text = string.Empty;
            txtBenefitAmount.Text = string.Empty;
            cbPaymentMethod.SelectedIndex = -1;
            cbWtranfer.SelectedIndex = -1;
            dtpContractDate.Text = string.Empty;
            SwithcHold.Value = false;
            cbPaymentFrequency.SelectedIndex = -1;
            dtpStartDateHold.Text = "";
            dtpAndDateHold.Text = "";

        }
        bool InstallmentIsHold(RealEstateHoldInstallment HoldInstallment)
        {
            if (HoldInstallment == null)
            {
                return false;
            }
            if ((HoldInstallment.StartingDate >= DateTime.Today && DateTime.Today <= HoldInstallment.FinalDate) && HoldInstallment.Active == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void gvAnualBenefits_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if ((int)e.RowElement.RowInfo.Cells["Status"].Value < 0)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                e.RowElement.BackColor = Color.LightGray;

            }
            else
            {
                if ((int)e.RowElement.RowInfo.Cells["hold"].Value == 1)
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                    e.RowElement.BackColor = Color.IndianRed;
                }
                else
                {

                    e.RowElement.DrawFill = true;
                    e.RowElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                    e.RowElement.BackColor = Color.LightGreen;

                }

            }
        }

        private void txtProperty_TextChanged(object sender, EventArgs e)
        {
            lblPropertyDesc.Text = txtProperty.Text;
            if (txtProperty.Text.Trim().Length > 0)
            {
                lblPropertyDesc.Visible = true;
                lblEditing.Visible = true;
            }
            else
            {
                lblPropertyDesc.Visible = false;
                lblEditing.Visible = false;
            }

        }

        private void cbContactType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            if (Convert.ToInt32(cbContactType.SelectedValue) != 6)
            {
                txtContatDescript.MaskType = MaskType.Standard;
                txtContatDescript.Mask = "(000) 000-0000";
                txtExt.Visible = true;
            }
            else
            {
                txtContatDescript.MaskType = MaskType.EMail;
                txtExt.Visible = false;
            }
        }

        private void btnSaveWt_Click(object sender, EventArgs e)
        {
            RealEstateBankTranferenceModel realEstateBanksTransference;
            if (MainControls.ChangeColorByTag(this.PanelWt, new int[] { 255, 255, 192 }, 2))
            {
                return;
            }
            if (_SelectedTransference != null)
            {

                realEstateBanksTransference = _RealEstateRegistry.RealEstateBanksTransference.First(x => x.RealEstateBanksTransferenceID == _SelectedTransference.RealEstateBanksTransferenceID);
                _RealEstateRegistry.RealEstateBanksTransference.Remove(realEstateBanksTransference);

                realEstateBanksTransference = new RealEstateBankTranferenceModel
                {
                    RealEstateBanksTransferenceID = _SelectedTransference.RealEstateBanksTransferenceID,
                    RealEstateRegistryID = _SelectedTransference.RealEstateRegistryID,
                    RealEstateRegistry = _SelectedTransference.RealEstateRegistry,
                    Description = txtWTDescription.Text,
                    BeneficiaryAddress = txtBeneficiaryAddress.Text,
                    BankAddress = txtBankAddress.Text,
                    BankName = txtBankName.Text,
                    RoutingCode = txtRoutinCode.Text,
                    SwiftCode = txtSwiftCode.Text,
                    CreationDate = DateTime.Today,
                    AccountName = txtAccountName.Text,
                    AccountNumber = txtAccountNumber.Text.Contains("*")? _SelectedTransference.AccountNumber : _SelectedTransference.AccountNumber.ToString() != txtAccountNumber.Text.Trim()?  Convert.ToInt64(txtAccountNumber.Text.Trim() == "" ? "0" : txtAccountNumber.Text): _SelectedTransference.AccountNumber,
                    IntermediaryBank = txtIntemediaryBank.Text,
                    IBAN = txtIban.Text,
                    Active = 1,
                    notSaveSecuence = _notSaveSecuence++

                };

            }
            else
            {
                realEstateBanksTransference = new RealEstateBankTranferenceModel
                {
                    Description = txtWTDescription.Text,
                    BeneficiaryAddress = txtBeneficiaryAddress.Text,
                    BankAddress = txtBankAddress.Text,
                    BankName = txtBankName.Text,
                    RoutingCode = txtRoutinCode.Text,
                    SwiftCode = txtSwiftCode.Text,
                    CreationDate = DateTime.Today,
                    AccountName = txtAccountName.Text,
                    AccountNumber = Convert.ToInt64(txtAccountNumber.Text == "" ? "0" : txtAccountNumber.Text),
                    IntermediaryBank = txtIntemediaryBank.Text,
                    IBAN = txtIban.Text,
                    Active = 1,
                    notSaveSecuence = _notSaveSecuence++

                };



            }
            if (_RealEstateRegistry == null)
            {
                return;
            }
            _RealEstateRegistry.RealEstateBanksTransference.Add(realEstateBanksTransference);
            UpdateTranferenceGrid();
            LimpiarTranferenceText();
            _SelectedTransference = null;
        }

        private void gvTranferSetup_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {



            if (Convert.ToInt32(gvTranferSetup.CurrentRow.Cells["RealEstateBanksTransferenceID"].Value) != 0)
            {
                _SelectedTransference = _RealEstateRegistry.RealEstateBanksTransference
               .Where(x => x.RealEstateBanksTransferenceID == Convert.ToInt64(gvTranferSetup.CurrentRow.Cells["RealEstateBanksTransferenceID"].Value))
               .FirstOrDefault();


            }
            else
            {
                _SelectedTransference = _RealEstateRegistry.RealEstateBanksTransference
              .Where(x => x.notSaveSecuence == Convert.ToInt64(gvTranferSetup.CurrentRow.Cells["notSaveSecuence"].Value))
              .FirstOrDefault();
            }

            txtWTDescription.Text = _SelectedTransference.Description;
            txtBeneficiaryAddress.Text = _SelectedTransference.BeneficiaryAddress;
            txtBankAddress.Text = _SelectedTransference.BankAddress;
            txtBankName.Text = _SelectedTransference.BankName;
            txtRoutinCode.Text = _SelectedTransference.RoutingCode;
            txtSwiftCode.Text = _SelectedTransference.SwiftCode;
            txtAccountName.Text = _SelectedTransference.AccountName;
            _tempAccountNumber = _SelectedTransference.AccountNumber;
            int startindex = Convert.ToInt32(_SelectedTransference.AccountNumber.ToString().Length - 4);
            txtAccountNumber.Text = "****"+ _SelectedTransference.AccountNumber.ToString().Substring(startindex, 4);
            txtIntemediaryBank.Text = _SelectedTransference.IntermediaryBank;
            txtIban.Text = _SelectedTransference.IBAN;


            //if (lstBankTranferenceDto == null)
            //{
            //    lstBankTranferenceDto = new List<BankTranferenceDto>();
            //}
        }

        private void gvAnualBenefits_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (gvAnualBenefits.RowCount > 0)
            {
                btnRemoveProperty.Enabled = true;
            }
            else
            {
                btnRemoveProperty.Enabled = false;
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {

        }

        private void pvInfo_SelectedPageChanged(object sender, EventArgs e)
        {

        }

        private void cbPaymentProperty_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //TabPaymetnControl.Enabled = cbPaymentProperty is null ? false : true;
            //gvFuturePayment.Enabled = cbPaymentProperty is null ? false : true;

        }


        private void btnGenPmtFuture_Click(object sender, EventArgs e)
        {
            if (MainControls.ChangeColorByTag(TabPaymetnControl.TabPages[0], new int[] { 255, 255, 192 }, 2))
            {
                return;
            };
            //anualbenefitTempID++;
            DateTime paymentDate = PmtDateFuture.Value;
            Int64 Prop_AnualBenefitID = Convert.ToInt64(MultyCSelectProperty.MultiColumnComboBoxElement.Rows[MultyCSelectProperty.SelectedIndex].Cells["RealEstateAnualBenefitID"].Value);
            int Prop_Temp_AnualBenefitID = Convert.ToInt32(MultyCSelectProperty.MultiColumnComboBoxElement.Rows[MultyCSelectProperty.SelectedIndex].Cells["TempAnualproID"].Value);
            for (int i = 0; i < Convert.ToInt32(txtmothFuture.Text); i++)
            {

                if (!gvFuturePayment.Rows.AsEnumerable().Any(x => Convert.ToDateTime(x.Cells["Date"].Value).Month == paymentDate.Month))
                {
                    TempIdDto++;
                    FuturesPmtMadeDto.Add(new FuturesPmtPlanDto
                    {
                        Description = txtRefFurutes.Text
                     ,
                        anualbenefitTempID = Prop_Temp_AnualBenefitID
                     ,
                        tempID = TempIdDto
                      ,
                        RealEstateAnualBenefitID = Prop_AnualBenefitID
                     ,
                        Paid = false
                     ,
                        Date = paymentDate
                     ,
                        Amount = Convert.ToDecimal(txtAmountFutures.Text)
                     ,
                        AmountPaid = 0
                     ,
                        PaymentMethod = cbPmtMethodFuture.Text
                     ,
                        user = Globalvariables.Userfullname
                     ,
                        Undo = false
                    });

                    //insertamos los registros nuevos directo en el contexto de la entidad registry
                    _RealEstateRegistry.RealEstateAnualBenefit
                   .First(y => y.RealEstateAnualBenefitID == Prop_AnualBenefitID)
                   .RealEstateFPaymentPlan.Add(new RealEstateFPaymentPlanModel
                   {
                       Description = txtRefFurutes.Text
                       ,
                       tempFPaymentPlanID = TempIdDto
                       ,
                       tempRealEstateAnualBenefitID = Prop_Temp_AnualBenefitID
                       ,
                       RealEstateAnualBenefitID = Prop_AnualBenefitID
                       ,
                       UserID = Globalvariables.guserid
                       ,
                       Active = 1
                       ,
                       Amount = Convert.ToDecimal(txtAmountFutures.Text)
                       ,
                       Date = paymentDate
                       ,
                       PaymentMethodID = Convert.ToInt32(cbPmtMethodFuture.SelectedValue)
                   });

                }
                paymentDate = paymentDate.AddMonths(1);

            }

            LoadFuturePaymentInfo();
            MainControls.ClearTextBox(TabPaymetnControl);

        }
        private void LoadFuturePaymentInfo() // filtro de payment por anual benefitid en caso de que sea nuevo lo filtra por ID temporal
        {
            gvFuturePayment.DataSource = null;
            if (MultyCSelectProperty.DataSource == null)
            {
                return;
            }
            Int64 Value1 = Convert.ToInt64(MultyCSelectProperty.MultiColumnComboBoxElement.Rows[MultyCSelectProperty.SelectedIndex].Cells["RealEstateAnualBenefitID"].Value);
            if (Value1 != 0)
            {

                gvFuturePayment.DataSource = FuturesPmtMadeDto.Where(x => x.RealEstateAnualBenefitID == Value1);
                Foundrecords.Text = gvFuturePayment.RowCount.ToString();
            }
            else
            {
                Int64 value = Convert.ToInt64(MultyCSelectProperty.MultiColumnComboBoxElement.Rows[MultyCSelectProperty.SelectedIndex].Cells["TempAnualproID"].Value);
                //Int64 value = Convert.ToInt64(MultyCSelectProperty.EditorControl.CurrentRow.Cells["TempAnualBenefitID"].Value);
                gvFuturePayment.DataSource = FuturesPmtMadeDto.Where(x => x.anualbenefitTempID == value && x.RealEstateAnualBenefitID == 0);
                Foundrecords.Text = gvFuturePayment.RowCount.ToString();
            }

        }
        private void btnUndoAllPmtGen_Click(object sender, EventArgs e)
        {
            try
            {

                Int64 TempAnualproID = Convert.ToInt64(MultyCSelectProperty.MultiColumnComboBoxElement.Rows[MultyCSelectProperty.SelectedIndex].Cells["TempAnualproID"].Value);
                Int64 RealEstateAnualBenefitID = Convert.ToInt64(MultyCSelectProperty.MultiColumnComboBoxElement.Rows[MultyCSelectProperty.SelectedIndex].Cells["RealEstateAnualBenefitID"].Value);

                //tmpFuturPmtPlan, PARA GUARDAR LOS OBJETOS A ELIMINAR
                List<FuturesPmtPlanDto> tmpFuturPmtPlan = FuturesPmtMadeDto.Where(y => y.Undo == true).ToList();
                if (tmpFuturPmtPlan.Count == 0)
                {
                    return;
                }
                if (tmpFuturPmtPlan.Any(y => y.RealEstateAnualBenefitID > 0))
                {
                    if (!AuthoritationKey())
                    {
                        return;
                    }

                }

                DialogResult Dresult = MessageBox.Show($"{tmpFuturPmtPlan.Count()} future payments will be eliminated, Do you want to continue?", "", MessageBoxButtons.YesNo);

                if (DialogResult.No == Dresult)
                {
                    return;
                }

                //eliminar de la lista si aun no estan registrados en la base de datos
                foreach (var TMPpmt in tmpFuturPmtPlan)
                {
                    if (TMPpmt.FuturesPmtPlanID != 0)
                    {
                        //  DESACTIVAMOS EL PAYMENT             //actualizar estado para los que estan registrado en la base de datos
                        _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateAnualBenefitID == TMPpmt.RealEstateAnualBenefitID).RealEstateFPaymentPlan
                                .FirstOrDefault(ll => ll.RealEstateFPaymentPlanID == TMPpmt.FuturesPmtPlanID).Active = 0;

                        // seteamos el usuario que lo ha desactivado
                        _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateAnualBenefitID == TMPpmt.RealEstateAnualBenefitID).RealEstateFPaymentPlan
                                 .FirstOrDefault(ll => ll.RealEstateFPaymentPlanID == TMPpmt.FuturesPmtPlanID).DeactiveUserId = Globalvariables.guserid;
                        // seteamos la fecha de desactivo
                        _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateAnualBenefitID == TMPpmt.RealEstateAnualBenefitID).RealEstateFPaymentPlan
                                 .FirstOrDefault(ll => ll.RealEstateFPaymentPlanID == TMPpmt.FuturesPmtPlanID).DesactiveDate = DateTime.Today;

                        //Y LUEGO SUS TRANSACCIONES
                        var trans = _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateFPaymentPlan.Any(y => y.RealEstateAnualBenefitID == TMPpmt.RealEstateAnualBenefitID))
                                .RealEstateFPaymentPlan.FirstOrDefault(xr => xr.RealEstatePmtTransaction.Count > 0 || xr.RealEstatePmtTransaction.Any(rrr => rrr.Active == 1));

                        //trans.RealEstatePmtTransaction.ToList();


                        if (trans != null)
                        {
                            var transplan = trans.RealEstatePmtTransaction.Where(a => a.Active == 1 && a.RealEstateFPaymentPlanID == TMPpmt.FuturesPmtPlanID).ToList();

                            transplan.ForEach(hh =>
                           {
                               _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateAnualBenefitID == TMPpmt.RealEstateAnualBenefitID)
                               .RealEstateFPaymentPlan.Where(xxr => xxr.RealEstatePmtTransaction.Count > 0).FirstOrDefault()
                               .RealEstatePmtTransaction.FirstOrDefault().Active = 0;

                               _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateAnualBenefitID == TMPpmt.RealEstateAnualBenefitID)
                              .RealEstateFPaymentPlan.Where(xxr => xxr.RealEstatePmtTransaction.Count > 0).FirstOrDefault()
                              .RealEstatePmtTransaction.FirstOrDefault().DeactiveUserID = Globalvariables.guserid;

                               _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateAnualBenefitID == TMPpmt.RealEstateAnualBenefitID)
                              .RealEstateFPaymentPlan.Where(xxr => xxr.RealEstatePmtTransaction.Count > 0).FirstOrDefault()
                              .RealEstatePmtTransaction.FirstOrDefault().DeactiveDate = DateTime.Today;

                           }
                           );
                        }

                    }
                    else
                    {

                        var FpmtToRemove = _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.Active != 0 && x.RealEstateFPaymentPlan.Any(yy => yy.tempFPaymentPlanID == TMPpmt.tempID && yy.Active == 1))
                                                                                .RealEstateFPaymentPlan.First(yy => yy.tempFPaymentPlanID == TMPpmt.tempID && yy.Active == 1);

                        _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateFPaymentPlan
                      .Any(r => r.tempFPaymentPlanID == TMPpmt.tempID)
                      ).RealEstateFPaymentPlan
                           .Remove(FpmtToRemove);
                    }


                }


                FuturesPmtMadeDto.RemoveAll(x => x.Undo == true && x.RealEstateAnualBenefitID == RealEstateAnualBenefitID);
                FuturesPmtMadeDto.RemoveAll(x => x.Undo == true && x.anualbenefitTempID == TempAnualproID);
                LoadFuturePaymentInfo();
                DysplayTransactionPerProperty();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry,Something went wrong.(no changes!)");
            }
        }

        private void txtmothFuture_Enter(object sender, EventArgs e)
        {
            if (((Control)sender).BackColor != Color.Transparent)
            {
                ((Control)sender).BackColor = Color.Transparent;
            }
        }

        private void gvFuturePayment_CellClick(object sender, GridViewCellEventArgs e)
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

        private void cbPaymentProperty_SelectedValueChanged(object sender, EventArgs e)
        {

            //LoadFuturePaymentInfo();

        }

        //****************************
        private decimal SumTransXPaymentPlas(Int64 FpaymentPlanID) //FUNCION QUE RETORNA LA SUMA DE LAS TRANSACCIONES POR PAYMENTPLANT
        {
            decimal totPaidToFpayment = 0;

            foreach (var row in gvPaymentApplyed.Rows.AsEnumerable().Where(x => Convert.ToInt64(x.Cells["RealEstateFPaymentPlanID"].Value) == FpaymentPlanID))
            {
                totPaidToFpayment += Convert.ToDecimal(row.Cells["Amount"].Value);
            }
            return totPaidToFpayment;
        }
        //*****************************


        private void gvFuturePayment_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2 && e.RowIndex > -1)
                {
                    if ((bool)e.Row.Cells["paid"].Value)
                    {
                        MessageBox.Show("This payment is already done");
                        return;
                    }

                    string Propert = MultyCSelectProperty.Text;

                    if (Convert.ToInt64(gvFuturePayment.CurrentRow.Cells["FuturesPmtPlanID"].Value) == 0)
                    {
                        DialogResult result1 = MessageBox.Show($"You must save the changes, do you want to continue?", "", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            Btnsave.PerformClick();
                            //PaymentFuturePayment(_RealEstateRegistry.RealEstateAnualBenefit.ToList());
                            //AnualbenifitData();
                            return;

                        }
                        else
                        {
                            return;
                        }

                    }

                    ChargeDtoAnualbenifitData();
                    //cbPaymentProperty.SelectedText = Propert;

                    DialogResult result = MessageBox.Show($"Do you want to mark as paid this Payment {gvFuturePayment.CurrentRow.Cells["Date"].Value}", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        decimal totPaidToFpayment = SumTransXPaymentPlas(Convert.ToInt64(gvFuturePayment.CurrentRow.Cells["FuturesPmtPlanID"].Value));


                        decimal amountToPay = Convert.ToDecimal(e.Row.Cells["Amount"].Value) - totPaidToFpayment;

                        List<RealEstatePmtTransactionModel> realEstatePmtTrans = new List<RealEstatePmtTransactionModel>();
                        realEstatePmtTrans.Add(new RealEstatePmtTransactionModel()
                        {

                            Active = 1,
                            ApplicationDate = Convert.ToDateTime(e.Row.Cells["Date"].Value)
                           ,
                            Description = "Direct Payment"
                           ,
                            TransDate = DateTime.Today
                           ,
                            PaymentMethodID = Convert.ToInt64(e.Row.Cells["PaymentMethodID"].Value)
                            ,
                            Amount = amountToPay
                            ,
                            RealEstateFPaymentPlanID = Convert.ToInt64(e.Row.Cells["FuturesPmtPlanID"].Value)
                            ,
                            UserID = Globalvariables.guserid
                        });

                        ApplyPaymentToFuture(realEstatePmtTrans);

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void ApplyPaymentToFuture(List<RealEstatePmtTransactionModel> realEstatePmtTrans)
        {
            Int64 property = Convert.ToInt64(MultyCSelectProperty.MultiColumnComboBoxElement.Rows[MultyCSelectProperty.SelectedIndex].Cells["RealEstateAnualBenefitID"].Value);

            _Owner = new Owner();
            List<RealEstateFPaymentPlanModel> realEstateFPaymentPlan = new List<RealEstateFPaymentPlanModel>();
            realEstateFPaymentPlan = _Owner.PaidFutures(realEstatePmtTrans, property);
            _RealEstateRegistry.RealEstateAnualBenefit.First(x => x.RealEstateAnualBenefitID == property)
                                                       .RealEstateFPaymentPlan = realEstateFPaymentPlan;

            PaymentFuturePayment(_RealEstateRegistry.RealEstateAnualBenefit.ToList());
            LoadFuturePaymentInfo();

        }

        private void MultyCSelectProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPaymetnControl.Enabled = MultyCSelectProperty is null ? false : true;
            gvFuturePayment.Enabled = MultyCSelectProperty is null ? false : true;

        }

        private void MultyCSelectProperty_SelectedValueChanged(object sender, EventArgs e)
        {

        }


        void DysplayTransactionPerProperty()//se utiliza en otros metodos
        {
            try
            {
                gvPaymentApplyed.DataSource = null;
                transactionPerAnualBenfit = new List<RealEstatePmtTransactionModel>();
                TransactionDto = new List<RealEstatePmtTransactionDto>();

                //*************SE INSERTAN LASTRANSACCIONES REALIZADAS EN DATAGRID DE LAS TRANSCCIONES...
                Int64 property = Convert.ToInt64(MultyCSelectProperty.MultiColumnComboBoxElement.Rows[MultyCSelectProperty.SelectedIndex].Cells["RealEstateAnualBenefitID"].Value);
                if (property != 0)
                {
                    _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateAnualBenefitID == property && x.Active == 1)
                     .RealEstateFPaymentPlan.Where(xy => xy.Active == 1).ToList()
                     .ForEach(tr => tr.RealEstatePmtTransaction.Where(xy => xy.Active == 1).ToList()
                        .ForEach(l =>
                        {
                            transactionPerAnualBenfit.Add(l);

                        }
                     ));
                }

                transactionPerAnualBenfit.ForEach(x =>
                         TransactionDto.Add(new RealEstatePmtTransactionDto
                         {
                             Amount = x.Amount,
                             ApplicationDate = x.ApplicationDate,
                             Description = x.Description,
                             PaymentMethod = PaymentMethodFrequency.PaymentMethod.FirstOrDefault(xr => xr.PaymentMethodID == x.PaymentMethodID).Description
                         ,
                             PaymentMethodID = x.PaymentMethodID,
                             RealEstatePmtTransactionID = x.RealEstatePmtTransactionID
                         ,
                             Undo = x.Undo
                         ,
                             User = lstUsers.FirstOrDefault(xu => xu.Id == x.UserID).FirstName + ' ' + lstUsers.FirstOrDefault(xu => xu.Id == x.UserID).LastName
                             ,
                             RealEstateFPaymentPlanID = x.RealEstateFPaymentPlanID
                             ,PaymentMethodReference = x.PaymentMethodReference
                         })
                             );
                gvPaymentApplyed.DataSource = TransactionDto;
                //FuturePaymentInformations(Int6);
                PaymentsAplicationDateList();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void MultyCSelectProperty_DropDownClosed(object sender, RadPopupClosedEventArgs args)
        {
            LoadFuturePaymentInfo();
            DysplayTransactionPerProperty();
        }

        private void gvFuturePayment_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "Paid")
            {
                if ((decimal)e.Row.Cells[5].Value >= (decimal)e.Row.Cells[4].Value)
                {

                    e.CellElement.Value = 1;
                    e.CellElement.ForeColor = Color.White;
                    e.CellElement.BackColor = Color.Gold;

                }
                else
                {
                    //e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                }

            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
            }


        }

        private void btnUndoPaymnet_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 RealEstateAnualBenefitID = Convert.ToInt64(MultyCSelectProperty.MultiColumnComboBoxElement.Rows[MultyCSelectProperty.SelectedIndex].Cells["RealEstateAnualBenefitID"].Value);

                //tmpFuturPmtPlan, PARA GUARDAR LOS OBJETOS A ELIMINAR
                //List<RealEstatePmtTransactionDto> TransactionDto
                List<RealEstatePmtTransactionDto> tmpFuturPmtDto = TransactionDto.Where(y => y.Undo == true).ToList();

                List<RealEstatePmtTransactionModel> tmpFuturPmt = new List<RealEstatePmtTransactionModel>();
                tmpFuturPmtDto.ForEach(x =>
                {
                    tmpFuturPmt.Add(new RealEstatePmtTransactionModel
                    {
                        Amount = x.Amount,
                        ApplicationDate = x.ApplicationDate
                        ,
                        Description = x.Description,
                        PaymentMethodID = x.PaymentMethodID,
                        RealEstatePmtTransactionID = x.RealEstatePmtTransactionID
                        ,
                        Undo = x.Undo
                        ,
                        RealEstateFPaymentPlanID = x.RealEstateFPaymentPlanID

                    });
                }
                );

                if (tmpFuturPmt.Count == 0)
                {
                    return;
                }

                if (!AuthoritationKey())
                {
                    return;
                }
                DialogResult Dresult = MessageBox.Show($"{tmpFuturPmt.Count()} payments will be eliminated, Do you want to continue?", "", MessageBoxButtons.YesNo);

                if (DialogResult.No == Dresult)
                {
                    return;
                }
                foreach (var TMPpmt in tmpFuturPmt)
                {
                    _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateAnualBenefitID == RealEstateAnualBenefitID)
                        .RealEstateFPaymentPlan.FirstOrDefault(xxr => xxr.RealEstatePmtTransaction.Any(h => h.RealEstatePmtTransactionID == TMPpmt.RealEstatePmtTransactionID))
                        .RealEstatePmtTransaction.FirstOrDefault(un => un.RealEstatePmtTransactionID == TMPpmt.RealEstatePmtTransactionID).Active = 0;

                    _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateAnualBenefitID == RealEstateAnualBenefitID)
                       .RealEstateFPaymentPlan.FirstOrDefault(xxr => xxr.RealEstatePmtTransaction.Any(h => h.RealEstatePmtTransactionID == TMPpmt.RealEstatePmtTransactionID))
                       .RealEstatePmtTransaction.FirstOrDefault(un => un.RealEstatePmtTransactionID == TMPpmt.RealEstatePmtTransactionID).DeactiveUserID = Globalvariables.guserid;

                    _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x => x.RealEstateAnualBenefitID == RealEstateAnualBenefitID)
                       .RealEstateFPaymentPlan.FirstOrDefault(xxr => xxr.RealEstatePmtTransaction.Any(h => h.RealEstatePmtTransactionID == TMPpmt.RealEstatePmtTransactionID))
                       .RealEstatePmtTransaction.FirstOrDefault(un => un.RealEstatePmtTransactionID == TMPpmt.RealEstatePmtTransactionID).DeactiveDate = DateTime.Today;
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
            DysplayTransactionPerProperty();


        }

        private void gvPaymentApplyed_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex > -1)
            {
                if (e.Row.Cells[2].Value != null)
                {
                    e.Row.Cells[2].Value = !(bool)e.Row.Cells[2].Value;

                }
            }
        }

        private void gvFuturePayment_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            if (gvFuturePayment.RowCount == 0)
            {
                lblTotalToBePay.Text = 0.ToString("C2");

                lblPmtPaid.Text = 0.ToString("C2");
                return;
            }
            decimal total = 0;
            decimal Paid = 0;
            foreach (var row in gvFuturePayment.Rows)
            {

                total += Convert.ToDecimal(row.Cells["Amount"].Value);
                Paid += Convert.ToDecimal(row.Cells["AmountPaid"].Value);
            }

            lblTotalToBePay.Text = total.ToString("C2");
            lblPmtPaid.Text = Paid.ToString("C2");
            PaymentsAplicationDateList();

        }
        //Funcion para cargar las fechas de los pagos correspondiente
        private void PaymentsAplicationDateList()
        {
            PmtApDate.DataSource = null;
            Int64 Value1 = Convert.ToInt64(MultyCSelectProperty.MultiColumnComboBoxElement.Rows[MultyCSelectProperty.SelectedIndex].Cells["RealEstateAnualBenefitID"].Value);
            PmtApDate.ValueMember = "FuturesPmtPlanID";
            PmtApDate.DisplayMember = "Date";
            PmtApDate.DataSource = FuturesPmtMadeDto.Where(x => x.RealEstateAnualBenefitID == Value1 && x.Paid != true);
            FuturePaymentInformations(Convert.ToInt64(PmtApDate.SelectedValue));

        }

        void ResultValanceDeu()
        {
            decimal PmtPaid = Convert.ToDecimal(lblPmtPaid.Text.Replace("$", ""));

            decimal deu = Convert.ToDecimal(lblTotalToBePay.Text.Replace("$", "")) - PmtPaid;
            lblBalanceDeu.Text = deu.ToString("C2");
        }
        private void lblPmtPaid_TextChanged(object sender, EventArgs e)
        {
            ResultValanceDeu();
        }

        private void btnApplyPmt_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtrefApplicationPmt.Text.Trim().Length == 0)
                {
                    txtrefApplicationPmt.Focus();
                    txtrefApplicationPmt.BackColor = Color.FromArgb(255, 255, 192);
                    return;
                }
                if (Convert.ToDecimal(txtPmtAmountFuture.Text) == 0 )
                {
                    txtPmtAmountFuture.Focus();
                    txtPmtAmountFuture.BackColor = Color.FromArgb(255, 255, 192);
                    return;
                }

                if (gvFuturePayment != null && gvFuturePayment.RowCount > 0)
                {

                    Int64 FuturesPmtPlanID = Convert.ToInt64(PmtApDate.SelectedValue);


                    if (FuturesPmtPlanID == 0)
                    {
                        DialogResult result = MessageBox.Show($"this payment plan has not been saved yet.[{PmtApDate.Text}]", "Do you want to do it first", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            Btnsave.PerformClick();
                        }
                    }
                    else
                    {
                        decimal totPaidToFpayment = SumTransXPaymentPlas(FuturesPmtPlanID);
                        decimal APagarEnMEs = Convert.ToDecimal(gvFuturePayment.Rows.AsEnumerable().FirstOrDefault(x => Convert.ToInt64(x.Cells["FuturesPmtPlanID"].Value) == Convert.ToInt64(PmtApDate.SelectedValue)).Cells["Amount"].Value);
                        //decimal AmountPaid = Convert.ToDecimal(gvFuturePayment.Rows.AsEnumerable().FirstOrDefault(x => Convert.ToInt64(x.Cells["FuturesPmtPlanID"].Value) == Convert.ToInt64(PmtApDate.SelectedValue)).Cells["AmountPaid"].Value);
                        decimal SumaDePagosMasMontoActual = totPaidToFpayment + Convert.ToDecimal(txtPmtAmountFuture.Text);

                        if (APagarEnMEs >= SumaDePagosMasMontoActual) //se evalua si hay un monto a favor para aplicarlo al siguiente mes
                        {
                            _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x =>
                                   x.RealEstateFPaymentPlan.Any(pp => pp.RealEstateFPaymentPlanID == FuturesPmtPlanID))
                               .RealEstateFPaymentPlan.FirstOrDefault(pmt => pmt.RealEstateFPaymentPlanID == FuturesPmtPlanID)
                               .RealEstatePmtTransaction.Add(new RealEstatePmtTransactionModel
                               {
                                   Active = 1,
                                   Description = txtrefApplicationPmt.Text,
                                   ApplicationDate = Convert.ToDateTime(PmtApDate.Text),
                                   Amount = Convert.ToDecimal(txtPmtAmountFuture.Text),
                                   RealEstateFPaymentPlanID = FuturesPmtPlanID,
                                   PaymentMethodID = Convert.ToInt64(cbFutureMethod.SelectedValue),
                                   TransDate = DateTime.Today,
                                   UserID = Globalvariables.guserid
                                   ,PaymentMethodReference = txtPaymentMethodReference.Visible?
                                                               txtPaymentMethodReference.Text : cbTranferPmt.Visible?
                                                                                                cbTranferPmt.SelectedValue.ToString() : ""
                               });

                        }
                        else
                        {
                            Int64 Value1 = Convert.ToInt64(MultyCSelectProperty.MultiColumnComboBoxElement.Rows[MultyCSelectProperty.SelectedIndex].Cells["RealEstateAnualBenefitID"].Value);
                            var LstFpayments = FuturesPmtMadeDto.Where(x => x.RealEstateAnualBenefitID == Value1 && x.Paid != true).ToList();

                            FPaymetntSelection selecttion = new FPaymetntSelection(Convert.ToDecimal(txtPmtAmountFuture.Text), Convert.ToInt64(PmtApDate.SelectedValue), LstFpayments, txtrefApplicationPmt.Text);

                            DialogResult res = selecttion.ShowDialog();

                            TransactionSelected = selecttion.TransactionSelected.Where(x => x.Amount > 0).ToList();

                            if (res == DialogResult.OK)
                            {
                                TransactionSelected.ForEach(y =>
                                {
                                    _RealEstateRegistry.RealEstateAnualBenefit.FirstOrDefault(x =>
                                       x.RealEstateFPaymentPlan.Any(pp => pp.RealEstateFPaymentPlanID == y.RealEstateFPaymentPlanID))
                                   .RealEstateFPaymentPlan.FirstOrDefault(pmt => pmt.RealEstateFPaymentPlanID == y.RealEstateFPaymentPlanID)
                                   .RealEstatePmtTransaction.Add(new RealEstatePmtTransactionModel
                                   {
                                       Active = y.Active,
                                       Description = y.Description,
                                       ApplicationDate = y.ApplicationDate,
                                       Amount =  y.Amount,
                                       RealEstateFPaymentPlanID = y.RealEstateFPaymentPlanID,
                                       PaymentMethodID = Convert.ToInt64(cbFutureMethod.SelectedValue),
                                       TransDate = DateTime.Today,
                                       UserID = Globalvariables.guserid
                                       , PaymentMethodReference = txtPaymentMethodReference.Visible ?
                                                               txtPaymentMethodReference.Text : cbTranferPmt.Visible ?
                                                                                                cbTranferPmt.SelectedValue.ToString() : ""

                                   });


                                });

                            }
                            else
                            {
                                return;
                            }


                            //AQUI ES QUE VA

                        }

                        Btnsave.PerformClick();

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        void FuturePaymentInformations(Int64 FpaymplantId)
        {
            if (FpaymplantId == null || FpaymplantId ==0)
            {
                lblPmtDescription.Text = "----";
                lblAmountPmtInfo.Text = "0";
                lblPmtAmountPaid.Text = "0";
                lblRemAmountPiad.Text = "0";
                lblFoundTranAmountPaidXPLan.Text = "0";
                lblPmtTransDate.Text = "----";
                return;
            }
            //Int64 anualbenefitID = Convert.ToInt64(MultyCSelectProperty.MultiColumnComboBoxElement.Rows[MultyCSelectProperty.SelectedIndex].Cells["RealEstateAnualBenefitID"].Value);
            var Future = FuturesPmtMadeDto.FirstOrDefault(x => x.FuturesPmtPlanID == FpaymplantId);
            lblPmtDescription.Text = Future.Description;
            lblAmountPmtInfo.Text = Future.Amount.ToString("C2");
            lblPmtAmountPaid.Text = Future.AmountPaid.ToString("C2");
            lblRemAmountPiad.Text = (Future.Amount - Future.AmountPaid).ToString("C2");
            lblFoundTranAmountPaidXPLan.Text = gvPaymentApplyed.Rows.AsEnumerable().Where(x => Convert.ToInt64(x.Cells["RealEstateFPaymentPlanID"].Value) == FpaymplantId).Count().ToString();
            lblPmtTransDate.Text = Future.Date.ToShortDateString();
        }

        private void PmtApDate_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (PmtApDate.DataSource != null)
            {
                if (PmtApDate.Items.Count > 0)
                {
                    FuturePaymentInformations(Convert.ToInt64(PmtApDate.SelectedValue));
                }
                else
                {
                  
                }
            }
        }

        private void txtPmtAmountFuture_Enter(object sender, EventArgs e)
        {
            if (txtPmtAmountFuture.BackColor != Color.White)
            {
                txtPmtAmountFuture.BackColor = Color.White;
            }
        }

        private void cbFutureMethod_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (Convert.ToInt32(cbFutureMethod.SelectedValue) == 1)
            {
                cbTranferPmt.Visible = true;
                txtPaymentMethodReference.Visible = false;
                txtPaymentMethodReference.Text = string.Empty;
            }
            else if(Convert.ToInt32(cbFutureMethod.SelectedValue) == 2)
            {
                txtPaymentMethodReference.Visible = true;
                cbTranferPmt.Visible = false;
                txtPaymentMethodReference.Text = string.Empty;

            }
            else
            {
                cbTranferPmt.Visible = false;
                txtPaymentMethodReference.Visible = false;
                txtPaymentMethodReference.Text = string.Empty;
            }
        }

        private void gvPaymentApplyed_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {

            GridDataCellElement cell = sender as GridDataCellElement;


            //if (cell != null)
            //{
            //    //e.ToolTipText = "Pmt Ref.: ***" +row["PaymentMethodReference"].Value.ToString().Substring(row.Cells["PaymentMethodReference"].Value.ToString().Length - 4,4);
            //    e.ToolTipText = $"Pmt Ref.";
            //    e.ToolTip.ForeColor = Color.Red;
            //    e.ToolTip.ToolTipTitle = "Information";
            //    e.ToolTip.IsBalloon = true;
            //}
        }

        private void gvPaymentApplyed_CellFormatting(object sender, CellFormattingEventArgs e)
        {
                  
        }

        private void gvPaymentApplyed_RowFormatting(object sender, RowFormattingEventArgs e)
        {
                foreach (var cell in e.RowElement.Children)
                {
                    if (e.RowElement.RowInfo.Cells["PaymentMethod"].Value.ToString().ToUpper() == "WT"
                        || e.RowElement.RowInfo.Cells["PaymentMethod"].Value.ToString().ToUpper() == "CHECK")
                    {
                        cell.ToolTipText = $"Payment Ref. { e.RowElement.RowInfo.Cells["PaymentMethodReference"].Value.ToString()}";
            

                    }
                    
                }
           
        
    }
    }
}
