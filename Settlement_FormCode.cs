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
using Telerik.WinControls.Styles;
using Telerik.WinControls.Data;

namespace Evolution.Forms
{
    public partial class Settlement : Form
    {
        public Settlement()
        {
            InitializeComponent();
        }
        DataView contractview = new DataView();
        DataView contractproccess = new DataView();
        DataView salesfloors = new DataView();
        DataView propertys = new DataView();
        DataView paymethod = new DataView();
        DataView settlementview = new DataView();
        DataView liquidarproperty = new DataView();
        General.Sqlcommandexecuter SQLCMD = new General.Sqlcommandexecuter();
        string currentdate = DateTime.Now.ToShortDateString(),ContractList="";
        decimal ProcessSettlement = 0;
        bool formatoCeldas = false;
        private void Settlement_Load(object sender, EventArgs e)
        {
            Fillcombos();
            General.GlobalAccess permiso = new General.GlobalAccess();
            permiso.permisomenucontectual(Menucontextual);
            permiso.groubox(radGroupBox5);
            permiso.groubox(radGroupBox7);
            permiso.groubox(radGroupBox4);
            Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
            Salesfloor.Text = ""; Property.Text = "";
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            Wait frmwait = new Wait();
            if (Salesfloorid.Text.Trim() == "") { MessageBox.Show("Missing Sales Floor", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); Salesfloorid.Focus(); return; }
            if (DateTime.Parse(Contractdate2.Text) > DateTime.Parse(currentdate)) { MessageBox.Show("Date is Bigger Than Current Date", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                formatoCeldas = true;
                radLabel8.Visible = true;
                Foundrecords.Visible = true;
               frmwait.Show(); frmwait.Refresh();
                Total.Text = "0.00"; Sales.Text = "0.00"; Closingtax.Text = "0.00";
                Searchcontract(0);

            }
            catch (Exception exc) { MessageBox.Show(exc.Message, Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { formatoCeldas = false; frmwait.Close(); }

            /*--------t-------------------------------------------------------------------------------------------------------------*/

        }
        private void Searchcontract(int option)
        {/*----------------------------Asignaciones y Validacion-------------------------------------------------------------*/
            int record = 0; if (option == 1) { record = GRDSETTLEMENT.CurrentRow.Index; }
            int agreementid = 0; if (record > 0) { agreementid = int.Parse( GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString());}
            string salesfloorid = "", propertyid = "", status = "", contractdate1 = "", paid = "0", OptionQuick="1";
            if (Salesfloorid.Text == "") { salesfloorid = "NULL"; } else { salesfloorid = Salesfloorid.Text; }
            if (Propertyid.Text == "") { propertyid = "NULL"; } else { propertyid = Propertyid.Text; }
            if (Contractdate1.Text == "") { contractdate1 = null; } else { contractdate1 = Contractdate1.Text; }
            if (Active.Checked == true) { status = status + "1"; } else { status = status + "0"; }
            if (Inactive.Checked == true) { status = status + "1"; } else { status = status + "0"; }
            if (Legal.Checked == true) { status = status + "1"; } else { status = status + "0"; }
            if (Hold.Checked == true) { status = status + "1"; } else { status = status + "0"; }
            if (Paid.Checked == true) { paid = "1"; } else { paid = "0"; }
            OptionQuick = ((Quick.Checked == true) ? "1" : "null"); 
            /*----------------------------------------------------------------------------------------------*/

            if (option == 0)
            {
                contractview = SQLCMD.SQLdata("LS_LIQUIDACIONVENTAS_L1 " + salesfloorid + ",'" + contractdate1 + "','" + Contractdate2.Text + "','" + Agreementnumber1.Text + "','" +
                Agreementnumber2.Text + "'," + option + ",'" + status + "'," + propertyid + "," + agreementid + "," + paid + ","+ OptionQuick + "").DefaultView;
                  FillGRDS(contractview,0,0,0);
            }
            else
            {
                agreementid = int.Parse(GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString());
                settlementview = SQLCMD.SQLdata("LS_LIQUIDACIONVENTAS_L1 " + salesfloorid + ",'" + contractdate1 + "','" + Contractdate2.Text + "','" + Agreementnumber1.Text + "','" +
                  Agreementnumber2.Text + "'," + option + ",'" + status + "'," + propertyid + "," + agreementid + "," + paid + "").DefaultView;
                TransactionSettlement(settlementview);
            }
            /*--------------------------------------------------------------------------------------------*/
        }
        private void TransactionSettlement(DataView DV)
        {
            GRDTRANSACTIONS.DataSource = DV;
        }
        private void FillGRDS(DataView DV, int agreementid1,double totalpagado,double totalcorrection)
        {
           
            GRDSETTLEMENT.Rows.Clear(); Foundrecords.Text = "0";
            progressBar1.Value = 0;
            progressBar1.Maximum = DV.Count;
            if (DV.Count <1) { MessageBox.Show("No Record Found",Application.CompanyName,MessageBoxButtons.OK,MessageBoxIcon.Information); radLabel8.Visible = false; Foundrecords.Visible = false; return; }
            /*--------------------------------------------------------------------------------------------------------------------------------------------*/
            Double netsales, closing, tax, distsales, distcctax, payment, paypercent, receibe, correction, salesttled, cctaxsettled, salesettle, cctaxsettle, pendingsales, pendingcctax;
               
           int record1 = 0; 
            /*-------------------------------------Editar cuando se pone un pago en Hold o se pone CN o DN en el formulario de paymentdetail-----------------------------*/
            if (agreementid1 > 0)
            { //select LS_PROPERTYSETTLEMENT(1,@salesfloorID int=17,@PropertyID int=17,@membresia money=10000,@pagado money=6500)
                DV.RowFilter = string.Format("agreementid = " + agreementid1 + "");
                double totalpaid = totalpagado - double.Parse(DV[record1]["closingcost"].ToString())- double.Parse(DV[record1]["tax"].ToString());
                liquidarproperty = SQLCMD.SQLdata("select DBO.LS_PROPERTYSETTLEMENT(1,"+ int.Parse(DV[record1]["salesfloor"].ToString()) + ","+ double.Parse(DV[record1]["netsales"].ToString()) + ","+ totalpaid + ")").DefaultView;
                DV.AllowEdit = true;
                DV[record1]["PAYMENTS_RECEIVED"] = totalpagado;
                DV[record1]["PAYMENTS_RECEIVED_PERC"] = ((totalpagado -double.Parse(DV[record1]["CLOSINGCOST"].ToString()) - double.Parse(DV[record1]["tax"].ToString())) / double.Parse(DV[record1]["netsales"].ToString())) *100;
                DV[record1]["Corrections"] = totalcorrection;
                DV[record1]["TOSETTLE_SALES"] = double.Parse(liquidarproperty[0][0].ToString());
                DV[record1]["ToSettle_taxcc"] = 0;
                DV[record1]["PENDIGTOSETTLE_SALES"] = 0;
                DV[record1]["PENDIGTOSETTLE_TAXCC"] = 0;
                DV[record1]["ar_clients"] = double.Parse(DV[record1]["netsales"].ToString()) + double.Parse(DV[record1]["CLOSINGCOST"].ToString()) + double.Parse(DV[record1]["tax"].ToString()) - totalpagado;
                DV[record1].EndEdit(); /*Fin de editar  */
            }
           
            /*-------------------------------------------------------------------------------------------------------------------------------------------------*/
            foreach (DataRowView record in DV)
            {/*----------------------------------------editar cada Fila-----------------------------------------------------------------------------------------*/
                progressBar1.Visible = true;
                progressBar1.Value = record1 +1;
                DV.AllowEdit = true; 
                // DV[record1]["tax"] = record1;
                /*----------------------------------Distribucion de membresia---------------------------------------------------------------------*/

                if (Convert.ToDouble(record["Dist_Membership"]) > 0) { DV[record1]["DISTRIBUTION_SALES"] = record["Dist_Membership"]; }
                else { DV[record1]["DISTRIBUTION_SALES"] = (Convert.ToDouble(record["PROPERTY_PERCENTAGE_AMOUNT"]) * Convert.ToDouble(record["netsales"])) / 100; }
                /*----------------------------------Distribucion de Tax---------------------------------------------------------------------*/

                if (Convert.ToDouble(record["TAX_PERCENTAGE"]) == 1 & Convert.ToDouble(record["Tax"]) > 0)
                { DV[record1]["DISTRIBUTION_TAXCC"] = (Convert.ToDouble(record["Tax"]) * Convert.ToDouble(record["TAX_VALUE"])) / 100; }
                else if (Convert.ToDouble(record["Tax"]) > 0) { DV[record1]["DISTRIBUTION_TAXCC"] = record["TAX_VALUE"]; }
                /*----------------------------------Distribucion de Closing Cost---------------------------------------------------------------------*/

                if (Convert.ToDouble(record["CC_PERCENTAGE"]) == 1 & Convert.ToDouble(record["ClosingCost"]) > 0)
                {
                    if (Convert.ToDouble(record["Tax"]) == 0) { DV[record1]["DISTRIBUTION_TAXCC"] = Convert.ToDouble(record["DISTRIBUTION_TAXCC"]) + Convert.ToDouble(record["Tax"]); }
                    else { DV[record1]["DISTRIBUTION_TAXCC"] = Convert.ToDouble(record["DISTRIBUTION_TAXCC"]) + (Convert.ToDouble(record["ClosingCost"]) * Convert.ToDouble(record["CC_Value"])) / 100; }
                }
                else if (Convert.ToDouble(record["ClosingCost"]) > 0)
                {
                    //if (Convert.ToDouble(record["Tax"]) == 0) { DV[record1]["DISTRIBUTION_TAXCC"] = Convert.ToDouble(record["DISTRIBUTION_TAXCC"]) + Convert.ToDouble(record["Tax"]); }
                    //else { DV[record1]["DISTRIBUTION_TAXCC"] = Convert.ToDouble(record["DISTRIBUTION_TAXCC"]) + (Convert.ToDouble(record["ClosingCost"]) * Convert.ToDouble(record["CC_Value"])) / 100; }
                    DV[record1]["DISTRIBUTION_TAXCC"] = Convert.ToDouble(record["DISTRIBUTION_TAXCC"]) + ((Convert.ToDouble(record["Tax"]) == 0) ? 0 : ((Convert.ToDouble(record["cc_value"]) <= 0) ? 0 : Convert.ToDouble(record["cc_value"])));
                    //RS!DISTRIBUTION_TAXCC = (RS!DISTRIBUTION_TAXCC) + IIf(RS!Tax = 0, 0, IIf(IsNull(RS!CC_Value), 0, RS!CC_Value))
                }
                if (Convert.ToDouble(record["Dist_CC_Tax"]) <= 0) { DV[record1]["DISTRIBUTION_TAXCC"] = DV[record1]["DISTRIBUTION_TAXCC"]; }
                else if (Convert.ToDouble(record["DISTRIBUTION_TAXCC"]) > 0) { DV[record1]["DISTRIBUTION_TAXCC"] = DV[record1]["Dist_CC_Tax"]; }
                else { DV[record1]["DISTRIBUTION_TAXCC"] = 0; }

                /*------------------------------To Settle Sales------------------------------------------------------------------*/
                if (Convert.ToDouble(record["Dist_Membership"]) <= 0)
                {
                    DV[record1]["TOSETTLE_SALES"] = Convert.ToDecimal(record["TOSETTLE_SALES"]) - Math.Abs(Convert.ToDecimal(record["SALES_SETTLED"]));
                }
                else
                {
                    DV[record1]["TOSETTLE_SALES"] = Convert.ToDouble(record["Dist_Membership"]) - Math.Abs(Convert.ToDouble(record["SALES_SETTLED"]));
                }

                /*-----------------------------To Settle Tax---------------------------------------------------------------------*/
                if (Convert.ToDouble(record["TAX_PERCENTAGE"]) == 1 & Convert.ToDouble(record["PAYMENTS_RECEIVED_PERC"]) >= Convert.ToDouble(record["TAX_SETTLEMENT_PERCENTAGE"]) & Convert.ToDouble(record["Tax"]) > 0)
                {
                    if (Convert.ToDouble(record["Dist_CC_Tax"]) <= 0)
                    {
                        DV[record1]["ToSettle_taxcc"] = (Convert.ToDouble(record["Tax"]) * Convert.ToDouble(record["TAX_VALUE"])) / 100;
                        DV[record1]["TaxToSettle"] = (Convert.ToDouble(record["Tax"]) * Convert.ToDouble(record["TAX_VALUE"])) / 100;/*Condicion para reporte semanal*/
                        // RS!ToSettle_taxcc = RS!Tax * (CCur(RS!TAX_VALUE) / 100)
                    }
                    else
                    {
                        DV[record1]["ToSettle_taxcc"] = ((Convert.ToDouble(record["TAX_SETTLED"]) - Convert.ToDouble(record["DISTRIBUTION_TAXCC"]) == 0) ? 0 : (Convert.ToDouble(record["TAX_SETTLED"])) - Convert.ToDouble(record["ToSettle_taxcc"])) + ((Convert.ToDouble(record["Dist_Tax"]) <= 0) ? Convert.ToDouble(record["ToSettle_taxcc"]) : Convert.ToDouble(record["Dist_Tax"]));
                        DV[record1]["TaxToSettle"] = ((Convert.ToDouble(record["TAX_SETTLED"]) - Convert.ToDouble(record["DISTRIBUTION_TAXCC"]) == 0) ? 0 : (Convert.ToDouble(record["TAX_SETTLED"])) - Convert.ToDouble(record["ToSettle_taxcc"])) + ((Convert.ToDouble(record["Dist_Tax"]) <= 0) ? Convert.ToDouble(record["ToSettle_taxcc"]) : Convert.ToDouble(record["Dist_Tax"]));/*Condicion para reporte semanal*/

                        // RS!ToSettle_taxcc = IIf(RS!TAX_SETTLED - RS!DISTRIBUTION_TAXCC = 0, 0, (CCur(RS!TAX_SETTLED)) - RS!ToSettle_taxcc + IIf(IsNull(RS!Dist_Tax), CCur(RS!ToSettle_taxcc), (RS!Dist_Tax)))
                    }

                }
                else 
                if (Convert.ToDouble(record["PAYMENTS_RECEIVED_PERC"]) >= Convert.ToDouble(record["TAX_SETTLEMENT_PERCENTAGE"]) & Convert.ToDouble(record["Tax"]) > 0)
                {
                    if (Convert.ToDouble(record["Dist_Tax"]) <= 0)
                    {
                        DV[record1]["ToSettle_taxcc"] = ((Convert.ToDouble(record["TAX_VALUE"]) <= 0) ? 0 : DV[record1]["TAX_VALUE"]);
                        DV[record1]["TaxToSettle"] = ((Convert.ToDouble(record["TAX_VALUE"]) <= 0) ? 0 : DV[record1]["TAX_VALUE"]); /*Condicion para reporte semanal*/
                        // RS!ToSettle_taxcc = IIf(IsNull(RS!TAX_VALUE), 0, RS!TAX_VALUE)
                    }
                    else
                    {
                        DV[record1]["ToSettle_taxcc"] = Convert.ToDouble(record["TAX_SETTLED"]) - Convert.ToDouble(record["ToSettle_taxcc"]) + ((Convert.ToDouble(record["Dist_CC"]) <= 0) ? Convert.ToDouble(record["ToSettle_taxcc"]) : Convert.ToDouble(record["Dist_CC"]));

                        DV[record1]["TaxToSettle"] = Convert.ToDouble(record["TAX_SETTLED"]) - Convert.ToDouble(record["ToSettle_taxcc"]) + ((Convert.ToDouble(record["Dist_CC"]) <= 0) ? Convert.ToDouble(record["ToSettle_taxcc"]) : Convert.ToDouble(record["Dist_CC"]));/*condicion para reporte semanal*/
                    
                    }
                    // RS!ToSettle_taxcc = (CCur(RS!TAX_SETTLED)) - RS!ToSettle_taxcc + IIf(IsNull(RS!Dist_CC), CCur(RS!ToSettle_taxcc), (RS!Dist_CC))

                }
                /*----------------------------------To Settle Closing Cost-----------------------------------------------------------------*/

                if (Convert.ToDouble(record["CC_PERCENTAGE"]) == 1 & (Convert.ToDouble(record["PAYMENTS_RECEIVED_PERC"]) >= Convert.ToDouble(record["CC_SETTLEMENT_PERCENTAGE"])
                    || Convert.ToDouble(record["PAYMENTS_RECEIVED"]) >= Convert.ToDouble(record["ClosingCost"])) & Convert.ToDouble(record["ClosingCost"]) > 0)
                {
                    if (Convert.ToDouble(record["Dist_CC_Tax"]) <= 0)
                    {

                        DV[record1]["ToSettle_taxcc"] = Convert.ToDouble(record["ToSettle_taxcc"]) + ((Convert.ToDouble(record["Tax"]) == 0) ? 0 : (Convert.ToDouble(record["ClosingCost"]) * Convert.ToDouble(record["CC_Value"])) / 100);
                        DV[record1]["ClosingToSettle"] =  ((Convert.ToDecimal(record["Tax"]) == 0) ? 0 : (Convert.ToDecimal(record["ClosingCost"]) * Convert.ToDecimal(record["CC_Value"])) / 100);/*condicion para report semanal*/
                        
                        // RS!ToSettle_taxcc = RS!ToSettle_taxcc + IIf(RS!Tax = 0, 0, RS!ClosingCost * CCur(RS!CC_Value) / 100)
                    }

                    else if (Convert.ToDouble(record["PAYMENTS_RECEIVED_PERC"]) >= Convert.ToDouble(record["TAX_SETTLEMENT_PERCENTAGE"]))
                    {

                        DV[record1]["ToSettle_taxcc"] = ((Convert.ToDouble(record["TAX_SETTLED"]) - Convert.ToDouble(record["DISTRIBUTION_TAXCC"]) == 0) ? 0 : Convert.ToDouble(record["ToSettle_taxcc"]) - Convert.ToDouble(record["TAX_SETTLED"]));
                        DV[record1]["ClosingToSettle"] = ((Convert.ToDecimal(record["TAX_SETTLED"]) - Convert.ToDecimal(record["DISTRIBUTION_TAXCC"]) == 0) ? 0 : Convert.ToDecimal(record["ClosingToSettle"]) - Convert.ToDecimal(record["TAX_SETTLED"]));/*condicion para report semanal*/

                        //RS!ToSettle_taxcc = IIf(RS!TAX_SETTLED - RS!DISTRIBUTION_TAXCC = 0, 0, RS!ToSettle_taxcc - (CCur(RS!TAX_SETTLED)))
                    }
                }

                /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
                else if ((Convert.ToDouble(record["PAYMENTS_RECEIVED_PERC"]) >= Convert.ToDouble(record["CC_SETTLEMENT_PERCENTAGE"])
                    || Convert.ToDouble(record["PAYMENTS_RECEIVED"]) >= Convert.ToDouble(record["ClosingCost"])) & Convert.ToDouble(record["ClosingCost"]) > 0)
                {
                    if (Convert.ToDouble(record["Dist_CC_Tax"]) <= 0)
                    {

                        DV[record1]["ToSettle_taxcc"] = Convert.ToDouble(record["ToSettle_taxcc"]) + ((Convert.ToDouble(record["Tax"]) == 0) ? 0 : ((Convert.ToDouble(record["CC_Value"]) <= 0) ? 0 : Convert.ToDouble(record["CC_Value"])));
                        DV[record1]["ClosingToSettle"] =  ((Convert.ToDecimal(record["Tax"]) == 0) ? 0 : ((Convert.ToDecimal(record["CC_Value"]) <= 0) ? 0 : Convert.ToDecimal(record["CC_Value"])));/*condicion para reporte semanal*/
                        
                        // RS!ToSettle_taxcc = RS!ToSettle_taxcc + IIf(RS!Tax = 0, 0, IIf(IsNull(RS!CC_Value), 0, RS!CC_Value))
                    }

                    else if (Convert.ToDouble(record["PAYMENTS_RECEIVED_PERC"]) >= Convert.ToDouble(record["TAX_SETTLEMENT_PERCENTAGE"]))
                    {
                        if (Convert.ToDouble(record["Dist_CC"]) <= 0)
                        {
                            DV[record1]["ToSettle_taxcc"] = Convert.ToDouble(record["TAX_SETTLED"]) - Convert.ToDouble(record["ToSettle_taxcc"]) + ((Convert.ToDouble(record["Dist_CC"]) <= 0) ? Convert.ToDouble(record["ToSettle_taxcc"]) : Convert.ToDouble(record["Dist_CC"]));
                            DV[record1]["ClosingToSettle"] = Convert.ToDecimal(record["TAX_SETTLED"]) - Convert.ToDecimal(record["ClosingToSettle"]) + ((Convert.ToDecimal(record["Dist_CC"]) <= 0) ? Convert.ToDecimal(record["ClosingToSettle"]) : Convert.ToDecimal(record["Dist_CC"]));/*condicion para reporte semanal*/

                            //RS!ToSettle_taxcc = (CCur(RS!TAX_SETTLED)) - RS!ToSettle_taxcc + IIf(IsNull(RS!Dist_CC), CCur(RS!ToSettle_taxcc), (RS!Dist_CC))
                        }

                    }
                }
                if (Convert.ToDouble(record["Dist_CC_Tax"]) <= 0)
                {
                    DV[record1]["ToSettle_taxcc"] = Convert.ToDouble(record["ToSettle_taxcc"]) - Convert.ToDouble(record["TAX_SETTLED"]);
                    //RS!ToSettle_taxcc = RS!ToSettle_taxcc - (CCur(RS!TAX_SETTLED))
                }

                /*--------------------------------------Pending To Settle Sales-----------------------------------------------------------------------------*/
                 DV[record1]["PENDIGTOSETTLE_SALES"] = decimal .Parse(record["DISTRIBUTION_SALES"].ToString()) - decimal.Parse(record["SALES_SETTLED"].ToString()) - decimal.Parse(record["TOSETTLE_SALES"].ToString());
               // MessageBox.Show(((double.Parse(record["DISTRIBUTION_SALES"].ToString()) - double.Parse(record["SALES_SETTLED"].ToString())) - double.Parse(record["TOSETTLE_SALES"].ToString())).ToString());
                if (Convert.ToDecimal(record["PENDIGTOSETTLE_SALES"]) < 0)
                {
                    DV[record1]["TOSETTLE_SALES"] = DV[record1]["PENDIGTOSETTLE_SALES"];
                    DV[record1]["PENDIGTOSETTLE_SALES"] = 0;
                }
                /*--------------------------------------Pending To Settle Tax + Closing Cost-----------------------------------------------------------------------------*/
                DV[record1]["PENDIGTOSETTLE_TAXCC"] = decimal.Parse (record["DISTRIBUTION_TAXCC"].ToString()) - decimal.Parse(record["TAX_SETTLED"].ToString()) - decimal.Parse(record["ToSettle_taxcc"].ToString());
                if (Convert.ToDecimal (record["PENDIGTOSETTLE_TAXCC"]) < 0)
                {
                    DV[record1]["ToSettle_taxcc"] = DV[record1]["PENDIGTOSETTLE_TAXCC"];
                    DV[record1]["PENDIGTOSETTLE_TAXCC"] = 0;
                }
                /*---------------------------si esta en hold poner el monto pending en cero -------------------------------------*/

                if (DV[record1]["Status_Description"].ToString() =="Hold") { DV[record1]["PENDIGTOSETTLE_SALES"] = 0; DV[record1]["PENDIGTOSETTLE_TAXCC"] = 0;  }

                /*------------------------------------cotejar fila si tiene monto a liquidar--------------------------------------------------------------------*/
                if (Convert.ToDouble(record["ToSettle_Sales"]) + Convert.ToDouble(record["ToSettle_taxcc"]) == 0)
                { DV[record1]["R"] = 0; }
                else { DV[record1]["R"] = 1; }
                /*------------------------------------Poner porciento pagado en cero si el valor es menor a cero---------------------------------------------------*/
                if (Convert.ToDouble(record["payments_received_perc"]) < 0) { DV[record1]["payments_received_perc"] = 0;  }
                /*------------------------------------Poner  en cero si el Netsales es menor o igual a cero---------------------------------------------------*/
                DV[record1]["ToSettle_taxcc"] = ((double.Parse (DV[record1]["netsales"].ToString())<=0)? 0 : double.Parse(DV[record1]["ToSettle_taxcc"].ToString()));
                /*---------------------------------------------------------------------------------------------------------------------------------------------*/
                // DV[record1]["netsales"] = Convert.ToDecimal (record["netsales"]).ToString("#,##0.00");

                DV[record1].EndEdit(); /*Fin de editar Fila */
                                       /*-------------------------------------Formato De los montos-------------------------------------------------------------------------------------------*/

                netsales = double.Parse(record["netsales"].ToString()); closing = double.Parse(record["closingcost"].ToString()); tax = double.Parse(record["tax"].ToString());
                distsales = double.Parse(record["distribution_sales"].ToString()); distcctax = double.Parse(record["distribution_taxcc"].ToString()); payment = double.Parse(record["payments_received"].ToString());
                paypercent = double.Parse(record["payments_received_perc"].ToString()); receibe = double.Parse(record["ar_clients"].ToString()); correction = double.Parse(record["corrections"].ToString());
                salesttled = double.Parse(record["Sales_Settled"].ToString()); cctaxsettled = double.Parse(record["Tax_Settled"].ToString()); salesettle = double.Parse(record["ToSettle_Sales"].ToString());
                cctaxsettle = double.Parse(record["ToSettle_taxcc"].ToString()); pendingsales = double.Parse(record["PENDIGTOSETTLE_SALES"].ToString()); pendingcctax = double.Parse(record["PENDIGTOSETTLE_TAXCC"].ToString());
                int Rselect = ((record["Status_Description"].ToString() == "Hold" & (salesettle + cctaxsettle) ==0)? 0 : int.Parse(record["R"].ToString()));

                /*------------------------------------Agregarle las filas al GridView---------------------------------------------------------------------------------*/

                GRDSETTLEMENT.Rows.Add(Rselect, record["agreementid"], record["agreementnumber"], netsales, closing, tax,
                    distsales, distcctax, payment, paypercent, receibe,
                    correction, salesttled, cctaxsettled, salesettle, cctaxsettle,
                   pendingsales, pendingcctax, record["EvoStatus"], record["MemberName"], record["Status_Description"], record["ContractDate"],
                   record["Upgrade"], record["UpgradePercent"], record["IncludeTax"], record["EXIT_PROGRAM"], record["seq"], record["salesfloor"], record["AccountStatus"],record["SettlementValidation"],record["UpDown_Grade"]);
                /*-------------------------------------pintar las filas de liquidaciones-------------------------------------------------------------*/
                if (Convert.ToInt32(GRDSETTLEMENT.Rows[record1].Cells["select"].Value) == 0) { GRDSETTLEMENT.Rows[record1].Cells["select"].ReadOnly = true; }
                if (GRDSETTLEMENT.Rows[record1].Cells["status"].Value.ToString() == "Hold") { GRDSETTLEMENT.Rows[record1].Cells["agreementnumber"].Style.ForeColor = Color.Red; }
                if (Convert.ToDecimal(GRDSETTLEMENT.Rows[record1].Cells["SettlementValidation"].Value.ToString()) >0 & Convert.ToDecimal(GRDSETTLEMENT.Rows[record1].Cells["Tosettlesales"].Value.ToString()) != 0)
                { GRDSETTLEMENT.Rows[record1].Cells["Tosettlesales"].Style.ForeColor = Color.Red; }
                if (Convert.ToDecimal(GRDSETTLEMENT.Rows[record1].Cells["SettlementValidation"].Value.ToString()) >0 & Convert.ToDecimal(GRDSETTLEMENT.Rows[record1].Cells["TosettleTaxClosing"].Value.ToString()) != 0)
                { GRDSETTLEMENT.Rows[record1].Cells["TosettleTaxClosing"].Style.ForeColor = Color.Red; }
                if (GRDSETTLEMENT.Rows[record1].Cells["UpDown_Grade"].Value.ToString() != "") { GRDSETTLEMENT.Rows[record1].Cells["NetSales"].Style.ForeColor = Color.Blue; }

                /*----------------------------------Borrar cuando este liquidado---------------------------------------------*/

                if (Settled.Checked == false)
                {
                    if (double.Parse(record["ToSettle_Sales"].ToString()) + double.Parse(record["ToSettle_taxcc"].ToString()) == 0)
                    {
                        if (double.Parse(record["ToSettle_Sales"].ToString()) + double.Parse(record["ToSettle_taxcc"].ToString()) + double.Parse(record["PENDIGTOSETTLE_SALES"].ToString())
                            + double.Parse(record["PENDIGTOSETTLE_TAXCC"].ToString()) == 0 & record["Status_Description"].ToString() != "Hold")
                        {
                            DV.AllowDelete = true; DV[record1].Delete();
                            record1 = record1 - 1;
                        }
                    }
                    
               }
                /*------------------------------------Borrar cuando no se este pagando-------------------------------------------------------------*/
                //if (Paid.Checked == false)
                //{
                //    if ( double.Parse(record["Sales_Settled"].ToString()) + double.Parse(record["Tax_Settled"].ToString()) >0)
                //    {

                //        DV.AllowDelete = true; DV[record1].Delete();
                //        record1 = record1 - 1;
                //    }

                //}
                /*----------------------------------------------------------------------------------------------------------------------------------*/
               
                record1 += 1;
            }
          
            GRDSETTLEMENT.Rows[0].IsCurrent = true;
           // RecordFound1.Visible = false;
            /*-----------------------------------------------------------------------------*/
            if (agreementid1 > 0 || Settled.Checked == false){ Findname.Text = ((DV.Count ==0)? "XXXX" : DV[record1 -1]["agreementnumber"].ToString()); Findname.Text = ""; }
            if(DV.Count == 0) { GRDSETTLEMENT.Rows.Clear(); }
            // GRDSETTLEMENT.Rows[0].Cells["select"].ReadOnly = true; //funciona
            grandtotalaliquidar();/*sumatoria de lo que se va a liquidar*/
            Foundrecords.Text = DV.Count.ToString();
            progressBar1.Value = ((progressBar1.Value < progressBar1.Maximum )? progressBar1.Maximum : progressBar1.Value  );
            progressBar1.Visible = false;
            
        }

        private void GRDSETTLEMENT_CellPaint(object sender, GridViewCellPaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Salesfloorid_TextChanged(object sender, EventArgs e)
        {
            if (Salesfloorid.TextLength >= 2)
            { SalesfloorID1.Text = Salesfloorid.Text; Propertyid.SelectionStart = 0;
                Propertyid.SelectionLength = Propertyid.Text.Length; Propertyid.Focus();  Salesfloor.SelectedValue = Convert.ToInt32(Salesfloorid.Text);
            }
        }

        private void Propertyid_TextChanged(object sender, EventArgs e)
        {
            if (Propertyid.TextLength >= 2)
            { PropertyID1.Text = Propertyid.Text; Agreementnumber1.Focus(); Property.SelectedValue = Convert.ToInt32(Propertyid.Text); }
        }

        private void Agreementnumber1_TextChanged(object sender, EventArgs e)
        {
            Agreementnumber2.Text = Agreementnumber1.Text;
        }
        private void Fillcombos()
        {
           salesfloors = SQLCMD.SQLdata("sp_l_salesfloor '2','0',''").DefaultView;
            Salesfloor.DataSource = salesfloors;
            Salesfloor.DisplayMember = "name";
            Salesfloor.ValueMember = "Id";
            propertys = SQLCMD.SQLdata("sp_l_Property '4','0',' '").DefaultView;
            Property.DataSource = propertys;
            Property.DisplayMember = "commonName";
            Property.ValueMember = "Id";
            paymethod = SQLCMD.SQLdata("SP_L_paymenttype 1,0,null").DefaultView;
            Paymentmethod.DataSource = paymethod;
            Paymentmethod.DisplayMember = "Description";
            Paymentmethod.ValueMember = "ID";
            /*--------------------------------------------------------*/
        }
        private void bClear_Click(object sender, EventArgs e)
        {
            Salesfloorid.Text = "";
            Propertyid.Text = "";
            Agreementnumber1.Text = "";
            Agreementnumber2.Text = "";
             Contractdate1.SetToNullValue();
            Contractdate2.Text = DateTime.Now.ToShortDateString();
            Salesfloor.Text = "";
            Property.Text = "";
            Salesfloorid.Focus();
        }

        private void Settlement_Activated(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            // bClear.PerformClick();
            if (this.WindowState == FormWindowState.Normal) { this.WindowState = FormWindowState.Maximized; }
            Salesfloorid.Focus();
            Paymentmethod.Text = "";
            Applicationdate.SetToNullValue();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
            //Wait wwwt = new Wait();
            //wwwt.TopMost = true;
            //wwwt.Show();
           
        }

        private void Findname_TextChanged(object sender, EventArgs e)
        {
            if (contractview.Count <1) { Findname.Text = ""; return;   }
            try
            {
                contractview.RowFilter = string.Format("MemberName+agreementnumber like '%" + Findname.Text.Trim() + "%'");
                GRDSETTLEMENT.Rows.Clear();
                Double netsales, closing, tax, distsales, distcctax, payment, paypercent, receibe, correction, salesttled, cctaxsettled, salesettle, cctaxsettle, pendingsales, pendingcctax;
                 int record1=0,select=0;
                foreach (DataRowView record in contractview)
                {
                    /*-------------------------------------Formato De los montos-------------------------------------------------------------------------------------------*/

                    netsales = double.Parse(record["netsales"].ToString()); closing = double.Parse(record["closingcost"].ToString()); tax = double.Parse(record["tax"].ToString());
                    distsales = double.Parse(record["distribution_sales"].ToString()); distcctax = double.Parse(record["distribution_taxcc"].ToString()); payment = double.Parse(record["payments_received"].ToString());
                    paypercent = double.Parse(record["payments_received_perc"].ToString()); receibe = double.Parse(record["ar_clients"].ToString()); correction = double.Parse(record["corrections"].ToString());
                    salesttled = double.Parse(record["Sales_Settled"].ToString()); cctaxsettled = double.Parse(record["Tax_Settled"].ToString()); salesettle = double.Parse(record["ToSettle_Sales"].ToString());
                    cctaxsettle = double.Parse(record["ToSettle_taxcc"].ToString()); pendingsales = double.Parse(record["PENDIGTOSETTLE_SALES"].ToString()); pendingcctax = double.Parse(record["PENDIGTOSETTLE_TAXCC"].ToString());
                    select = ((record["Status_Description"].ToString() == "Hold" & (salesettle + cctaxsettle) ==0) ? 0 : int.Parse(record["R"].ToString()));
                    /*------------------------------------Agregarle las filas al GridView---------------------------------------------------------------------------------*/

                    GRDSETTLEMENT.Rows.Add(/*record["R"]*/select, record["agreementid"], record["agreementnumber"], netsales, closing, tax,
                        distsales, distcctax, payment, paypercent, receibe,
                        correction, salesttled, cctaxsettled, salesettle, cctaxsettle,
                       pendingsales, pendingcctax, record["EvoStatus"], record["MemberName"], record["Status_Description"], record["ContractDate"],
                       record["Upgrade"], record["UpgradePercent"], record["IncludeTax"], record["EXIT_PROGRAM"], record["seq"], record["salesfloor"], record["AccountStatus"], record["SettlementValidation"], record["UpDown_Grade"]);
                    /*--------------------------------------------------------------------------------------------------*/
                    if (Convert.ToInt32(GRDSETTLEMENT.Rows[record1].Cells["select"].Value) == 0) { GRDSETTLEMENT.Rows[record1].Cells["select"].ReadOnly = true; }
                    if (GRDSETTLEMENT.Rows[record1].Cells["status"].Value.ToString() == "Hold") { GRDSETTLEMENT.Rows[record1].Cells["agreementnumber"].Style.ForeColor = Color.Red; }
                    if (GRDSETTLEMENT.Rows[record1].Cells["UpDown_Grade"].Value.ToString() != "") { GRDSETTLEMENT.Rows[record1].Cells["Netsales"].Style.ForeColor = Color.Blue; }
                    /*--------------------------------------------------------------------------------------------------*/
                    record1 += 1;
                }
                GRDSETTLEMENT.Rows[0].IsCurrent = true;
                grandtotalaliquidar();/*sumatoria de lo que se va a liquidar*/
            }
            catch (Exception ecx) { MessageBox.Show("Record No found",Application.CompanyName,MessageBoxButtons.OK,MessageBoxIcon.Error); Findname.Focus(); }
            finally { contractview.RowFilter = ""; }
        }

        private void bProcess_Click(object sender, EventArgs e)
        {/*----------------------------Asignaciones y Validacion-------------------------------------------------------------*/
            int onerow = 0; double amoutsales = 0, amoutcctax = 0;
            String AppDate = "";
            if(GRDSETTLEMENT.Rows.Count < 1) { MessageBox.Show("No Contracts In The List",Application.CompanyName,MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            /*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
            for(int row1=0; row1<= GRDSETTLEMENT.RowCount -1; row1++)
            {
                if (int.Parse(GRDSETTLEMENT.Rows[row1].Cells["select"].Value.ToString()) == 1)
                {
                    onerow = onerow + int.Parse(GRDSETTLEMENT.Rows[row1].Cells["select"].Value.ToString());
                    amoutsales = double.Parse(GRDSETTLEMENT.Rows[row1].Cells["tosettlesales"].Value.ToString());
                    amoutcctax = double.Parse(GRDSETTLEMENT.Rows[row1].Cells["tosettletaxclosing"].Value.ToString());
                }
            }
            if (onerow == 0) { MessageBox.Show("Nothing To Process", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            /*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
            string OldDate = "01-01-1990";
            //if (int.Parse(GRDSETTLEMENT.Rows[record].Cells["Select"].Value.ToString()) == 0) { MessageBox.Show("Nothing To Process", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Paymentmethod.Text == "") { MessageBox.Show("Select Payment Type", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); Paymentmethod.Focus();  return; }
            if (Applicationdate.Text.Trim() == "") { MessageBox.Show("Select Application Date", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); Applicationdate.Focus(); return; }
            if (DateTime.Parse(Applicationdate.Text) > DateTime.Parse(currentdate)) { MessageBox.Show("Date is Bigger Than Current Date", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Reference.Text.Trim() == "") { MessageBox.Show("Type The Reference", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); Reference.Focus(); return; }
            if (Sales.Text.Trim() == "") { MessageBox.Show("Sales Amount Required", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); Sales.Focus(); return; }
            if (Closingtax.Text.Trim() == "") { MessageBox.Show("Closing + Tax Amount Required", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); Closingtax.Focus(); return; }
            AppDate = Applicationdate.Text;
            if (DateTime.Parse(Applicationdate.Text)> DateTime.Parse(Contractdate2.Text) || DateTime.Parse(Applicationdate.Text) < ((Contractdate1.Text =="")? DateTime.Parse(OldDate) :DateTime.Parse(Contractdate1.Text)))
            {
                if (MessageBox.Show("Application Date is Out Of Searching Date Range \n Do you Want To Continue ? ", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) { return; }
            }
            /*----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
            string salesfloorid = "", propertyid = "", contractdate1 = "", option = "0";
            if (Salesfloor.Text == "") { salesfloorid = "NULL"; } else { salesfloorid = Salesfloor.SelectedValue.ToString(); }
            if (Property.Text == "") { propertyid = "NULL"; } else { propertyid = Property.SelectedValue.ToString(); }
            if (Contractdate1.Text == "") { contractdate1 = null; } else { contractdate1 = Contractdate1.Text; }
            if (onerow > 1) { grandtotalaliquidar(); }
           if(double.Parse(Sales.Text)+double.Parse(Closingtax.Text) == 0) { MessageBox.Show("Cannot Process When Total is Zero", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning);  return; }
            if(onerow == 1)
            { if(amoutsales < double.Parse(Sales.Text)) { MessageBox.Show("amount to settle is bigger than available", Application.CompanyName,MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
                if (amoutcctax < double.Parse(Closingtax.Text)) { MessageBox.Show("amount to settle is bigger than available", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }
            /*--------------------------------------------------------------------------------------------------------------------------------------------*/
            SettlementsValidation();
            if (ProcessSettlement > 0) 
            {
                if (MessageBox.Show("one or more contracts have payment already processed \n "+ContractList+"\n Do You Want To Continue ?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
            }
            if (MessageBox.Show("Confirm Process ?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No) { return; }
            /*--------------------------------Proccess Settlement--------------------------------------------------------------*/
            contractproccess = SQLCMD.SQLdata("LS_M_CHECKHISTORY_2 "+ salesfloorid + ",'"+ contractdate1 + "','"+Contractdate2.Text+"','"+Agreementnumber1.Text+"','"+
                Agreementnumber2.Text +"','"+Reference.Text+"',"+ option + ",0,"+ Paymentmethod.SelectedValue +","+General.Globalvariables.guserid+",0,"+
               double.Parse( Sales.Text) +","+double.Parse(Closingtax.Text)+",0,0,'"+ AppDate + "'").DefaultView;
            if(contractproccess.Count < 1) { return; }
            int checkhistoryID = Convert.ToInt32( contractproccess.Table.Rows[0]["ID_CHECKHISTORY"].ToString());
            /*------------------------Recorrer todos los contractos cotejado para procesarlos----------------------------------------------*/
            int agreementid,selected;
            string SQLstrn = ""; Double saletosettle, cctaxtosettle, saletosettlex1, cctaxtosettlex1;

            for (int record3=0; record3 <= GRDSETTLEMENT.RowCount -1; record3++)
            {
                selected = int.Parse(GRDSETTLEMENT.Rows[record3].Cells["select"].Value.ToString());
                if (selected == 1)
                {
                    agreementid = Convert.ToInt32(GRDSETTLEMENT.Rows[record3].Cells["agreementid"].Value.ToString());
                    saletosettle = Convert.ToDouble(GRDSETTLEMENT.Rows[record3].Cells["tosettlesales"].Value.ToString());
                    cctaxtosettle = Convert.ToDouble(GRDSETTLEMENT.Rows[record3].Cells["tosettletaxclosing"].Value.ToString());
                    SQLstrn = SQLstrn + " " + "EXEC LS_M_CHECKHISTORYDETAIL1 " + checkhistoryID + "," + saletosettle + "," + cctaxtosettle + "," + agreementid + "";
                    /*------------------------------------------------------------------------------------------------------------------------------------*/
                    saletosettlex1 = ((onerow > 1)? saletosettle : double.Parse(Sales.Text));
                    cctaxtosettlex1 = ((onerow > 1)? cctaxtosettle : double.Parse(Closingtax.Text));
                    UpdateProcessedRecord(agreementid, saletosettlex1, cctaxtosettlex1);
                }
            }
            contractproccess = SQLCMD.SQLdata(SQLstrn).DefaultView;
            // Searchcontract(1);/*buscar la transaciones de liquidacion procesada*/
            contractview.RowFilter = "";
            Findname.Text = "-";
            Findname.Text = "";
            grandtotalaliquidar();
            //UpdateProcessedRecord();
            MessageBox.Show("Done",Application.CompanyName,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void GRDSETTLEMENT_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GRDSETTLEMENT.Rows.Count < 1) { MessageBox.Show("No Contracts In The List", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            AgreementIDView.Text = GRDSETTLEMENT.CurrentRow.Cells["AgreementID"].Value.ToString();
            Authorization aauto = new Authorization();
            if (e.ColumnIndex ==0)
            {
               // MessageBox.Show("test click");
                if (GRDSETTLEMENT.CurrentRow.Cells["select"].Value.ToString() =="1" || double.Parse(GRDSETTLEMENT.CurrentRow.Cells["tosettlesales"].Value.ToString()) + double.Parse(GRDSETTLEMENT.CurrentRow.Cells["tosettletaxclosing"].Value.ToString()) !=0)//tosettletaxclosing
                {

                    if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        GRDSETTLEMENT.CurrentRow.Cells["select"].ReadOnly = false;
                        contractview.RowFilter = string.Format("agreementid = "+ int.Parse(GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString()) + "");
                        contractview.AllowEdit = true;

                        contractview[0]["R"] = ((int.Parse(GRDSETTLEMENT.CurrentRow.Cells["select"].Value.ToString()) == 1)? 0 : 1);
                        contractview[0].EndEdit();
                        contractview.RowFilter = "";
                        GRDSETTLEMENT.CurrentRow.Cells["select"].Value = ((int.Parse(GRDSETTLEMENT.CurrentRow.Cells["select"].Value.ToString()) == 1) ? 0 : 1);
                        GRDSETTLEMENT.CurrentRow.Cells["select"].ReadOnly = true;
                        grandtotalaliquidar();
                    }

                }
                /*sumatoria de lo que se va a liquidar*/
                //Sales.Text = double.Parse(Sales.Text) + GRDSETTLEMENT.Rows[record].Cells["tosettlesales"].Value.ToString();
                //Closingtax.Text = double.Parse(Closingtax.Text) + GRDSETTLEMENT.Rows[record].Cells["tosettletaxclosing"].Value.ToString();
                //double totalsum = Convert.ToDouble(Sales.Text) + Convert.ToDouble(Closingtax.Text);
                //Total.Text = double.Parse(Sales.Text).ToString() + double.Parse(Closingtax.Text).ToString(); //Menucontextual.Visible = true;
            }
            
        }

        private void holdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.Rows.Count < 1) { MessageBox.Show("No Contracts In The List", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            HoldSettlement hold = new HoldSettlement();
           
           // int record = GRDSETTLEMENT.CurrentRow.Cells[""].Value
            hold.agreementid = GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString();
            hold.agreementnumber = GRDSETTLEMENT.CurrentRow.Cells["agreementnumber"].Value.ToString();
            hold.membername = GRDSETTLEMENT.CurrentRow.Cells["name"].Value.ToString();
            if(hold.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                contractview.RowFilter = string.Format("agreementid =" + GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString() + "");
                contractview.AllowEdit = true;
                double amounttosettle = double.Parse(GRDSETTLEMENT.CurrentRow.Cells["tosettlesales"].Value.ToString()) + double.Parse(GRDSETTLEMENT.CurrentRow.Cells["tosettletaxclosing"].Value.ToString());
                contractview[0]["R"] = ((int.Parse(GRDSETTLEMENT.CurrentRow.Cells["Select"].Value.ToString()) == 1) ? 0 : ((amounttosettle > 0)? 1 : 0));
                contractview[0]["Status_Description"] = ((GRDSETTLEMENT.CurrentRow.Cells["status"].Value.ToString() == "Hold")? "Active" : "Hold");
                contractview[0].EndEdit();
                contractview.RowFilter = "";
                Findname.Text = GRDSETTLEMENT.CurrentRow.Cells["agreementnumber"].Value.ToString();
                Findname.Text = "";
                grandtotalaliquidar();
            }
        }

        private void paymentDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.Rows.Count < 1) { MessageBox.Show("No Contracts In The List", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            PaymentDetail paydetail = new PaymentDetail();
            // int record = GRDSETTLEMENT.CurrentRow.Index;
            decimal totalpaid1 = 0,AccountReceivable1=0;
            paydetail.datecreate = Contractdate2.Text;
            totalpaid1 = decimal.Parse (GRDSETTLEMENT.CurrentRow.Cells["paymentreceived"].Value.ToString());
            AccountReceivable1 = decimal.Parse(GRDSETTLEMENT.CurrentRow.Cells["accountreceive"].Value.ToString());
            paydetail.Controls["radGroupBox2"].Controls["AgreementNumber"].Text = GRDSETTLEMENT.CurrentRow.Cells["agreementnumber"].Value.ToString();
            paydetail.Controls["radGroupBox2"].Controls["Membername"].Text = GRDSETTLEMENT.CurrentRow.Cells["name"].Value.ToString();
            paydetail.Controls["radGroupBox2"].Controls ["TotalPaid1"].Text = totalpaid1.ToString("#,##0.00");
            paydetail.Controls["AccountReceivable"].Text = AccountReceivable1.ToString("#,##0.00");
            paydetail.agreementid = GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString();
           if( paydetail.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {   int agreementid11 = int.Parse(GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString());
                //MessageBox.Show(paydetail.sumatoria.ToString() +" CN "+paydetail.totalcorrection.ToString());
                FillGRDS(contractview, agreementid11, paydetail.sumatoria, paydetail.totalcorrection);
            }
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts To Process",Application.CompanyName,MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
           // int record = GRDSETTLEMENT.CurrentRow.Index;
            
            if (int.Parse( GRDSETTLEMENT.CurrentRow.Cells["Select"].Value.ToString()) ==0) { MessageBox.Show("Nothing To Process", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
           // if(Paymentmethod.Text =="" ) { MessageBox.Show("Select Payment Method", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            //if ( Reference.Text.Trim() == "") { MessageBox.Show("Type Reference", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            ProcessContracts prcess = new ProcessContracts();
            prcess.agrementnumber = GRDSETTLEMENT.CurrentRow.Cells["agreementnumber"].Value.ToString();
            prcess.SettlementValidation = double.Parse( GRDSETTLEMENT.CurrentRow.Cells["SettlementValidation"].Value.ToString());
            prcess.reference = Reference.Text;
            prcess.paymentmethod = ((Paymentmethod.Text.Trim() == "") ? "0" : Paymentmethod.SelectedValue.ToString()); 
            prcess.sales = double.Parse( GRDSETTLEMENT.CurrentRow.Cells["tosettlesales"].Value.ToString());
            prcess.closing_tax = double.Parse(GRDSETTLEMENT.CurrentRow.Cells["tosettletaxclosing"].Value.ToString());
            prcess.salesfloorid = GRDSETTLEMENT.CurrentRow.Cells["salesfloorid"].Value.ToString();
            prcess.contractdate1 = ((Contractdate1.Text=="")?"01-01-1990": Contractdate1.Text);
            prcess.contractdate2 = Contractdate2.Text;
            prcess.agreementid = GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString();
            if ( prcess.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Searchcontract(1);
                UpdateProcessedRecord(int.Parse(GRDSETTLEMENT.CurrentRow.Cells["agreementid"].Value.ToString()),prcess.xsales,prcess.xcctax);
                contractview.RowFilter = "";
                Findname.Text = GRDSETTLEMENT.CurrentRow.Cells["agreementnumber"].Value.ToString();
                Findname.Text = "";
                grandtotalaliquidar();
            }
        }

        private void viewContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List",Application.CompanyName,MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
          //  int record = GRDSETTLEMENT.CurrentRow.Index;
            ContractSequence seqcontract = new ContractSequence();
            seqcontract.action = "1";
            seqcontract.AN = GRDSETTLEMENT.CurrentRow.Cells["agreementnumber"].Value.ToString();
            seqcontract.MdiParent = MdiParent;
            seqcontract.Show();
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
            if(e.KeyChar == 13) { Agreementnumber2.Focus(); }
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Agreementnumber2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { bSearch.PerformClick(); }
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumerosentero(e);
        }

        private void Sales_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void Closingtax_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.ValidarTexbox justnumber = new General.ValidarTexbox();
            justnumber.Solonumeros(e);
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            
            Wait wwt = new Wait();
            Authorization aauto = new Authorization();
            try
            {
                int option = 0, action1 = 0, agreementid, IDcheckhistory, salesfloorid, idcheckhistorydetail; string sqlquery = "", reference = "";
                double amoutsales, amountcctax;
                
                if (bSamereference.IsChecked == true)
                {
                    action1 = 1;
                     if (Comment.Text.Trim() == "") { MessageBox.Show("Reference Is Required", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); Comment.Focus(); return; }
                    /*------------------------Validar si existe la referencia---------------------------*/
                    int salesfloorx1 = ((SalesfloorID1.Text.Trim() =="")? 0 : int.Parse(SalesfloorID1.Text));
                    settlementview = SQLCMD.SQLdata("LS_M_CHECKHISTORY_2 "+ salesfloorx1 + ",null,null,null,null,'"+Comment.Text.Trim()+ "',4,null,null,null,null,null,null").DefaultView;
                    if (settlementview.Count <1) { MessageBox.Show("This Reference Does Not Exist", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    /*------------------------------------------------------------------------------------------------*/
                    option = 2;
                    if (SalesfloorID1.Text.Trim() == "" || PropertyID1.Text.Trim()=="")
                    {
                        action1 = 2;
                        if (MessageBox.Show("Warning Salesfloor and Property No Include \n All Transactions With this Reference will be Undone. Continue ?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        { return; }
                    }else { if (MessageBox.Show("Confirm Undo", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; } }
                    //for (record = 0; record <= GRDTRANSACTIONS.RowCount - 1; record++)
                    //{
                    salesfloorid = ((SalesfloorID1.Text.Trim()=="")? 0 : int.Parse(SalesfloorID1.Text.Trim()));// int.Parse(GRDTRANSACTIONS.Rows[record].Cells["salesfloorID"].Value.ToString());
                        IDcheckhistory = 0;// int.Parse(GRDTRANSACTIONS.Rows[record].Cells["ID"].Value.ToString());
                        idcheckhistorydetail = 0;// int.Parse(GRDTRANSACTIONS.Rows[record].Cells["checkhistorydetailID"].Value.ToString());
                        agreementid = 0;// int.Parse(GRDTRANSACTIONS.Rows[record].Cells["agreementid"].Value.ToString());
                        //reference = GRDTRANSACTIONS.Rows[record].Cells["reference"].Value.ToString().Trim(); 
                        
                        //if (reference == Comment.Text.Trim())
                        //{
                            /*-----------------------------------------------------------------------------------------------------------*/
                            sqlquery = sqlquery +" "+ "EXEC LS_M_CHECKHISTORY_2 " + salesfloorid + ",null,null,null,null,'" + Comment.Text + "'," + option + ",null,null," + General.Globalvariables.guserid + "," +
                                IDcheckhistory + ",null,null," + idcheckhistorydetail + "," + agreementid + ",null,"+ action1 + "";
                            /*-------------------------------------------------------------------------------------------------------------------*/
                            //amoutsales = double.Parse(GRDTRANSACTIONS.Rows[record].Cells["salessettled"].Value.ToString());
                            //amountcctax = double.Parse(GRDTRANSACTIONS.Rows[record].Cells["closingtaxsettled"].Value.ToString());
                            //contractview.RowFilter = string.Format("agreementid =" + agreementid + "");
                            //contractview.AllowEdit = true;
                            //contractview[0]["R"] = 1;
                            //contractview[0]["sales_settled"] = double.Parse(contractview[0]["sales_settled"].ToString()) - amoutsales;
                            //contractview[0]["tax_settled"] = double.Parse(contractview[0]["tax_settled"].ToString()) - amountcctax;
                            //contractview[0]["TOSETTLE_SALES"] = double.Parse(contractview[0]["TOSETTLE_SALES"].ToString()) + amoutsales;
                            //contractview[0]["ToSettle_taxcc"] = double.Parse(contractview[0]["ToSettle_taxcc"].ToString()) + amountcctax;
                            //contractview[0].EndEdit();
                        //}
                        /*-----------------------------------------------------------------------------------------------------------------------*/
                   // }

                }
                /*----------------------------------------------------------------------------------------------------------------------------------------*/
                if (bCurrent.IsChecked == true)
                {
                    if (GRDTRANSACTIONS.Rows.Count < 1) { MessageBox.Show("No Transaction In The List", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                   // if (Comment.Text.Trim() == "") { MessageBox.Show("Reference Is Required", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); Comment.Focus(); return; }
                    option = 3;
                   // record = GRDTRANSACTIONS.CurrentRow.Index;
                    salesfloorid = int.Parse(GRDTRANSACTIONS.CurrentRow.Cells["salesfloorID"].Value.ToString());
                   // reference = GRDTRANSACTIONS.Rows[record].Cells["reference"].Value.ToString().Trim();
                    IDcheckhistory = int.Parse(GRDTRANSACTIONS.CurrentRow.Cells["ID"].Value.ToString());
                    idcheckhistorydetail = int.Parse(GRDTRANSACTIONS.CurrentRow.Cells["checkhistorydetailID"].Value.ToString());
                    agreementid = int.Parse(GRDTRANSACTIONS.CurrentRow.Cells["agreementid"].Value.ToString());
                    /*-----------------------------------------------------------------------------------------------------------------*/
                  //  if(Comment.Text.Trim() != reference) { MessageBox.Show("Reference is Different",Application.CompanyName,MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
                    if (MessageBox.Show("Confirm Undo", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) { return; }
                    /*-----------------------------------------------------------------------------------------------------------------*/
                    sqlquery = sqlquery + " LS_M_CHECKHISTORY_2 " + salesfloorid + ",null,null,null,null,null," + option + ",null,null," + General.Globalvariables.guserid + "," +
                        IDcheckhistory + ",null,null," + idcheckhistorydetail + "," + agreementid + ",null";
                    /*-------------------------------------------------------------------------------------------------------------------*/
                    amoutsales = double.Parse(GRDTRANSACTIONS.CurrentRow.Cells["salessettled"].Value.ToString());
                    amountcctax = double.Parse(GRDTRANSACTIONS.CurrentRow.Cells["closingtaxsettled"].Value.ToString());
                    contractview.RowFilter = string.Format("agreementid =" + agreementid + "");
                    contractview.AllowEdit = true;
                    contractview[0]["R"] = 1;
                    contractview[0]["sales_settled"] = double.Parse(contractview[0]["sales_settled"].ToString()) - amoutsales;
                    contractview[0]["tax_settled"] = double.Parse(contractview[0]["tax_settled"].ToString()) - amountcctax;
                    contractview[0]["TOSETTLE_SALES"] = double.Parse(contractview[0]["TOSETTLE_SALES"].ToString()) + amoutsales;
                    contractview[0]["ToSettle_taxcc"] = double.Parse(contractview[0]["ToSettle_taxcc"].ToString()) + amountcctax;
                    contractview[0].EndEdit();
                    /*-----------------------------------------------------------------------------------------------------------------------*/
                }
                /*------------------------Deshacer Transacciones-------------------------------------------------------------------------------------------------------*/
               // if (sqlquery == "") { MessageBox.Show("Reference is Different"); return; }
                if ((SalesfloorID1.Text.Trim() == "" || PropertyID1.Text.Trim() == "") & bSamereference.IsChecked == true)
                { if (aauto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        wwt.Show(); wwt.Refresh();
                        settlementview = SQLCMD.SQLdata(sqlquery).DefaultView;
                    }else { return; }
                }else
                {
                    wwt.Show(); wwt.Refresh();
                    settlementview = SQLCMD.SQLdata(sqlquery).DefaultView;
                }
                if(action1 > 0 & contractview.Count > 0) { pictureBox2.Visible = true; Searchcontract(0); pictureBox2.Visible = false; }/*Actializar el listado para ver el efecto del Undo*/
                if (contractview.Count > 0)/*filtrar si hay contracto en la lista de contracto a liquidar*/
                {
                    Searchcontract(1);
                    contractview.RowFilter = "";
                    Findname.Text = "-"; Findname.Text = "";/*actualizar el gridview al buscar en el textbox name*/
                    grandtotalaliquidar();
                }
                MessageBox.Show("Undone", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                radPageView1.SelectedPage = radPageViewPage1;
            }catch(Exception ecx) { MessageBox.Show(ecx.Message,Application.CompanyName); }
            finally { wwt.Close(); }
        }

        private void GRDSETTLEMENT_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //overviewToolStripMenuItem.PerformClick();
            paymentDetailToolStripMenuItem.PerformClick();
        }

        private void overviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(GRDSETTLEMENT.RowCount < 1) {/* MessageBox.Show("No Contracts In The List", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning);*/ return; }
            Searchcontract(1);
            radPageView1.SelectedPage = radPageViewPage2;
        }
        private void UpdateProcessedRecord(int agreementid,double xsales,double xcctax)
        {
            // int record = GRDSETTLEMENT.CurrentRow.Index;
            contractview.RowFilter = string.Format("agreementid ="+ agreementid + "");
            contractview.AllowEdit = true;
            contractview[0]["R"] = 0;
            contractview[0]["sales_settled"] = double.Parse(contractview[0]["sales_settled"].ToString()) + double.Parse(contractview[0]["tosettle_sales"].ToString());
            contractview[0]["tax_settled"] = double.Parse(contractview[0]["tax_settled"].ToString()) + double.Parse(contractview[0]["tosettle_taxcc"].ToString());
            contractview[0]["tosettle_sales"] = double.Parse(contractview[0]["tosettle_sales"].ToString()) -xsales;
            contractview[0]["tosettle_taxcc"] = double.Parse(contractview[0]["tosettle_taxcc"].ToString()) -xcctax;
            contractview[0]["pendigtosettle_sales"] = double.Parse(contractview[0]["distribution_sales"].ToString()) - double.Parse(contractview[0]["sales_settled"].ToString());
            contractview[0]["pendigtosettle_taxcc"] = double.Parse(contractview[0]["distribution_taxcc"].ToString()) - double.Parse(contractview[0]["tax_settled"].ToString());
            contractview[0].EndEdit();
          
          /*  GRDSETTLEMENT.Rows[record].Cells["Select"].Value = 0;
            GRDSETTLEMENT.Rows[record].Cells["settledsales"].Value = Convert.ToDouble(GRDSETTLEMENT.Rows[record].Cells["settledsales"].Value.ToString()) + Convert.ToDouble(GRDSETTLEMENT.Rows[record].Cells["tosettlesales"].Value.ToString());
            GRDSETTLEMENT.Rows[record].Cells["settledtaxclosing"].Value = Convert.ToDouble(GRDSETTLEMENT.Rows[record].Cells["settledtaxclosing"].Value.ToString()) + Convert.ToDouble(GRDSETTLEMENT.Rows[record].Cells["tosettletaxclosing"].Value.ToString());
            GRDSETTLEMENT.Rows[record].Cells["tosettlesales"].Value = 0;
            GRDSETTLEMENT.Rows[record].Cells["tosettletaxclosing"].Value = 0;
            GRDSETTLEMENT.Rows[record].Cells["pendingtosales"].Value = Convert.ToDouble(GRDSETTLEMENT.Rows[record].Cells["distsales"].Value.ToString()) - Convert.ToDouble(GRDSETTLEMENT.Rows[record].Cells["settledsales"].Value.ToString());
            GRDSETTLEMENT.Rows[record].Cells["pendingtotaxclosing"].Value = Convert.ToDouble( GRDSETTLEMENT.Rows[record].Cells["distclosingtax"].Value.ToString()) - Convert.ToDouble(GRDSETTLEMENT.Rows[record].Cells["settledtaxclosing"].Value.ToString());  
            */

        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string status = "",paid="",agreementid="0";
            /*-------------------------------------------------------------------------------------------------------*/
            if (Active.Checked == true) { status = status + "1"; } else { status = status + "0"; }
            if (Inactive.Checked == true) { status = status + "1"; } else { status = status + "0"; }
            if (Legal.Checked == true) { status = status + "1"; } else { status = status + "0"; }
            if (Hold.Checked == true) { status = status + "1"; } else { status = status + "0"; }
            if (Paid.Checked == true) { paid =  "1"; } else { paid =  "0"; }
            /*-------------------------------------------------------------------------------------------------------*/
            for (int record=0; record<= GRDSETTLEMENT.RowCount -1; record++)
            {
                agreementid = agreementid +","+ GRDSETTLEMENT.Rows[record].Cells["agreementid"].Value.ToString();
            }
            /*-------------------------------------------------------------------------------------------------------*/
            SelectReport repo = new SelectReport();
            repo.salesfloor = Salesfloorid.Text;
            repo.propertyid = Propertyid.Text;
            repo.contractdate1 = Contractdate1.Text;
            repo.contractdate2 = Contractdate2.Text;
            repo.contract1 = Agreementnumber1.Text;
            repo.contract2 = Agreementnumber2.Text;
            repo.status = status;
            repo.paid = paid;
            repo.agreementid = agreementid;
            repo.DVreport = contractview;
            //repo.MdiParent = MdiParent;
            repo.ShowDialog();
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Wait frmwait = new Wait();
            try
            {
                frmwait.Show(); frmwait.Refresh();
                General.ExportToExcel exportexcel = new General.ExportToExcel();
           
              exportexcel.ExportaraExcel(contractview);
            }catch (Exception exc)  { MessageBox.Show(exc.Message,Application.CompanyName); }
            finally { frmwait.Close(); }
        }

        private void bExport1_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Wait frmwait = new Wait();
            try
            {
               frmwait.Show(); frmwait.Refresh();
                //    General.ExportToExcel exportexcel = new General.ExportToExcel();
                //    exportexcel.ExportarToExcelSummary(contractview);
                //General.ExportToExcel exportexcel = new General.ExportToExcel();
                //exportexcel.ExportarGridview(GRDSETTLEMENT);
                General.ReportToThird ReportToThird = new General.ReportToThird();
                ReportToThird.ExportarGridview(GRDSETTLEMENT, Salesfloor.Text, ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text), Contractdate2.Text, 1);

            }
            catch (Exception exc) { MessageBox.Show(exc.Message,Application.CompanyName); }
            finally { frmwait.Close(); }
            /*------------------------------------------------*/

        }

        private void bXml_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Wait frmwait = new Wait();
            try
            {
                frmwait.Show(); frmwait.Refresh();
                General.ExportToExcel exportaXML = new General.ExportToExcel();
                exportaXML.ExportToXML(contractview);
            }catch (Exception exs) { MessageBox.Show(exs.Message,Application.CompanyName); }
            finally { frmwait.Close(); }
        }
        /*---------------Sumar el total de tosettlesales y tosettlecctax--------------------------------------*/
        private void grandtotalaliquidar()
        {
          double  sumsalestosettle = 0, sumcctaxtosettle = 0, grandtotal = 0;

            if (GRDSETTLEMENT.RowCount < 1) { return; }
            for(int record=0;record<= GRDSETTLEMENT.RowCount -1; record ++)
            {
                if (int.Parse(GRDSETTLEMENT.Rows[record].Cells["select"].Value.ToString()) == 1)
                {
                    sumsalestosettle += double.Parse(GRDSETTLEMENT.Rows[record].Cells["tosettlesales"].Value.ToString());
                    sumcctaxtosettle += double.Parse(GRDSETTLEMENT.Rows[record].Cells["tosettletaxclosing"].Value.ToString());
                }
            }
         
            Sales.Text = sumsalestosettle.ToString("#,##0.00");
            Closingtax.Text = sumcctaxtosettle.ToString("#,##0.00");
            grandtotal = sumsalestosettle + sumcctaxtosettle;
            Total.Text = grandtotal.ToString("#,##0.00");
        }

       

        private void radPageViewPage2_Click(object sender, EventArgs e)
        {
           
        }

        private void radPageViewPage2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void radPageView1_Click(object sender, EventArgs e)
        {
            if (radPageView1.SelectedPage == radPageViewPage2)
            { //overviewToolStripMenuItem.PerformClick();
                if (GRDSETTLEMENT.RowCount < 1) { return; }
                Searchcontract(1);
            }
        }

        private void Ckeckinclude_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            SalesfloorID1.Enabled = true; PropertyID1.Enabled = true;
            if(Ckeckinclude.Checked == false)
            { SalesfloorID1.Enabled = false; PropertyID1.Enabled = false; }
        }

        private void Closingtax_TextChanged(object sender, EventArgs e)
        {
            double x1 = ((Sales.Text.Trim() == "") ? 0 : double.Parse(Sales.Text)), x2 = ((Closingtax.Text.Trim() == "") ? 0 : double.Parse(Closingtax.Text)), x3 = 0;
            x3 = x1 + x2;
            Total.Text = x3.ToString("#,##0.00");
        }

        private void Sales_TextChanged(object sender, EventArgs e)
        {
            double x1 = ((Sales.Text.Trim() == "") ? 0 : double.Parse(Sales.Text)), x2 = ((Closingtax.Text.Trim() == "") ? 0 : double.Parse(Closingtax.Text)), x3 = 0;
            x3 = x1 + x2;
            Total.Text = x3.ToString("#,##0.00");
        }

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {

        }

        private void MasterTemplate_CellPaint(object sender, GridViewCellPaintEventArgs e)
        {
            //if(GRDSETTLEMENT.RowCount < 1) { return; }
          
        }
        private void GRDSETTLEMENT_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            /*--------------------------------------------------------*/
           // if (int.Parse(Foundrecords.Text) == GRDSETTLEMENT.RowCount) { e.CellElement.DrawFill = false; return; }
            if (e.CellElement.ColumnInfo.Name == "tosettlesales")
            {
                e.CellElement.DrawFill = true;
                if (Convert.ToDecimal(e.CellElement.Value) != 0)
                {

                    e.CellElement.BackColor = Color.LemonChiffon;
                    e.CellElement.NumberOfColors = 1;
                }
                else
                {
                    e.CellElement.BackColor = Color.Yellow;
                    e.CellElement.NumberOfColors = 1;
                }

            }
            /*--------------------------------------------------------------*/
            if (e.CellElement.ColumnInfo.Name == "tosettletaxclosing")
            {
                e.CellElement.DrawFill = true;
                if (Convert.ToDecimal(e.CellElement.Value) != 0)
                {

                    e.CellElement.BackColor = Color.LemonChiffon;
                    e.CellElement.NumberOfColors = 1;
                }
                else
                {
                    e.CellElement.BackColor = Color.Yellow;
                    e.CellElement.NumberOfColors = 1;
                }

            }
            if (e.CellElement.ColumnInfo.Name == "settledsales")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.PaleTurquoise;
                e.CellElement.NumberOfColors = 1;

            }
            /*-------------------------------------------------------*/
            if (e.CellElement.ColumnInfo.Name == "settledtaxclosing")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.PaleTurquoise;
                e.CellElement.NumberOfColors = 1;

            }
            /*-------------------------------------------------------*/
            if (e.CellElement.ColumnInfo.Name == "pendingtosales")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.PaleTurquoise;
                e.CellElement.NumberOfColors = 1;

            }
            /*-------------------------------------------------------*/
            if (e.CellElement.ColumnInfo.Name == "pendingtotaxclosing")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.PaleTurquoise;
                e.CellElement.NumberOfColors = 1;

            }
            
            /*-------Inactivar color para las demas columnas----*/
              if (e.CellElement.ColumnInfo.Name == "agreementnumber") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "netsales") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "closingcost") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "tax") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "distsales") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "distclosingtax") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "paymentreceived") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "paymentpercent") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "accountreceive") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "ownercorrection") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "name") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "status") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "contractdate") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "updrade") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "financetax") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "exitprogram") { e.CellElement.DrawFill = false; }
            if (e.CellElement.ColumnInfo.Name == "contractsequence") { e.CellElement.DrawFill = false; }

        }
        private void MasterTemplate_CustomSorting(object sender, GridViewCustomSortingEventArgs e)
        {
            //decimal row1Freight = Convert.ToDecimal (e .Row1.Cells["tosettlesales"].Value);
            //decimal row2Freight = Convert.ToDecimal(e.Row1.Cells["tosettletaxclosing"].Value);


            /*----------------------------------------------------------------------*/

            /*-----------------------------------------------------------------------*/
        }

        private void radPageViewPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ReportToThird_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Wait frmwait = new Wait();
            try
            {
                frmwait.Show(); frmwait.Refresh();
                General.ReportToThird ReportToThird = new General.ReportToThird();
                    ReportToThird.ExportarGridview(GRDSETTLEMENT, Salesfloor.Text, ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text), Contractdate2.Text, 0);
            }
            catch (Exception exc) { MessageBox.Show(exc.Message, Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { frmwait.Close(); }
            /*------------------------------------------------*/
            //General.WeeklyReport Semanal = new General.WeeklyReport();
            //Semanal.ExportarGridview(contractview, Salesfloor.Text, ((Contractdate1.Text == "") ? "01-01-1990" : Contractdate1.Text), Contractdate2.Text);
            /*----------------------------------------------------------------------------------------*/
        }

        private void GRDSETTLEMENT_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void bWeekly_Click(object sender, EventArgs e)
        {
            if (GRDSETTLEMENT.RowCount < 1) { MessageBox.Show("No Contracts In The List", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Wait frmwait = new Wait();
            try
            {
                frmwait.Show(); frmwait.Refresh();
                General.WeeklyReport Semanal = new General.WeeklyReport();
                DateTime Since = ((Contractdate1.Text == "") ? DateTime.Parse("01-01-1990") : DateTime.Parse(Contractdate1.Text));
                DateTime Until = DateTime.Parse(Contractdate2.Text);
                    Semanal.ExportarGridview(contractview, Salesfloor.Text, Since.ToString("dd-MMM-yyyy"), Until.ToString("dd-MMMM-yyyy"),int.Parse(Salesfloor.SelectedValue.ToString()));
            }
            catch (Exception exc) { MessageBox.Show(exc.Message, Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { frmwait.Close(); }
        }

        private void SettlementsValidation()
        {//one or more contracts have payment already processed
            ProcessSettlement = 0; ContractList = "";
            for (int row1 = 0; row1 <= GRDSETTLEMENT.RowCount - 1; row1++)
            {
                if (decimal.Parse(GRDSETTLEMENT.Rows[row1].Cells["SettlementValidation"].Value.ToString()) >0)
                {
                    ProcessSettlement = ProcessSettlement + decimal.Parse(GRDSETTLEMENT.Rows[row1].Cells["SettlementValidation"].Value.ToString());
                    ContractList = ContractList+","+GRDSETTLEMENT.Rows[row1].Cells["AgreementNumber"].Value.ToString();
                }
            }
        }
        /*====================================================================================================================================================================================*/
    }
}
