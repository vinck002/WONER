using Evolution.Forms.RealEstate.ControlsFuntions;
using Evolution.General.RealEstateData;
using Persistence.DataBase.RealEstateMoldels;
using Services.RealEstate.Owner;
using Services.RealEstate.Owner.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Evolution.Forms.RealEstate
{
    public partial class RealEstateProcessContract : Form
    {
        private List<RealEstateProcessContractDto> lstRealEstateProcessContractDto;
        Owner _owner;
        RealEstateConfig _config;
        FormControl _FormControl;
        BackgroundWorker bw;
        public RealEstateProcessContract()
        {
            InitializeComponent();
            loadGridData();
            FillYearComboBox();
            _FormControl = new FormControl(); 

        }

        void sumary()
        {
            if (dtgOwnerResult.RowCount == 0)
            {
                return;
            }
            decimal totalinstallment = 0;
            decimal totalAnualBenefit = 0;
            decimal totalJanFeb = 0;
            decimal totalMarApr = 0;
            decimal totalMayJun = 0;
            decimal totaljulAug = 0;
            decimal totalSepOct = 0;
            decimal totalnovDec = 0;

            foreach (var item in dtgOwnerResult.Rows)
            {
                totalinstallment += Convert.ToDecimal(item.Cells["PaymentAmount"].Value);
                totalAnualBenefit += Convert.ToDecimal(item.Cells["AnualBenefit"].Value);
                totalJanFeb += Convert.ToDecimal(item.Cells["JanToFeb"].Value);
                totalMarApr += Convert.ToDecimal(item.Cells["MarToApr"].Value);
                totalMayJun += Convert.ToDecimal(item.Cells["MayToJun"].Value);
                totaljulAug += Convert.ToDecimal(item.Cells["JulToAug"].Value);
                totalSepOct += Convert.ToDecimal(item.Cells["SepToOct"].Value);
                totalnovDec += Convert.ToDecimal(item.Cells["NovToDec"].Value);
            }
            lblTotInstallment.Text = totalinstallment.ToString("C2");
            lbltotBenefit.Text = totalAnualBenefit.ToString("C2");
            lblJanFeb.Text = totalJanFeb.ToString("C2");
            lblMarApr.Text = totalMarApr.ToString("C2");
            lblMayJun.Text = totalMayJun.ToString("C2");
            lblJulAug.Text = totaljulAug.ToString("C2");
            lblSepOct.Text = totalSepOct.ToString("C2");
            lblNobDec.Text = totalnovDec.ToString("C2");
        }
        private void btnGProperties_Click(object sender, EventArgs e)
        {
            RealEstateRegistry Registry = new RealEstateRegistry();
            Registry.ShowDialog();
        }

        void loadGridData()
        {
            _owner = new Owner();
            InitialConfigProcessDto InitialConfigData = _owner.LoadConfiguration();
           List<RealEstatePropertyTypeModel> getPropertyFilter = InitialConfigData.realEstatePropertyTypeModels.ToList();
            _config = InitialConfigData.RealEstateConfig;
            CPropertyType.ValueMember = "RealEstatePropertyTypeID";
            CPropertyType.DisplayMember = "Description";
            CPropertyType.DataSource = getPropertyFilter;
            CPropertyType.SelectedIndex = -1;
            
            // DATA GRID CONFIG
            dtgOwnerResult.GroupDescriptors.Add(new Telerik.WinControls.Data.GroupDescriptor("OwnerInfo"));
            dtgOwnerResult.TableElement.RowHeight = 19;
            dtgOwnerResult.TableElement.GroupHeaderHeight = 19;
            //dtgOwnerResult.BestFitColumns();
            
        }
  
        void FillYearComboBox()
        {
        
            cbFYear.DataSource = Enumerable.Range(DateTime.Now.Year - 10,11 ).ToList();
            cbFYear.SelectedText = DateTime.Now.Year.ToString();
        }

        #region functions


        //FUNCION PARA DIRIGIRNOS AL CONTROL DE PAGOS
        void openProcessPayment()
        {
            if (dtgOwnerResult.CurrentRow.Cells["RealEstateAnualBenefitID"].Value == null)
            {
                return;
            }
            //RealEstateProcessContractDto contract = lstRealEstateProcessContractDto.wh
            RealEstateProcessPayment ProcessPayment = new RealEstateProcessPayment(_config, Convert.ToInt64(dtgOwnerResult.CurrentRow.Cells["RealEstateRegistryID"].Value), Convert.ToInt64(dtgOwnerResult.CurrentRow.Cells["RealEstateAnualBenefitID"].Value), Convert.ToInt64(dtgOwnerResult.CurrentRow.Cells["RealEstatePropertyID"].Value), dtgOwnerResult.CurrentRow.Cells["OwnerInfo"].Value.ToString());
            ProcessPayment.ShowDialog();
        }


        #endregion
        private void dtgOwnerResult_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
            openProcessPayment();

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(cbFYear.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Only numbers are allowed");
                cbFYear.Focus();
                return;
            }
            int PropertyType = Convert.ToInt32(CPropertyType.SelectedIndex > -1? CPropertyType.SelectedValue:0);
            string propertyDesc = txtDescription.Text.Trim().Length > 0? txtDescription.Text:string.Empty;
            string ContractRef = txtContract.Text.Trim().Length > 0 ? txtContract.Text:string.Empty;
            lstRealEstateProcessContractDto = _owner.GetAllRealEstateContractProperty(Convert.ToInt32(cbFYear.Text), PropertyType, propertyDesc, ContractRef);
            dtgOwnerResult.DataSource = lstRealEstateProcessContractDto;
            lblSelectedYear.Text = cbFYear.Text;
            sumary();
        }

        private void RealEstateProcessContract_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");

            }
            if (e.KeyCode == Keys.F5)
            {
                btnSearch.PerformClick();

            }

        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            //dtgOwnerResult.TableElement.RowHeight = 30;
            if (dtgOwnerResult.RowCount == 0)
            {
                return;
            }
        

            dtgOwnerResult.PrintStyle.FitWidthMode = PrintFitWidthMode.FitPageWidth;
            dtgOwnerResult.PrintStyle.CellFont = new Font("Calibri", 5, FontStyle.Bold);
            dtgOwnerResult.PrintStyle.HeaderCellFont = new Font("Segoe UI", 5,FontStyle.Bold);
            dtgOwnerResult.PrintStyle.HeaderCellBackColor = Color.LightGray;
            
            
            dtgOwnerResult.PrintStyle.GroupRowBackColor = Color.AliceBlue;
            dtgOwnerResult.PrintStyle.GroupRowFont = new Font("Segoe UI", 6);
         
            dtgOwnerResult.PrintStyle.CellPadding = new Padding(0);

             RadPrintDocument document = new RadPrintDocument();
            document.DefaultPageSettings.Landscape = true;
            document.DefaultPageSettings.PrinterSettings.Copies = 1;
            document.HeaderHeight = 20;
            document.HeaderFont = new Font("Segoe UI", 8);
            document.AutoPortraitLandscape = true;
            document.Margins = new Margins(10,40,20,30);
            document.MiddleHeader = "Real Estate OWNERS Payment";
            document.RightHeader = "Page [Page #] of [Total Pages]";
            document.RightFooter = "Printed on: [Date Printed]";
            document.AssociatedObject = dtgOwnerResult;

            RadPrintPreviewDialog PrevDalog = new RadPrintPreviewDialog(document);
         
            PrevDalog.Show();
          
            
            //document.Print();
        }
        private async void ExcelExportdowork()
        {
            if (dtgOwnerResult.RowCount > 0)
            {
                if (lstRealEstateProcessContractDto != null)
                {
                    ExportRaelEstatePayment ERE = new ExportRaelEstatePayment();
                    ERE.ExportarGridview(lstRealEstateProcessContractDto, Convert.ToInt32(lblSelectedYear.Text));
                }
            }
        }
        private async void WorkerCompleted(object btn = null)
        {
            WaitPrint.StopWaiting();
            WaitPrint.Visible = false;
         
            if (btn is RadButton)
            {
                ((RadButton)btn).Enabled = true;
            }
            else
            {
                ((Button)btn).Enabled = true;
            }


        }
        void print(object sender)
        {
            try
            {
                ((Control)sender).Enabled = false;
                WaitPrint.StartWaiting();
                WaitPrint.Visible = true;
                bw = new BackgroundWorker();
                bw.DoWork += (obj, arg) => ExcelExportdowork();
                bw.RunWorkerCompleted += (obj, arg) => WorkerCompleted(sender);
                bw.RunWorkerAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnExproExcell_Click(object sender, EventArgs e)
        {

            print(sender);

        }

        private void cbFYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            _FormControl.OnlyDecimaltxt(sender, e);
        }

        private void dtgOwnerResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                openProcessPayment();
            }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgOwnerResult_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "JanToFeb")
            {
                if ((int)e.Row.Cells[22].Value > 0)
                {
                    
                    e.CellElement.DrawFill = true;
                    e.CellElement.ForeColor = Color.White;
                    e.CellElement.BackColor = Color.Red;

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
           

            if (e.CellElement.ColumnInfo.Name == "MarToApr")
            {
                if ((int)e.Row.Cells[23].Value > 0)
                {

                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.Red;
                    e.CellElement.ForeColor = Color.White;

                }
                else
                {
                    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                }

            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
            }

            if (e.CellElement.ColumnInfo.Name == "MayToJun")
            {
                if ((int)e.Row.Cells[24].Value > 0)
                {

                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.Red;
                    e.CellElement.ForeColor = Color.White;
                    

                }
                else
                {
                    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                }

            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
            }

            if (e.CellElement.ColumnInfo.Name == "JulToAug")
            {
                if ((int)e.Row.Cells[25].Value > 0)
                {

                    e.CellElement.DrawFill = true;
                    e.CellElement.BackColor = Color.Red;
                    e.CellElement.ForeColor = Color.White;

                }
                else
                {
                    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                }

            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
            }


            if (e.CellElement.ColumnInfo.Name == "SepToOct")
            {
                if ((int)e.Row.Cells[26].Value > 0)
                {

                    e.CellElement.DrawFill = true;
                    e.CellElement.ForeColor = Color.White;
                    e.CellElement.BackColor = Color.Red;

                }
                else
                {
                    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                }

            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
            }

            if (e.CellElement.ColumnInfo.Name == "NovToDec")
            {
                if ((int)e.Row.Cells[27].Value > 0)
                {

                    e.CellElement.DrawFill = true;
                    e.CellElement.ForeColor = Color.White;
                    e.CellElement.BackColor = Color.Red;

                }
                else
                {
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

        private void dtgOwnerResult_ConditionalFormattingFormShown(object sender, EventArgs e)
        {
           
        }

        private void dtgOwnerResult_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if ((int)e.RowElement.RowInfo.Cells["REtroactive"].Value == 1)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                e.RowElement.BackColor = Color.Yellow;

            }
            else
            {
                e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);

                //e.RowElement.DrawFill = true;
                //e.RowElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                //e.RowElement.BackColor = Color.LightGreen;


            }
        }
    }
}
