using Evolution.Forms.FormControlTools;
using Evolution.Forms.RealEstate.ControlsFuntions;
using Evolution.General;
using Persistence.DataBase.RealEstateMoldels;
using Services.RealEstate.Owner;
using Services.RealEstate.Owner.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Evolution.Forms.RealEstate
{
    public partial class RealEstateProcessPayment : Form
    {
        List<RealEstateTransactionModel> lstRealEstateTransaction;
        List<TransactionDto> lstTransactionDto;
        List<RealEstateAnualBenefitModel> _AnualBenefit;
        RealEstateRegistryModel _RealEstateRegistry;
        RadToolTip toolTip;
        //RealEstateConfig _config;
        Owner ow;
        FormControl _FormControl;
        int TransactionTempID = 1;
        string _defaultPath;
        private Int64 _SelectedAnualBenefit;
        private Int64 _PropertyId;
        private Int64 _RealEstateRegistryID;
        string _ownerName;
        
        //****PARA EL RETROACTIVO
        decimal AmountBenefitLAstYear = 0;
        decimal TotAnualbenLAstYear = 0;
        Int64 PreviewAnualBenenfitID = 0;


        public RealEstateProcessPayment()
        {
            InitializeComponent();
            SpecialPermitValidations();
            FillYearComboBox();
            openFileDialog1.Filter = "Attach Files (PDF,DOC)|*.PDF;*.DOC;";
            dtpApplicationDate.Text = DateTime.Today.ToShortDateString();
            dtpDate1.Text = DateTime.Today.AddMonths(-1).ToShortDateString();
            dtpDate2.Text = DateTime.Today.ToShortDateString();
           
        }
        public RealEstateProcessPayment(RealEstateConfig Config, Int64 realEstateRegistryID,Int64 SelectedAnualBenefit, Int64 PropertyId, string ownerName)
            : this()
        {
            if (!(Config is null))
            {
                if (File.Exists(@Config.AttachmentPath))
                {
                    if (!Directory.Exists(Config.AttachmentPath))
                    {
                        Directory.CreateDirectory(Config.AttachmentPath);
                    }
                    _defaultPath = Config.AttachmentPath;
                }
                else
                {
                    if (!Directory.Exists(Application.StartupPath.Replace("Debug", "Attachments")))
                    {
                        Directory.CreateDirectory(Application.StartupPath.Replace("Debug", "Attachments"));
                    }
                    _defaultPath = Application.StartupPath.Replace("Debug", "Attachments");
                }

               

            }
            else
            {
                if (!Directory.Exists(Application.StartupPath.Replace("Debug", "Attachments")))
                {
                    Directory.CreateDirectory(Application.StartupPath.Replace("Debug", "Attachments"));
                }
                _defaultPath = Application.StartupPath.Replace("Debug", "Attachments");
            }
            //*********************************************
            _PropertyId = PropertyId;
            _SelectedAnualBenefit = SelectedAnualBenefit;
            _ownerName = ownerName;
            _RealEstateRegistryID = realEstateRegistryID;
            //**********************************************
            FillOwnerData();
            //**********************************************
            _FormControl = new FormControl();

        }

        void FillOwnerData()
        {
           
            ow = new Owner();
            _RealEstateRegistry = ow.GetRealEstateRegistryById1(_RealEstateRegistryID);
            ////_AnualBenefit = _RealEstateRegistry.RealEstateAnualBenefit.ToList();
            _AnualBenefit = _RealEstateRegistry.RealEstateAnualBenefit.Where(x => x.RealEstatePropertyID == _PropertyId).ToList();
          
            lblOwner.Text = _ownerName;
            lblProperty.Text = _AnualBenefit.First(x => x.RealEstatePropertyID == _PropertyId).RealEstateProperty.Description;
            cbTransType.DataSource = ow.getTransType().Where(x => x.Active == 1 && x.Description != "Transfer").OrderByDescending(x => x.RealEstateTransactionTypeID);

            if (lstTransactionDto == null)
            {
                lstTransactionDto = new List<TransactionDto>();
            }
            if (true)
            {

            }
            LoadlstTransactionDto();
            
            //ListarFechaFrecuencias();
            loadGridByYear();
            DNCNDIFERENCE();

            if (_AnualBenefit.Any(x=> x.Active == 1 && x.PrevieusAnualBenefitdID == 0 && x.Status == 0 && x.ContractDate.Year == DateTime.Today.Year))
            {
                return;
            }

            foreach (var anualBenefit in _AnualBenefit)
            {
                anualBenefit.RealEstateTransaction.Where(x => x.Active == 1 && x.ApplicationDate.Year < DateTime.Today.Year && x.RealEstateTransactionTypeID != 3).ToList()
                    .ForEach(t =>  TotAnualbenLAstYear += t.Amount);
            }

            if (_AnualBenefit.Any(x => x.PrevieusAnualBenefitdID != 0 && x.ContractDate.Year == DateTime.Today.Year))
            {

                
                if (_AnualBenefit.Any(x => x.PrevieusAnualBenefitdID != 0 && x.ContractDate.Year < DateTime.Today.Year))
                {
                    PreviewAnualBenenfitID = _AnualBenefit.Where(x => x.PrevieusAnualBenefitdID != 0 && x.ContractDate.Year < DateTime.Today.Year)
                                         .FirstOrDefault().PrevieusAnualBenefitdID;
                    AmountBenefitLAstYear = _AnualBenefit.Where(x => x.RealEstateAnualBenefitID == PreviewAnualBenenfitID).FirstOrDefault().AnnualBenefit;
                }
                else
                {
                    AmountBenefitLAstYear = _AnualBenefit.Where(x => x.RealEstateAnualBenefitID == _SelectedAnualBenefit).FirstOrDefault().AnnualBenefit;
                }

                
            }
            else
            {
                AmountBenefitLAstYear = _AnualBenefit.Where(x => x.RealEstateAnualBenefitID == _SelectedAnualBenefit).FirstOrDefault().AnnualBenefit;
            }

            if (!(_AnualBenefit.Any(x=> x.ContractDate.Year < DateTime.Today.Year && x.RealEstatePropertyID == _PropertyId)))
            {
                return;
            }
         
                if (AmountBenefitLAstYear > TotAnualbenLAstYear)
                {
                DialogResult msg = MessageBox.Show($"You have an outstanding amount from the previous year to pay ${(AmountBenefitLAstYear - TotAnualbenLAstYear)} " +
                    $" do you want to add it as an extra payment to the current year?", "Retroactive", MessageBoxButtons.YesNo);
                if (msg == DialogResult.Yes)
                {
                    LoadRetroactive();
                    btnRetroAc.Visible = false;
                }
                else
                {
                    if ((AmountBenefitLAstYear - TotAnualbenLAstYear) > 0)
                    {
                        btnRetroAc.Visible = true;
                    }
                }


            }
          
          
            //lblDiference.Text = (_AnualBenefit.FirstOrDefault(x => x.Status >= 0).AnnualBenefit + estrapayment - ((sumaCN + sumaDN))).ToString("C2");
        }
        DialogResult MensageYesNo(string msg, string titulo)
        {
            return MessageBox.Show(msg, titulo, MessageBoxButtons.YesNo);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_RealEstateRegistry.RealEstateAnualBenefit.Any(x=> x.RealEstateTransaction.Any(h=>h.RealEstateTransactionID == 0)))
            {
                //DialogResult msg2 = MensageYesNo("Do you want to apply them?", "Unsaved transactions!");
                if (MensageYesNo("Do you want to apply them?", "Unsaved transactions!") == DialogResult.Yes)
                {

                    bProcess.PerformClick();
                    //PaymentWtInfo PaymentWtInfo = new PaymentWtInfo();
                    //AddOwnedForm(PaymentWtInfo);
                    //PaymentWtInfo.ShowDialog();
                }
               

            }
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbFYear.Text) < DateTime.Today.Year )
            {
                if (!AuthoritationKey())
                {
                    return;
                }
            }
          
            if (txtDescript.Text.Length == 0 || txtAmount.Text.Length == 0 || cbTransType.SelectedIndex < 0)
            {
                MainControls.ChangeColorByTag(this, new int[] { 255, 255, 192 }, 2);

                return;
            }
            decimal TotalInstallment = 0;
            //foreach (var item in lstTransactionDto.Where(x=> x.Active == 1 &&( x.TransactionTypeID != 3 || x.TransactionTypeID != 7)))// el valor  3 es igal a extraPaid y no lo tomamos en cuenta com installment
            //{
            //    TotalInstallment += item.Amount;
            //}

            foreach (var item in gvPaymentINFO.Rows.AsEnumerable().Where(x=> Convert.ToInt32(x.Cells["TransactionTypeID"].Value) != 3 
                                                                          || Convert.ToInt32(x.Cells["TransactionTypeID"].Value) !=7))
            {
                var transType = Convert.ToDecimal(item.Cells["TransactionTypeID"].Value);
                if (transType != 3 || transType != 7)
                {
                 TotalInstallment += Convert.ToDecimal(item.Cells["Amount"].Value);
                 }

                }

            //decimal TotDiference = Convert.ToDecimal(lblDiference.Text.Trim().Replace("$", "").Replace("(","").Replace(")", ""));
            decimal TotDiference = _AnualBenefit.First(x => x.Status >= 0 && x.Active ==1).AnnualBenefit;

            decimal ExtraPaid = _AnualBenefit.First(y => y.Status >= 0 && y.Active == 1).RealEstateTransaction
                .Where(x => x.Active == 1 && (x.RealEstateTransactionTypeID == 3 || x.RealEstateTransactionTypeID == 7)).Sum(s => s.Amount);

            if ((TotalInstallment + Convert.ToDecimal(txtAmount.Text.Trim().Replace("$",""))) > TotDiference + ExtraPaid)
            {
                MessageBox.Show("This Payment cannot be executed, because it exceeds the total Annual benefit");
                return;
            }


            if (lstTransactionDto == null)
            {
                lstTransactionDto = new List<TransactionDto>();
            }


            if (!(File.Exists(openFileDialog1.FileName)) && txtFileName.Text.Trim().Length > 0) //VERIFICA SI TIENE DESCRIPCION Y HAY ARCHIVO SELECCIONADO
            {
                MessageBox.Show("No file selected");
                btnFile.Focus();
                return;
            }
            else if ((File.Exists(openFileDialog1.FileName)) && txtFileName.Text.Trim().Length == 0) //VERIFICA SI HAY ARCHIVO PERO ESTE NO  TIENE DESCRIPCION
            {
                MessageBox.Show("The file has no name");
                txtFileName.Focus();
                return;
            }

            if (File.Exists(Path.Combine(_defaultPath, txtFileName.Text + lblExtension.Text)))
            {
                MessageBox.Show("File Name Allready Exist");
                txtFileName.Focus();
                txtFileName.BackColor = Color.FromArgb(255, 255, 192);
                return;
            }

            _RealEstateRegistry.RealEstateAnualBenefit.Where(x => x.RealEstateAnualBenefitID == _SelectedAnualBenefit)
                .First().RealEstateTransaction
                .Add(new RealEstateTransactionModel
                {
                    TempID = TransactionTempID,
                    RealEstateAnualBenefitID = _SelectedAnualBenefit,
                    Active = 1,
                    Amount = Convert.ToDecimal(txtAmount.Text.Trim() == string.Empty ? "0" : txtAmount.Text),
                    Description = txtDescript.Text,
                    RealEstateTransactionTypeID = Convert.ToInt32(cbTransType.MultiColumnComboBoxElement.Rows[cbTransType.SelectedIndex].Cells["RealEstateTransactionTypeID"].Value),
                    TransDate = DateTime.Now,
                    UserID = Globalvariables.guserid, //TODO: Cambiar usuario dinamico 
                    ApplicationDate = dtpApplicationDate.Value,
                    RealEstateDocuments = txtFileName.Text.Trim().Length > 0 ? new RealEstateDocumentsModel
                    {
                        CreatedDate = DateTime.Now,FileName = txtFileName.Text + lblExtension.Text,FilePath = _defaultPath
                    } : null

                }) ;

            //_AnualBenefit.RealEstateTransaction.Add();


            lstTransactionDto.Add(new TransactionDto
            {
                TempID = TransactionTempID,
                RealEstateAnualBenefitID = _SelectedAnualBenefit,
                Description = txtDescript.Text,
                Amount = Convert.ToDecimal(txtAmount.Text),
                ApplicationDate = dtpApplicationDate.Value,
                Active = 1,
                TransactionType = cbTransType.MultiColumnComboBoxElement.Rows[cbTransType.SelectedIndex].Cells["Description"].Value.ToString(),
                TransactionTypeID = Convert.ToInt32(cbTransType.MultiColumnComboBoxElement.Rows[cbTransType.SelectedIndex].Cells["RealEstateTransactionTypeID"].Value)
                ,
                Type = cbTransType.MultiColumnComboBoxElement.Rows[cbTransType.SelectedIndex].Cells["Type"].Value.ToString()
                ,
                FileName = txtFileName.Text
                ,
                TempPath = openFileDialog1.FileName
                ,
                NewPath = _defaultPath
            });
            ShownGridInfo();
            openFileDialog1.Reset();
            txtFileName.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtDescript.Text = string.Empty;
            cbTransType.SelectedIndex = -1;
            TransactionTempID++;
        }
        //
        void FillYearComboBox()
        {

            cbFYear.DataSource = Enumerable.Range(DateTime.Now.Year - 10, 11).ToList();
            cbFYear.SelectedText = DateTime.Now.Year.ToString();
        }



        void ShownGridInfo() // MOSTRAR Y ACTUALIZAR LOS DATOS EN GRID
        {

            gvPaymentINFO.DataSource = null;
            gvPaymentINFO.DataSource = lstTransactionDto.Where(x=>x.ApplicationDate.Year == Convert.ToInt32(cbFYear.Text));

        }

        private void bProcess_Click(object sender, EventArgs e)
        {

            try
            {
                if (lstRealEstateTransaction == null)
                {
                    lstRealEstateTransaction = new List<RealEstateTransactionModel>();
                }

                ow = new Owner();

                ow.InsertOrUpdate1(_RealEstateRegistry);

                if (lstTransactionDto != null)
                {
                    foreach (var item in lstTransactionDto)
                    {
                        if (item.RealEstateTransactionID == 0)
                        {
                            if (item.TempPath.Trim().Replace("openFileDialog1", "") != "")
                            {
                                File.Copy(item.TempPath, Path.Combine(item.NewPath, item.FileName));
                            }

                        }
                    }
                }
                //lstTransactionDto = null;
                FillOwnerData();
                //LoadlstTransactionDto();

                MessageBox.Show("Done!!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        // CARGAR LOS DATO DE LA LISTA LoadlstTransactionDto 
        void LoadlstTransactionDto()
        {
            lstTransactionDto.Clear();
            lstTransactionDto = new List<TransactionDto>();
            foreach (var AnualBen in _AnualBenefit)
            {
                AnualBen.RealEstateTransaction.Where(x => x.Active == 1)
                    .ToList()
                    .ForEach(r => lstTransactionDto.Add(new TransactionDto
                    {

                        RealEstateTransactionID = r.RealEstateTransactionID,
                        Active = r.Active,
                        Amount = r.Amount,
                        ApplicationDate = r.ApplicationDate,
                        Description = r.Description,
                        RealEstateAnualBenefitID = r.RealEstateAnualBenefitID,
                        TransactionType = r.RealEstateTransactionType.Description,
                        TransactionTypeID = r.RealEstateTransactionTypeID,
                        Type = r.RealEstateTransactionType.Description,
                        FileName = r.RealEstateDocuments is null ? "" : r.RealEstateDocuments.FileName,
                        RealEstateDocumentID = r.RealEstateDocuments is null ? 0 : r.RealEstateDocuments.RealEstateDocumentsID
                        ,
                        AnualBenStatus = AnualBen.Status 
                        ,TransDate = r.TransDate
                    }
                    )); ;
            }
           

        }

        //string TransactionTReason(int Id = 0)
        //{
        //    string description = "Payment";
        //    switch (Id)
        //    {
        //        case 3:
        //            description = "ExtraPay";
        //                break;
        //        case 5:
        //            description = "Transfer";
        //            break;
        //        case 1:
        //            description = "Deduction";
        //            break;
        //        default:
        //            description = "";
        //            break;

        //    }
        //    return "";
        //}
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

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (!AuthoritationKey())
            {
                return;
            }

            if (gvPaymentINFO.RowCount <= 0) { return; }
            if ((int)gvPaymentINFO.CurrentRow.Cells["AnualBenStatus"].Value < 0)
            {
                MessageBox.Show("This Payment cannot be edited or deleted, because a contract update was made");
                return;
            }
            if (!gvPaymentINFO.CurrentRow.IsSelected) { return; }
            DialogResult dialogResult = MessageBox.Show($"will delete the following transaction [{gvPaymentINFO.CurrentRow.Cells["Description"].Value}]: Amount: {gvPaymentINFO.CurrentRow.Cells["Amount"].Value}", "Undo Tansaction", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }


            RealEstateTransactionModel deactivateTran;
            int realEstateTransactionID = gvPaymentINFO.CurrentRow.Cells["RealEstateTransactionID"].Value == null ? 0 : Convert.ToInt32(gvPaymentINFO.CurrentRow.Cells["RealEstateTransactionID"].Value);
            if (realEstateTransactionID != 0)
            {
                deactivateTran = _RealEstateRegistry.RealEstateAnualBenefit.Where(x => x.RealEstateAnualBenefitID == _SelectedAnualBenefit)
                .First().RealEstateTransaction.Where(x => x.RealEstateTransactionID == Convert.ToInt64(gvPaymentINFO.CurrentRow.Cells["RealEstateTransactionID"].Value))
                .FirstOrDefault();

                _RealEstateRegistry.RealEstateAnualBenefit.Where(x => x.RealEstateAnualBenefitID == _SelectedAnualBenefit)
                    .FirstOrDefault().RealEstateTransaction.Remove(deactivateTran);

                deactivateTran.Active = 0;

                _RealEstateRegistry.RealEstateAnualBenefit.Where(x => x.RealEstateAnualBenefitID == _SelectedAnualBenefit)
                .First().RealEstateTransaction.Add(deactivateTran);

                TransactionDto DtoToRemove = lstTransactionDto.Where(x => x.RealEstateTransactionID == Convert.ToInt32(gvPaymentINFO.CurrentRow.Cells["RealEstateTransactionID"].Value)).FirstOrDefault();

                lstTransactionDto.Remove(DtoToRemove);
            }
            else
            {
                deactivateTran = _RealEstateRegistry.RealEstateAnualBenefit.Where(x => x.RealEstateAnualBenefitID == _SelectedAnualBenefit)
                  .First().RealEstateTransaction.Where(x => x.RealEstateTransactionID == Convert.ToInt64(gvPaymentINFO.CurrentRow.Cells["TransactionTempID"].Value))
                  .FirstOrDefault();

                _RealEstateRegistry.RealEstateAnualBenefit.Where(x => x.RealEstateAnualBenefitID == _SelectedAnualBenefit)
                .First().RealEstateTransaction.Remove(deactivateTran);

                TransactionDto DtoToRemove = lstTransactionDto.Where(x => x.TempID == Convert.ToInt32(gvPaymentINFO.CurrentRow.Cells["TransactionTempID"].Value)).FirstOrDefault();

                lstTransactionDto.Remove(DtoToRemove);
            }


            ShownGridInfo();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char signo_decimal = (char)46; //Si pulsan el punto .
            if (char.IsNumber(e.KeyChar)  |
            e.KeyChar == (char)Keys.Escape | e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false; // No hacemos nada y dejamos que el sistema controle la pulsación de tecla
                return;
            }
            else if (e.KeyChar == signo_decimal)
            {
                //Si no hay caracteres, o si ya hay un punto, no dejaremos poner el punto(.)
                if (txtAmount.Text.Length == 0 | txtAmount.Text.LastIndexOf(signo_decimal) >= 0)
                {
                    e.Handled = true; // Interceptamos la pulsación para que no permitirla.
                }
                else //Si hay caracteres continuamos las comprobaciones
                {
                    //Cambiamos la pulsación al separador decimal definido por el sistema 
                    e.KeyChar = Convert.ToChar(System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator);
                    e.Handled = false; // No hacemos nada y dejamos que el sistema controle la pulsación de tecla
                }
                return;
            }
            else if (e.KeyChar == (char)13) // Si es un enter
            {
                e.Handled = true; //Interceptamos la pulsación para que no la permita.
                SendKeys.Send("{TAB}"); //Pulsamos la tecla Tabulador por código
            }
            else //Para el resto de las teclas
            {
                e.Handled = true; // Interceptamos la pulsación para que no tenga lugar
            }
        

        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.Text.Length > 0)
            {
                txtAmount.BackColor = Color.White;
            }

        }

        private void txtDescript_Leave(object sender, EventArgs e)
        {
            if (txtDescript.Text.Length > 0)
            {
                txtDescript.BackColor = Color.White;
            }
        }

        private void cbTransType_Leave(object sender, EventArgs e)
        {
            if (cbTransType.SelectedIndex >= 0)
            {
                txtDescript.BackColor = Color.White;
            }
        }
        //*****************OPERACION DE SUMA EN LA INGORMACION DEL GRID 
        void DNCNDIFERENCE()
        {
            if (_AnualBenefit == null)
            {
                return;
            }

            decimal TotalAnualBenToPay = 0;
          
            if (_AnualBenefit.Where(x => x.Status >= 0 ).Count() > 0)
            {
                TotalAnualBenToPay = _AnualBenefit.FirstOrDefault(x => x.Status >= 0).AnnualBenefit;
            }
            else
            {
                TotalAnualBenToPay = _AnualBenefit.Where(x => x.Status == -1).First().AnnualBenefit;
                
            }
            if (PreviewAnualBenenfitID > 0 && (int)cbFYear.SelectedValue < DateTime.Today.Year)
            {
                TotalAnualBenToPay = _AnualBenefit.Where(x => x.RealEstateAnualBenefitID == PreviewAnualBenenfitID).First().AnnualBenefit;
            }


            decimal sumaDN = 0;
            decimal sumaCN = 0;
            //decimal sumaTotal = 0;
            decimal estrapayment = 0;
            decimal Tranfer = 0;



            foreach (var item in gvPaymentINFO.Rows)
            {
                switch (Convert.ToInt32(item.Cells["TransactionTypeID"].Value))
                {

                    case 1 :
                        sumaDN += Convert.ToDecimal(item.Cells["Amount"].Value);
                        break;
                    case 3:
                        estrapayment += Convert.ToDecimal(item.Cells["Amount"].Value);
                        break;
                    case 4:
                        sumaCN += Convert.ToDecimal(item.Cells["Amount"].Value);
                        break;
                    case 7:
                        Tranfer += Convert.ToDecimal(item.Cells["Amount"].Value);
                        break;
                    default:
                        break;

                }


            }
            lblTotal.Text = (sumaCN + sumaDN).ToString("C2");
            lblDN.Text = sumaDN.ToString("C2");
            lblCN.Text = (sumaCN).ToString("C2");

            lblDiference.Text = (TotalAnualBenToPay + estrapayment - ((sumaCN + sumaDN)) - Tranfer).ToString("C2");

            if (Convert.ToDecimal(lblDiference.Text.Replace("$","").Replace("(", "").Replace(")", "")) < 0)
            {
                lblDiference.ForeColor = Color.Red;
            }
            else
            {
                lblDiference.ForeColor = Color.FromArgb(0, 192, 0);
            }

        }
        private void gvPaymentINFO_RowsChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {
            DNCNDIFERENCE();
        }

        //void ListarFechaFrecuencias()
        //{
        //    //_functions = new Functions();
        //    //lstPaymentfrecuence = _functions.FrequencyPayment(2);

        //    //cbFrequency.DataSource = cbFrequency.DataSource = Enumerable.Range(2000, 100).ToList();
        //    //cbFrequency.SelectedIndex = cbFrequency.Items.IndexOf($"{DateTime.Now.Year}");
        //}
        private void cbFrequency_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void radToggleSwitch1_MouseHover(object sender, EventArgs e)
        {
            if (toolTip == null)
            {
                toolTip = new RadToolTip();
            }

            if (!radToggleSwitch1.Value)
            {
                toolTip.Show("It will disable the payments applications", 3000);
            }

        }

        private void radToggleSwitch1_ValueChanged(object sender, EventArgs e)
        {
            if (radToggleSwitch1.Value)
            {
                pnTransRange.Enabled = true;
                btnAdd.Enabled = false;
                btnDeactivate.Enabled = false;
                lblMessageConsult.Visible = true;
            }
            else
            {
                pnTransRange.Enabled = false;
                btnAdd.Enabled = true;
                btnDeactivate.Enabled = true;
                lblMessageConsult.Visible = false;
                //ShownGridInfo();
                //LoadlstTransactionDto();
                loadGridByYear();
            }

        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            gvPaymentINFO.DataSource = null;
            gvPaymentINFO.DataSource = lstTransactionDto.Where(x => x.ApplicationDate >= dtpDate1.Value && x.ApplicationDate <= dtpDate2.Value).ToList();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                lblExtension.Text = Path.GetExtension(openFileDialog1.FileName);

                //txtFileName.Text = openFileDialog1.SafeFileName;
            }

        }
        void SpecialPermitValidations()
        {

            //add Payment
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 480 && x.Field<int>("Value") == 1).Count() > 0)
            {
                btnAdd.Visible = true;
            }

            //remove Payment
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 481 && x.Field<int>("Value") == 1).Count() > 0)
            {
                btnDeactivate.Visible = true;
            }

            //Apply payment
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 482 && x.Field<int>("Value") == 1).Count() > 0)
            {
                bProcess.Enabled = true;
            }


        }
        private void gvPaymentINFO_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                if (e.Column.Name == "FileName")
                {
                    if (!File.Exists(Path.Combine(_defaultPath, gvPaymentINFO.Rows[e.RowIndex].Cells["FileName"].Value.ToString())))
                    {

                        if (Convert.ToInt32(gvPaymentINFO.Rows[e.RowIndex].Cells["RealEstateTransactionID"].Value) == 0)
                        {
                            MessageBox.Show("The transaction has not yet been generated");
                        }
                        //else
                        //{
                        //    if (gvPaymentINFO.Rows[e.RowIndex].Cells["FileName"].Value.ToString().Trim() == "")
                        //    {

                        //    }
                        //    MessageBox.Show("File not Found");
                        //}

                        return;
                    }
                    Process.Start(Path.Combine(_defaultPath, gvPaymentINFO.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void gvPaymentINFO_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
          
        }

        private void cbFYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            _FormControl.OnlyDecimaltxt(sender, e);
        }


        #region FUNCTIONS
        void loadGridByYear()
        {
            ShownGridInfo();
            if (lstTransactionDto.Count > 0)
            {
                gvPaymentINFO.DataSource = null;
                gvPaymentINFO.DataSource = lstTransactionDto.Where(x => x.ApplicationDate.Year == Convert.ToInt32(cbFYear.Text)).ToList();

            }
        }


        #endregion

        private void cbFYear_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (lstTransactionDto != null)
            {

                loadGridByYear();
            }
            
        }

        private void RealEstateProcessPayment_Load(object sender, EventArgs e)
        {
            txtAmount.Focus();
        }

        private void gvPaymentINFO_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if ((int)e.RowElement.RowInfo.Cells["AnualBenStatus"].Value < 0)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                e.RowElement.BackColor = Color.LightGray;

            }
            else
            {


                e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
               

            }
        }
        void LoadRetroactive()
        {
            //AGREGO EL CREDITO COMO EXTRAPAYMENT A ESTE AÑO
            _RealEstateRegistry.RealEstateAnualBenefit.Where(x => x.RealEstateAnualBenefitID == _SelectedAnualBenefit)
            .First().RealEstateTransaction
            .Add(new RealEstateTransactionModel
            {
                TempID = TransactionTempID++,
                RealEstateAnualBenefitID = _SelectedAnualBenefit,
                Active = 1,
                Amount = (AmountBenefitLAstYear - TotAnualbenLAstYear),
                Description = $"Retroactive from-{(DateTime.Today.Year - 1)} ",
                RealEstateTransactionTypeID = 3,
                TransDate = DateTime.Now,
                UserID = Globalvariables.guserid,
                ApplicationDate = DateTime.Today,
                RealEstateDocuments = null
            });

            //y AQUI AGREGO OTRO COMO DN AL AÑO PASADO
            _RealEstateRegistry.RealEstateAnualBenefit.Where(x => x.RealEstateAnualBenefitID == _SelectedAnualBenefit)
          .First().RealEstateTransaction
          .Add(new RealEstateTransactionModel
          {
              TempID = TransactionTempID++,
              RealEstateAnualBenefitID = _SelectedAnualBenefit,
              Active = 1,
              Amount = (AmountBenefitLAstYear - TotAnualbenLAstYear),
              Description = $"TRANSFERRED TO-{(DateTime.Today.Year -1)} ",
              RealEstateTransactionTypeID = 7,
              TransDate = DateTime.Today,
              UserID = Globalvariables.guserid,
              ApplicationDate = new DateTime(DateTime.Today.Year - 1, 12, 01),
              RealEstateDocuments = null
          });
            bProcess.PerformClick();
        }
      
        private void btnRetroAc_Click(object sender, EventArgs e)
        {
            if (lstTransactionDto.Any(x=> x.TransactionTypeID == 7))
            {
                return;
            }
            DialogResult msg = MessageBox.Show($"You have an outstanding amount from the previous year to pay ${(AmountBenefitLAstYear - TotAnualbenLAstYear)} " +
                   $" Sure?", "Retroactive", MessageBoxButtons.YesNo);

            if (msg == DialogResult.Yes)
            {
                LoadRetroactive();

                btnRetroAc.Visible = false;
            }
            else
            {
                if ((AmountBenefitLAstYear - TotAnualbenLAstYear) > 0)
                {
                    btnRetroAc.Visible = true;
                }
            }


            
        }

        private void cbTransType_TextChanged(object sender, EventArgs e)
        {
            txtDescript.Text = cbTransType.Text;
        }
    }
}
