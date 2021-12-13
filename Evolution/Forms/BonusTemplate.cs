using Evolution.Forms.BonusCommissions;
using Evolution.General;
using Evolution.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Evolution.Forms
{
    public partial class BonusTemplate : Form, IBonusCommissioner
    {

        Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
        List<BonusCommissionerModel> _ListCommissionerInfo = new List<BonusCommissionerModel>();
        BonusCommisioner _FrmCommisioner;
        DataTable _ContractSeach;
        int _ContratcCounter = 0;
        decimal _SumaAmount = 0;
        decimal _TempCellAmount = 0; //save Cell vaule temp data fot validate Amount Sum

        string _datefrom;
        string _dateTo;
        decimal nTotalBonustoContract = 0; // total neto
        bool _AllowProcces = false;
        private long _BonusCommissionID;
        private int _Processed = -1;
        private string _Code;
        private StringBuilder _SbBathAgreementID;
        BonnusCommissionerSP BCSP;
        private bool _closedPrint;
        public bool ClosePrint { set { _closedPrint = value; } }
        public BonusTemplate()
        {
            InitializeComponent();
            BCSP = new BonnusCommissionerSP();

            _ListCommissionerInfo = BCSP.LoadCommissioner().Where(x => x.Selected == 1).ToList();
            GRDBonusCommissioner.DataSource = null;
            GRDBonusCommissioner.DataSource = _ListCommissionerInfo;
            SumAmount();
            txtContractFound.Text = (_ContratcCounter).ToString();
            ContractSelected();
            DataTable esto = Globalvariables.DVpermit.Table;
            if (Globalvariables.DVpermit.Table.AsEnumerable().Where(x => x.Field<int>("Code") == 470 && x.Field<int>("Value") == 1).Count() > 0)
            {
                btnApply.Visible = true;
            }
            else
            {
                btnApply.Visible = false;
            }
        }

        private void bHidtory_Click(object sender, EventArgs e)
        {
            BonusCommissionHistory BonusComHist = new BonusCommissionHistory(this);
            BonusComHist.ShowDialog();

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BonusTemplate_Load(object sender, EventArgs e)
        {
            DateTime DateTex = DateTime.Now;
            dtpContractDate1.Text = DateTex.AddMonths(-1).ToString("MM-dd-yyyy");
            dtpContractDate2.Text = DateTex.ToString("MM-dd-yyyy");
        }


        //***************************************************************I.N.T.E.R.F.A.C.E. carga Lista de Commissioners*************************************************
        #region Commissioners

        public void CommissionerInfo(List<BonusCommissionerModel> GetListCommissionerInfo)
        {

            _ListCommissionerInfo = null;
            GRDBonusCommissioner.DataSource = null;
            _ListCommissionerInfo = GetListCommissionerInfo;

            GRDBonusCommissioner.DataSource = _ListCommissionerInfo;
            SumAmount();
            txtContractFound.Text = (_ContratcCounter).ToString();

            for (int i = 0; i < GRDBonusCommissioner.Rows.Count; i++)
            {
                GRDBonusCommissioner.Rows[i].Cells["Total"].Value = (Convert.ToDecimal(GRDBonusCommissioner.Rows[i].Cells["ContractQuantity"].Value) * Convert.ToDecimal(GRDBonusCommissioner.Rows[i].Cells["Amount"].Value)).ToString("C");

            }


        }

        public void TemplateBathAgreement(DataTable ContractSeach, int Processed, Int64 BonusCommissionID, string datefrom, string dateTo, string Code)
        {
            _Code = Code;
            _BonusCommissionID = BonusCommissionID;
            _Processed = Processed;
            txtProcessed.Text = _Processed == 1 ? "PROCESSED" : "SAVED";
            txtProcessed.Visible = true;
            DGVAgreemetnResult.DataSource = null;
            _ContractSeach = ContractSeach;
            DGVAgreemetnResult.DataSource = ContractSeach;
            ContractCount();
            BonusTotalSelected();
            if (Processed == 1)
            {
                btnApply.Enabled = false;
                btnSave.Enabled = false;
            }
            else if (Processed == 0)
            {
                btnSave.Enabled = false;
                btnApply.Enabled = true;
            }

            _datefrom = datefrom;
            _dateTo = dateTo;
            if (ContractSeach == null)
            {

                btnClear.PerformClick();
            }
            else
            {
                dtpContractDate1.Text = datefrom.ToString(); dtpContractDate2.Text = dateTo.ToString();
            }

            DGVAgreemetnResultCheckBlock();
            btnPrint.Enabled = true;
        }


        private DialogResult PersonalMessageBox(string Text, string caption)
        {
            return MessageBox.Show(Text, caption, MessageBoxButtons.YesNo);

        }
        void DGVAgreemetnResultCheckBlock()
        {
            if (_Processed > -1)
            {
                DGVAgreemetnResult.Columns["Selected"].ReadOnly = true;
            }
            else
            {
                DGVAgreemetnResult.Columns["Selected"].ReadOnly = false;
            }
        }



        #endregion



        //***************************************************************E.N.D***************************************************************
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (_BonusCommissionID != null && DGVAgreemetnResult.RowCount > 0)
            {
                if (PersonalMessageBox("Are you sure, you want to make a new search?", "New Search") == DialogResult.No)
                {
                    return;
                }
            }
            ClearFields();
            BonnusCommissionerSP bcSP = new BonnusCommissionerSP();
            _ContractSeach = new DataTable();
            _ContractSeach = bcSP.batchAgreements(0, dtpContractDate1.Text, dtpContractDate2.Text);
            DGVAgreemetnResult.DataSource = null;
            //LA CONDICION DEBAJO ES PARA MOOSTRAR SOLO LOS CONTRATOS QUE NO HAN SIDO PROCESADOS
            var rows = _ContractSeach.AsEnumerable().Where(x => x.Field<int>("Processed") == 0).ToList();

            if (!rows.Any())
            {

                MessageBox.Show("No contracts to process!");
                DGVAgreemetnResult.DataSource = null;
            }
            else
            {
                DataTable Merge;
                Merge = rows.CopyToDataTable();
                DGVAgreemetnResult.DataSource = Merge;
                btnSave.Enabled = true;
                //ContractSeach.AsEnumerable().Where(x => x.Field<int>("Processed") == 0).CopyToDataTable();
            }
            ViewStatedProcessedSaved();
            ContractCount();
            BonusTotalSelected();
        }

        private void bAddComm_Click(object sender, EventArgs e)
        {
            _FrmCommisioner = new BonusCommisioner();
            AddOwnedForm(_FrmCommisioner);
            _FrmCommisioner.ShowDialog();
        }


        //********************************************** Metodos ,SUMAS y TEXBOX**************************************************************
        void ViewStatedProcessedSaved(bool p = false)
        {
            txtProcessed.Visible = p;
        }
        #region Sumas y Cuentas
        void SumAmount()
        {
            _SumaAmount = 0;
            if (GRDBonusCommissioner.RowCount > 0)
            {

                for (int i = 0; i < GRDBonusCommissioner.RowCount; i++)
                {
                    _SumaAmount += Convert.ToDecimal(GRDBonusCommissioner.Rows[i].Cells["Amount"].Value);
                }

            }

            txtTotaDist.Text = _SumaAmount.ToString("C");

        }
        void ContractCount()
        {
            _ContratcCounter = 0;
            if (DGVAgreemetnResult.RowCount > 0)
            {
                int Num;
                _ContratcCounter = DGVAgreemetnResult.Rows.AsEnumerable().Select(x => Num = Convert.ToInt32(x.Cells["Selected"].Value)).Where(x => x == 1).Count();

            }
            txtContractFound.Text = (_ContratcCounter).ToString();
            ContractSelected();

        }

        void ContractSelected()
        {
            if (_Processed == -1)
            {
                for (int i = 0; i < GRDBonusCommissioner.Rows.Count; i++)
                {

                    GRDBonusCommissioner.Rows[i].Cells["ContractQuantity"].Value = _ContratcCounter.ToString();
                }
            }


            BonusTotalSelected();
        }
        void BonusTotalSelected()
        {

            if (DGVAgreemetnResult.Rows.Count > 0)
            {
                for (int i = 0; i < GRDBonusCommissioner.Rows.Count; i++)
                {
                    GRDBonusCommissioner.Rows[i].Cells["Total"].Value = (Convert.ToDecimal(GRDBonusCommissioner.Rows[i].Cells["ContractQuantity"].Value) * Convert.ToDecimal(GRDBonusCommissioner.Rows[i].Cells["Amount"].Value)).ToString("C");

                }
            }
        }

        void TotalBonusPerContract()
        {
            nTotalBonustoContract = 0;
            if (GRDBonusCommissioner.Rows.Count > 0)
            {
                for (int i = 0; i < GRDBonusCommissioner.Rows.Count; i++)
                {
                    if (GRDBonusCommissioner.Rows[i].Cells["Total"].Value != null)
                    {
                        nTotalBonustoContract += Convert.ToDecimal(GRDBonusCommissioner.Rows[i].Cells["Total"].Value.ToString().Replace("$", ""));
                    }


                }

                txtTotalNeto.Text = nTotalBonustoContract.ToString("C");
            }
        }

        #endregion

        //***********************************************F.I.N******************************************************
        //***********************************************F.I.N******************************************************
        private void GRDBonusCommissioner_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SumAmount();
            TotalBonusPerContract();
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            if (GRDBonusCommissioner.RowCount > 0)
            {
                GRDBonusCommissioner.CurrentRow.Delete();
                SumAmount();
                TotalBonusPerContract();
            }

        }

        private void GRDBonusCommissioner_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Row == null)
            {
                return;
            }

            if (Convert.ToInt32(e.Row.Cells["ContractQuantity"].Value) > _ContratcCounter)
            {
                MessageBox.Show("The amount entered exceeds the number of contracts");
                e.Row.Cells["ContractQuantity"].Value = _ContratcCounter;
            }

            if (_SumaAmount > 300)
            {
                MessageBox.Show("The sum of the amount exceeds US$300");
                GRDBonusCommissioner.CurrentRow.Cells["Amount"].Value = _TempCellAmount.ToString("C");

            }
            BonusTotalSelected();
            TotalBonusPerContract();

        }



        private void DGVAgreemetnResult_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            DGVAgreemetnResultCheckBlock();

            ContractCount();

        }

        private void DGVAgreemetnResult_CellClick(object sender, GridViewCellEventArgs e)
        {
            //ContractCount();

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (_ContractSeach == null)
            {
                MessageBox.Show("Expired!");
                return;
            }
            if (_Processed == 1)
            {
                MessageBox.Show("AllReady Processed!");
                return;
            }
            ProcessBonus(5, 1, DateTime.Now);

        }

        private void GRDBonusCommissioner_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            _TempCellAmount = Convert.ToDecimal(e.Row.Cells["Amount"].Value);


        }
        private string CodeGenerate()
        {
            //Random rnd = new Random();

            ////--------------------------------------------GENERAMOS CODIGO-------------------------------------------------------------------------------
            //string Code = DateTime.Now.Hour + DateTime.Now.Month
            //   + DateTime.Now.Day
            //   + DateTime.Now.Year.ToString()
            //    + DateTime.Now.Second.ToString()
            //    + rnd.Next(DateTime.Now.Millisecond)
            //    ;

            var ticks = new DateTime(2016, 1, 1).Ticks;
            var ans = DateTime.Now.Ticks - ticks;
            string uniqueId = ans.ToString("x");

            //var n = Guid.NewGuid().ToString();
            //string base64Guid = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            //char[] ArrayCode = Code.ToArray();
            //string[] SplitedCode= Regex.Split(Code, Delimiter);
            //string[] SplitedCode;
            return uniqueId;
        }
        //-------------------------------------- PARA PINTAR LAS CELDAS DE ROJO EN CASO YA HALLA SIDO PROCESADAS----------------------------------
        //private void DGVAgreemetnResult_RowFormatting(object sender, RowFormattingEventArgs e)
        //{

        //    //if (Convert.ToBoolean(e.RowElement.RowInfo.Cells["Processed"].Value))
        //    //{
        //    //    e.RowElement.DrawFill = true;
        //    //    e.RowElement.GradientStyle = GradientStyles.Linear;
        //    //    e.RowElement.BackColor = Color.Red;
        //    //}
        //    //else
        //    //{
        //    //    e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
        //    //    e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
        //    //    e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
        //    //}
        //}

       //----***************************************P.R.I.N.T.I.N.G***************************************
        private void PrinBar(bool swith)
        {
            WaitingBar1.StopWaiting();
            WaitingBar1.Visible = swith;
        }
        //--------------------------------------------------------------------------------------------------
        private void ClearFields()
        {
            _BonusCommissionID = 0;
            _Code = string.Empty;
            DGVAgreemetnResult.DataSource = null;
            ViewStatedProcessedSaved();
            _Processed = -1;
            ClearGridCommissioner();
            btnApply.Enabled = false;
            _ListCommissionerInfo = null; _ContractSeach = null;
            btnPrint.Enabled = false;
            btnSave.Enabled = true;
            _SbBathAgreementID = null;
            btnReload.PerformClick();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            DateTime DateTex = DateTime.Now;
            dtpContractDate1.Text = DateTex.AddMonths(-1).ToString("MM-dd-yyyy");
            dtpContractDate2.Text = DateTex.ToString("MM-dd-yyyy");
            ClearFields();
        }

        //LIMPIAR EL GRID BONUS COMMISSIONER
        void ClearGridCommissioner()
        {
            GRDBonusCommissioner.Rows.AsEnumerable().ToList().ForEach(
             x =>
             {
                 x.Cells["Comment"].Value = string.Empty;
                 x.Cells["Total"].Value = 0;
                 x.Cells["ContractQuantity"].Value = 0;
             });
        }


        //---------------------------------------CODICO PARA EL TOOLTIP EN CELDAS SI ES NECESARIO----------------------
        //private void DGVAgreemetnResult_CellFormatting(object sender, CellFormattingEventArgs e)
        //{

        //    if (e.Row is GridViewDataRowInfo)
        //    {
        //        if (Convert.ToBoolean(e.Row.Cells["Processed"].Value))
        //        {
        //            e.CellElement.ToolTipText = "Processed Contract";
        //        }

        //    }
        //}
  
    
        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            if (_Processed > -1)
            {
                WaitingBar1.StartWaiting();
                WaitingBar1.Visible = true;
                PrintBCommissions eXPORT = new PrintBCommissions();
                DataSet Ds = SQLCMD.SQLdataSet($"Fx_BonusCommissionerMainReport {_BonusCommissionID}");
                eXPORT.PrintCrystal(_ContractSeach, Ds.Tables[0], Ds.Tables[1], false);

              
                PrinBar(_closedPrint);
      
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Processed == 1)
            {
                MessageBox.Show("AllReady Processed!");
                return;
            }
            else if (_Processed == 0)
            {
                return;
            }
            else
            {
                if (_SumaAmount > 300)
                {
                    MessageBox.Show("The sum of the amount exceeds US$300");
                    return;
                }
                ProcessBonus(1, 0);

                btnClear.PerformClick();
            }




        }
        //----------------------------------------------------------------function save or Procesed-----------------------------------
        public void ProcessBonus(int opc, int process, DateTime? processedDate = null)
        {
          
            if (DGVAgreemetnResult.Rows.Count <= 0)
            {
                MessageBox.Show("There are no contracts to process");
                return;
            }
   
            Authorization aauto = new Authorization();
            if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _AllowProcces = true;
            }
            else { return; }

            if (_AllowProcces)
            {

                try
                {
                   
                    //-------------------------------------------------------------------------------------------------------------------------------------------
                    //Int64 BonusCommissionID = 0;
                    StringBuilder SbBathCommissioner = new StringBuilder();
                    _SbBathAgreementID = new StringBuilder();

                    //---------------------------------------------------------------RECORRER AGREEMENTSID PARA INSERTARLO EN "SbBathAgreementID"----------------------------------------------------

                    DGVAgreemetnResult.Rows.AsEnumerable().ToList().ForEach(x =>
                     {
                         if (Convert.ToBoolean(x.Cells["Selected"].Value))
                         {
                             _SbBathAgreementID.Append($",{x.Cells["AgreementID"].Value}");
                         }
                     });


                    //----------------------------------------------------CONDICION SI ESTA PROCESANDO-----------------------------------------------------------------
                    if (opc == 5)
                    {
                        string BONUSCOMMISSIOControl = $"exec Sp_BONUSCOMMISSIONHISTORY {opc},'','','',''," +
                       $"'','',{_BonusCommissionID},{(Globalvariables.guserid == 0 ? 7 : Globalvariables.guserid)},{process},'{(processedDate)}'";
                        SQLCMD.SQLdata(BONUSCOMMISSIOControl);

                    }
                    else
                    {
                        string Code = CodeGenerate();
                        string BONUSCOMMISSIOControl = $"exec Sp_BONUSCOMMISSIONHISTORY {opc},'{Code}','{dtpContractDate1.Text}','{dtpContractDate2.Text}','{_SbBathAgreementID.ToString().Substring(1)}'," +
                                               $"{_ContratcCounter},{nTotalBonustoContract},0,{(Globalvariables.guserid == 0 ? 7 : Globalvariables.guserid)},{process},'{(processedDate)}'";
                        _BonusCommissionID = Convert.ToInt64(SQLCMD.SQLdata(BONUSCOMMISSIOControl).Rows[0][0]);

                    }
                    //-------------------------------------------------------------------------------------------------------------------------------------------

                    //---------------------------------SI LA OPCION ES 5( 5 = ACTUALIZAR A ESTADO PROCESADO) EVALUA SI VA A RECORRER EL DETALLE "BONUSCOMMISSIONER"--------------------------------------------------------------------------------------
                    if (opc != 5)
                    {
                        for (int i = 0; i < GRDBonusCommissioner.RowCount; i++)
                        {
                            SbBathCommissioner.Append($"exec Sp_BONUSCOMMISSIONHISTORYDetail {GRDBonusCommissioner.Rows[i].Cells["CommissionerID"].Value}," +
                                $"'{GRDBonusCommissioner.Rows[i].Cells["FullName"].Value}',{GRDBonusCommissioner.Rows[i].Cells["Amount"].Value}," +
                                $"{GRDBonusCommissioner.Rows[i].Cells["ContractQuantity"].Value},{_BonusCommissionID},'{GRDBonusCommissioner.Rows[i].Cells["Comment"].Value}',1;");
                        }
                        //-------------------------------------------------------------------------------------------------------------------------------------------

                        SQLCMD.SQLdata(SbBathCommissioner.ToString());
                    }
                    _AllowProcces = false;
                    DGVAgreemetnResult.DataSource = null;


                    if (opc != 5)
                    {
                        _Processed = 0;
                        btnPrint.Enabled = true;
                        BonnusCommissionerSP BCS = new BonnusCommissionerSP();
                        _ContractSeach = BCS.batchAgreements(1, string.Empty, string.Empty, _SbBathAgreementID.ToString().Substring(1));
                        btnPrint.PerformClick();

                    }
                    else
                    {
                        MessageBox.Show("Done");
                    }

                    btnClear.PerformClick();

                }
                catch (Exception ex)
                {
                    _AllowProcces = false;
                    MessageBox.Show(ex.Message);
                }

            }



        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            _ListCommissionerInfo = BCSP.LoadCommissioner().Where(x => x.Selected == 1).ToList();
            GRDBonusCommissioner.DataSource = null;
            GRDBonusCommissioner.DataSource=_ListCommissionerInfo;
            SumAmount();
            TotalBonusPerContract();
        }


        //----------------------------------------------------------------------------------------------------------------------------
    }
}
