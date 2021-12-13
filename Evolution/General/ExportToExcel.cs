using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Telerik.WinControls.UI;
using System.Drawing;
namespace Evolution.General
{
   public class ExportToExcel
    {
        Sqlcommandexecuter SQLCMD = new Sqlcommandexecuter();
        List<ColumnExportModel> lstCollums;
        int _FormId = 1;
        /*------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public void ExportaraExcel(DataView DV)
        {
                   Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =(Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
            /*-----------------poner header o nombre de las columnas---------------------------*/
            for (int j = 0; j < DV.Table.Columns.Count; j++)
            {
                hoja_trabajo.Cells[1, j + 1] = DV.Table.Columns[j].ColumnName;

            }
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["D1", "D" + DV.Count  + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
             /*-----------------------Agregarle los datos a cada celda-----------------------------------*/
            int rd = 0,fila=0;
            foreach (DataRowView DV1 in DV )
            {
                for (int j = 0; j < DV.Table.Columns.Count; j++)
                {
                    if (rd == 0)
                    {
                        hoja_trabajo.Cells[2, j + 1] = DV1[rd+j];
                    }
                    else
                    {
                        hoja_trabajo.Cells[fila + 2, j + 1] = DV1[j];

                    }

                }
                fila = fila + 1;
                rd = rd + 1;
            }
            /*---------------------------------------------------------------------------------*/
            hoja_trabajo.Columns.AutoFit();
            hoja_trabajo.Cells.Borders.LineStyle = BorderStyle.FixedSingle;
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
    /*-------------------------------------exportar lo que se visualiza en la ventana de Settlement-------------------------------------------------------------*/
    public void ExportarToExcelSummary(DataView DV)
        {/*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            libros_trabajo = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            int R1 = 0;
            for (int R = 0; R <= DV.Count; R++)
            { 
                if (R == 0)
                {

                    hoja_trabajo.Cells[R + 1, 1] = "AgreementNumber";
                    hoja_trabajo.Cells[R + 1, 2] = "CONTRACTDATE";
                    hoja_trabajo.Cells[R + 1, 3] = "MemberName";
                    hoja_trabajo.Cells[R + 1, 4] = "UNITTYPENAME";
                    hoja_trabajo.Cells[R + 1, 5] = "Program";
                    hoja_trabajo.Cells[R + 1, 6] = "";
                    hoja_trabajo.Cells[R + 1, 7] = "";
                    hoja_trabajo.Cells[R + 1, 8] = "NETSALES";
                    hoja_trabajo.Cells[R + 1, 9] = "ClosingCost";
                    hoja_trabajo.Cells[R + 1, 10] = "Tax";
                    hoja_trabajo.Cells[R + 1, 11] = "Payment_Closing_TAX";
                    hoja_trabajo.Cells[R + 1, 12] = "Payment_Closing";
                    hoja_trabajo.Cells[R + 1, 13] = "Downpayment_TAX";
                    hoja_trabajo.Cells[R + 1, 14] = "PercentageDownpayment";
                    hoja_trabajo.Cells[R + 1, 15] = "Amount_Financing";
                    hoja_trabajo.Cells[R + 1, 16] = "FINANCING_YEARS";
                    hoja_trabajo.Cells[R + 1, 17] = "Firstyear";
                    hoja_trabajo.Cells[R + 1, 18] = "Last_Financingyear";
                    hoja_trabajo.Cells[R + 1, 19] = "MonthyPayment";
                    hoja_trabajo.Cells[R + 1, 20] = "OtherPayment";
                    hoja_trabajo.Cells[R + 1, 21] = "Payment_Received";
                    hoja_trabajo.Cells[R + 1, 22] = "Amount_Financing";
                    hoja_trabajo.Cells[R + 1, 23] = "Closing_Paid";
                    hoja_trabajo.Cells[R + 1, 24] = "PercentagePaid";
                    hoja_trabajo.Cells[R + 1, 25] = "TotalSettled";
                    hoja_trabajo.Cells[R + 1, 26] = "Status";
                    
                }
                else
                {
                    hoja_trabajo.Cells[R + 1, 1] = DV.Table.Rows[R1]["AgreementNumber"].ToString() ;
                    hoja_trabajo.Cells[R + 1, 2] = DV.Table.Rows[R1]["CONTRACTDATE"].ToString();
                    hoja_trabajo.Cells[R + 1, 3] = DV.Table.Rows[R1]["MemberName"].ToString();
                    hoja_trabajo.Cells[R + 1, 4] = DV.Table.Rows[R1]["UNITTYPENAME"].ToString(); 
                    hoja_trabajo.Cells[R + 1, 5] = ((int.Parse(DV.Table.Rows[R1]["EXIT_PROGRAM"].ToString())==1)? "EXIT" : "UNLIMITED");
                    hoja_trabajo.Cells[R + 1, 6] = "";
                    hoja_trabajo.Cells[R + 1, 7] = "";
                    hoja_trabajo.Cells[R + 1, 8] = DV.Table.Rows[R1]["NETSALES"].ToString();
                    hoja_trabajo.Cells[R + 1, 9] = DV.Table.Rows[R1]["ClosingCost"].ToString();
                    hoja_trabajo.Cells[R + 1, 10] = DV.Table.Rows[R1]["Tax"].ToString();
                    hoja_trabajo.Cells[R + 1, 11] = ((Double.Parse(DV.Table.Rows[R1]["DOWNPAYMENT"].ToString()) - Double.Parse(DV.Table.Rows[R1]["ClosingCost"].ToString()) - Double.Parse(DV.Table.Rows[R1]["Tax"].ToString()) > 0)? Double.Parse(DV.Table.Rows[R1]["DOWNPAYMENT"].ToString()) - Double.Parse(DV.Table.Rows[R1]["ClosingCost"].ToString()) - Double.Parse(DV.Table.Rows[R1]["Tax"].ToString()) : 0);
                    hoja_trabajo.Cells[R + 1, 12] = ((Double.Parse(DV.Table.Rows[R1]["DOWNPAYMENT"].ToString()) >= Double.Parse(DV.Table.Rows[R1]["ClosingCost"].ToString()) ) ? Double.Parse(DV.Table.Rows[R1]["ClosingCost"].ToString()) : Double.Parse(DV.Table.Rows[R1]["DOWNPAYMENT"].ToString()));
                    hoja_trabajo.Cells[R + 1, 13] = ((Double.Parse(DV.Table.Rows[R1]["DOWNPAYMENT"].ToString()) - Double.Parse(DV.Table.Rows[R1]["Closingcost"].ToString()) - Double.Parse(DV.Table.Rows[R1]["Tax"].ToString()) >= Double.Parse(DV.Table.Rows[R1]["Tax"].ToString())) ? Double.Parse(DV.Table.Rows[R1]["Tax"].ToString()) : ((Double.Parse(DV.Table.Rows[R1]["DOWNPAYMENT"].ToString()) - Double.Parse(DV.Table.Rows[R1]["Closingcost"].ToString()) > Double.Parse(DV.Table.Rows[R1]["Closingcost"].ToString())) ? Double.Parse(DV.Table.Rows[R1]["DOWNPAYMENT"].ToString()) - Double.Parse(DV.Table.Rows[R1]["Closingcost"].ToString()) : 0));
                    hoja_trabajo.Cells[R + 1, 14] = ((Double.Parse(DV.Table.Rows[R1]["DOWNPAYMENT"].ToString()) - Double.Parse(DV.Table.Rows[R1]["Closingcost"].ToString()) - Double.Parse(DV.Table.Rows[R1]["Tax"].ToString()) <= 0) ? 0 : ((Double.Parse(DV.Table.Rows[R1]["DOWNPAYMENT"].ToString()) - Double.Parse(DV.Table.Rows[R1]["Closingcost"].ToString()) - Double.Parse(DV.Table.Rows[R1]["Tax"].ToString())) / Double.Parse(DV.Table.Rows[R1]["NETSALES"].ToString())) * 100);
                    hoja_trabajo.Cells[R + 1, 15] = Double.Parse(DV.Table.Rows[R1]["NETSALES"].ToString())+ Double.Parse(DV.Table.Rows[R1]["ClosingCost"].ToString())+ Double.Parse(DV.Table.Rows[R1]["Tax"].ToString())- Double.Parse(DV.Table.Rows[R1]["DOWNPAYMENT"].ToString()) ;
                    hoja_trabajo.Cells[R + 1, 16] = ((Double.Parse(DV.Table.Rows[R1]["FINANCING_YEARS"].ToString())==0) ? 0 : Double.Parse(DV.Table.Rows[R1]["FINANCING_YEARS"].ToString()));
                    hoja_trabajo.Cells[R + 1, 17] = ((Double.Parse(DV.Table.Rows[R1]["FINANCING_YEARS"].ToString()) ==0) ? 0 : Double.Parse(DV.Table.Rows[R1]["firstyear"].ToString()));
                    hoja_trabajo.Cells[R + 1, 18] = int.Parse(DV.Table.Rows[R1]["firstyear"].ToString()) +((int.Parse(DV.Table.Rows[R1]["FINANCING_YEARS"].ToString())==0)? 0 : int.Parse(DV.Table.Rows[R1]["FINANCING_YEARS"].ToString()));
                    hoja_trabajo.Cells[R + 1, 19] = DV.Table.Rows[R1]["MP"].ToString();
                    hoja_trabajo.Cells[R + 1, 20] = Double.Parse(DV.Table.Rows[R1]["PAYMENTS_RECEIVED"].ToString()) - Double.Parse(DV.Table.Rows[R1]["DOWNPAYMENT"].ToString());
                    hoja_trabajo.Cells[R + 1, 21] = DV.Table.Rows[R1]["PAYMENTS_RECEIVED"].ToString();
                    hoja_trabajo.Cells[R + 1, 22] = Double.Parse(DV.Table.Rows[R1]["NETSALES"].ToString()) + Double.Parse(DV.Table.Rows[R1]["ClosingCost"].ToString()) + Double.Parse(DV.Table.Rows[R1]["Tax"].ToString()) - Double.Parse(DV.Table.Rows[R1]["PAYMENTS_RECEIVED"].ToString());
                    hoja_trabajo.Cells[R + 1, 23] = (((Double.Parse(DV.Table.Rows[R1]["NETSALES"].ToString()) + Double.Parse(DV.Table.Rows[R1]["ClosingCost"].ToString()) + Double.Parse(DV.Table.Rows[R1]["Tax"].ToString())) < 0) ? 0 : (Double.Parse(DV.Table.Rows[R1]["PAYMENTS_RECEIVED"].ToString()) - (Double.Parse(DV.Table.Rows[R1]["ClosingCost"].ToString()) + Double.Parse(DV.Table.Rows[R1]["Tax"].ToString())) / Double.Parse(DV.Table.Rows[R1]["NETSALES"].ToString())) * 100);
                    hoja_trabajo.Cells[R + 1, 24] = ((Double.Parse(DV.Table.Rows[R1]["NETSALES"].ToString()) + Double.Parse(DV.Table.Rows[R1]["ClosingCost"].ToString()) + Double.Parse(DV.Table.Rows[R1]["Tax"].ToString()) - Double.Parse(DV.Table.Rows[R1]["PAYMENTS_RECEIVED"].ToString())) / (Double.Parse(DV.Table.Rows[R1]["NETSALES"].ToString()) + Double.Parse(DV.Table.Rows[R1]["ClosingCost"].ToString()) + Double.Parse(DV.Table.Rows[R1]["Tax"].ToString()))) * 100;
                    hoja_trabajo.Cells[R + 1, 25] = Double.Parse( DV.Table.Rows[R1]["SALES_SETTLED"].ToString()) + Double.Parse(DV.Table.Rows[R1]["tax_settled"].ToString());
                    hoja_trabajo.Cells[R + 1, 26] = DV.Table.Rows[R1]["status"].ToString();
                    R1 += 1;
                }
            }
/*------------------------------------------------------------------------------------------------------------------------------*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }
        /*----------------------------Exportar a XML-------------------------------------------------------------------------------------------------*/
        public void ExportToXML(DataView DV)
        { SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "XML (*.xml)|*.xml";
            decimal deposit, tax, totalimporte, importemembership, closingcost,Financing;
            bool IsNull = false;
              if (fichero.ShowDialog() == DialogResult.OK) 
            {
                
                  StreamWriter texto = new StreamWriter(fichero.FileName);
                  string linea = "<?xml version=\"1.0\"?>" +"\r\n"+ "<XMLContratosLifeStyle>" + "\r\n" ;
                    for(int i=0; i<DV.Count; i++)
                    {/*----------------------------------------------------------------------------------------------------------------------------------------*/
                      if (DV.Table.Rows[i]["EvoStatus2"].ToString() != "-1") /*tenia uno para que solo exportara los activo pero conan dijo que federico queria que salieran todos los status*/
                        {
                            deposit = decimal.Parse(DV.Table.Rows[i]["DOWNPAYMENT"].ToString());
                            tax = decimal.Parse(DV.Table.Rows[i]["Tax"].ToString());
                            totalimporte = decimal.Parse(DV.Table.Rows[i]["totalImporte"].ToString());
                            importemembership = decimal.Parse(DV.Table.Rows[i]["ContractValue"].ToString());
                            closingcost = decimal.Parse(DV.Table.Rows[i]["ClosingCost"].ToString());
                            Financing = decimal.Parse(DV.Table.Rows[i]["LoanAmount"].ToString());
                             IsNull = ((DV.Table.Rows[i]["AccountStatusXML"].ToString() =="Nulo")? true : false);
                            /*----------------------------------------------------------------------------------------------------------------------------------------*/
                            linea = linea + "\t" + "<Contrato>" + "\r\n";
                            linea = linea + "\t\t" + "<NumContrato>" + DV.Table.Rows[i]["agreementnumber"].ToString() + "</NumContrato>" + "\r\n" +

                            "\t\t" + " <Estado>" + DV.Table.Rows[i]["AccountStatusXML"].ToString() + "</Estado>" + "\r\n" +
                            "\t\t" + "<Club>" + ((IsNull==true)? "" : DV.Table.Rows[i]["c_salesfloor"].ToString()) + "</Club>" + "\r\n" +
                            "\t\t" + "<TipoPrograma> " + ((IsNull == true) ? "" : DV.Table.Rows[i]["Program"].ToString()) + "</TipoPrograma>" + "\r\n" +
                            "\t\t" + "<Hotel> " + ((IsNull == true) ? "" : DV.Table.Rows[i]["Property"].ToString().Replace("&", "&amp;")) + "</Hotel>" + "\r\n" +
                            "\t\t" + "<FechaVenta>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["CONTRACTDATE"].ToString()) + "</FechaVenta>" + "\r\n" +
                            "\t\t" + "<FechaDesde>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["CONTRACTDATE"].ToString()) + "</FechaDesde>" + "\r\n" +
                            "\t\t" + "<FechaHasta>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["dateuntil1"].ToString()) + "</FechaHasta>" + "\r\n" +
                            "\t\t" + "<TipoMembresia>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["Membershiptype"].ToString()) + "</TipoMembresia>" + "\r\n" +
                            "\t\t" + "<Paquete>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["Program"].ToString() )+ "</Paquete>" + "\r\n" +
                            "\t\t" + "<TipoHab>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["UNITTYPENAME"].ToString()) + "</TipoHab>" + "\r\n" +
                            "\t\t" + "<NumOcu>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["numocu"].ToString()) + "</NumOcu>" + "\r\n" +
                            "\t\t" + "<Temporada>"+ ((IsNull == true) ? "" : "Roja")+" </Temporada>" + "\r\n" +
                            "\t\t" + "<SemanasCompradas>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["SemanasC"].ToString()) + "</SemanasCompradas>" + "\r\n" +
                            "\t\t" + "<SemanasUsadas>"+ ((IsNull == true) ? "" : "0")+" </SemanasUsadas>" + "\r\n" +
                            "\t\t" + "<BonusTime>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["bonustime"].ToString()) + "</BonusTime>" + "\r\n" +
                            "\t\t" + "<ImporteMembresia>" + ((IsNull == true) ? "" : importemembership.ToString("0.00")) + "</ImporteMembresia>" + "\r\n" +
                            "\t\t" + "<GastosAdminYContrato>" + ((IsNull == true) ? "" : closingcost.ToString("0.00")) + "</GastosAdminYContrato>" + "\r\n" +
                            "\t\t" + "<Impuestos>" + ((IsNull == true) ? "" : tax.ToString("0.00")) + "</Impuestos>" + "\r\n" +
                            "\t\t" + "<TotalImporte>" + ((IsNull == true) ? "" : totalimporte.ToString("0.00")) + "</TotalImporte>" + "\r\n" +
                            "\t\t" + "<Deposito>" + ((IsNull == true) ? "" : deposit.ToString("0.00")) + "</Deposito>" + "\r\n" +
                            "\t\t" + "<ImporteFinanciacion>" + ((IsNull == true) ? "" : Financing.ToString("0.00")) + "</ImporteFinanciacion>" + "\r\n" +
                            "\t\t" + "<FechaIni>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["datefrom"].ToString()) + "</FechaIni>" + "\r\n" + 
                            "\t\t" + "<FechaFin>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["dateuntil"].ToString()) + "</FechaFin >" + "\r\n" +
                            "\t\t" + "<Monthly_Payment>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["MP"].ToString()) + "</Monthly_Payment>" + "\r\n" +
                            "\t\t" + "<NumCuotas>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["NCuotas"].ToString()) + "</NumCuotas>" + "\r\n" +
                            "\t\t" + "<Comprador>" + "\r\n" +
                            "\t\t" + "<LinComprador>"+ ((IsNull == true) ? "" : "1")+" </LinComprador>" + "\r\n" +
                            "\t\t" + "<NumCont>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["agreementnumber"].ToString().Replace("&", "&amp;")) + "</NumCont>" + "\r\n" +
                            "\t\t" + "<Nombre>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["Comprador1"].ToString().Replace("&", "&amp;")) + "</Nombre>" + "\r\n" +
                            "\t\t" + "<Direccion>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["Address"].ToString().Replace("&", "&amp;")) + "</Direccion>" + "\r\n" +
                            "\t\t" + "<Cuidad>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["city"].ToString().Replace("&", "&amp;")) + "</Cuidad>" + "\r\n" +
                            "\t\t" + "<Provincia>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["State"].ToString().Replace("&", "&amp;")) + "</Provincia>" + "\r\n" +
                            "\t\t" + "<CodPostal>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["zip"].ToString().Replace("&", "&amp;")) + "</CodPostal>" + "\r\n" +
                            "\t\t" + "<Telefono>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["PHONE"].ToString().Replace("&", "&amp;")) + "</Telefono>" + "\r\n" +
                            "\t\t" + "<Email>" + ((IsNull == true) ? "" : DV.Table.Rows[i]["EMAIL"].ToString().Replace("&","&amp;")) + "</Email>" + "\r\n" +
                            "\t\t" + "</Comprador>" + "\r\n";
                        if (DV.Table.Rows[i]["Comprador2"].ToString().Length > 3 && IsNull == false)
                        {
                            linea = linea + "\t\t\t" + "<Comprador>" + "\r\n" +
                             "\t\t\t\t" + " <LinComprador>1</LinComprador>" + "\r\n" +
                             "\t\t\t\t" + "<NumCont>" + DV.Table.Rows[i]["agreementnumber"].ToString() + "</NumCont>" + "\r\n" +
                             "\t\t\t\t" + "<Nombre>" + DV.Table.Rows[i]["Comprador2"].ToString().Replace("&", "&amp;") + "</Nombre>" + "\r\n" +
                             "\t\t\t\t" + "<Direccion>" + DV.Table.Rows[i]["Address"].ToString().Replace("&", "&amp;") + "</Direccion>" + "\r\n" +
                             "\t\t\t\t" + "<Cuidad>" + DV.Table.Rows[i]["city"].ToString().Replace("&", "&amp;") + "</Cuidad>" + "\r\n" +
                             "\t\t\t\t" + "<Provincia>" + DV.Table.Rows[i]["State"].ToString().Replace("&", "&amp;") + "</Provincia>" + "\r\n" +
                             "\t\t\t\t" + "<CodPostal>" + DV.Table.Rows[i]["zip"].ToString().Replace("&", "&amp;") + "</CodPostal>" + "\r\n" +
                             "\t\t\t" + "</Comprador>" + "\r\n";
                        }
                        linea = linea + "\t" + "</Contrato>" + "\r\n\r\n";
                    }
                    } 
            linea = linea + "</XMLContratosLifeStyle>";
                texto.WriteLine(linea);
                texto.Close();
                
            }


        }
        /*--------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /*<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>*/
        public void ExportarGridview(RadGridView DV)
        {/*----------------------------------------------------------------------------------------*/
        Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            libros_trabajo = aplicacion.Workbooks.Add();
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
            /*----------------------------------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rango1 = aplicacion.Range["A1", "A" + DV.RowCount + 1 + ""];
            rango1.NumberFormat = "@";//solo texto en los contractos
            int R1 = 0;
            for (int R = 0; R <= DV.RowCount ; R++)
            {
                if (R == 0)
                {

                    hoja_trabajo.Cells[R + 1, 1] = "Agreement Number";
                    hoja_trabajo.Cells[R + 1, 2] = "Netsales";
                    hoja_trabajo.Cells[R + 1, 3] = "Closing Cost";
                    hoja_trabajo.Cells[R + 1, 4] = "Tax";
                    hoja_trabajo.Cells[R + 1, 5] = "Distribution Sales";
                    hoja_trabajo.Cells[R + 1, 6] = "Distribution ClosingTax";
                    hoja_trabajo.Cells[R + 1, 7] = "Payment Received";
                    hoja_trabajo.Cells[R + 1, 8] = "Payment %";
                    hoja_trabajo.Cells[R + 1, 9] = "Account Receivable";
                    hoja_trabajo.Cells[R + 1, 10] = "Ownership Corrections";
                    hoja_trabajo.Cells[R + 1, 11] = "Settled Sales";
                    hoja_trabajo.Cells[R + 1, 12] = "Settled ClosingTax";
                    hoja_trabajo.Cells[R + 1, 13] = "To Settle Sales";
                    hoja_trabajo.Cells[R + 1, 14] = "To Settle ClosingTax";
                    hoja_trabajo.Cells[R + 1, 15] = "Pending To Sales";
                    hoja_trabajo.Cells[R + 1, 16] = "Pending ClosingTax";
                    hoja_trabajo.Cells[R + 1, 17] = "Name";
                    hoja_trabajo.Cells[R + 1, 18] = "Status";
                    hoja_trabajo.Cells[R + 1, 19] = "Contract Date";
                    hoja_trabajo.Cells[R + 1, 20] = "Upgrade";
                    hoja_trabajo.Cells[R + 1, 21] = "Financing Tax";
                    hoja_trabajo.Cells[R + 1, 22] = "Exit Program";

                }
                else
                {
                    hoja_trabajo.Cells[R + 1, 1] = DV.Rows[R1].Cells["AgreementNumber"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 2] = DV.Rows[R1].Cells["netsales"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 3] = DV.Rows[R1].Cells["closingcost"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 4] = DV.Rows[R1].Cells["tax"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 5] = DV.Rows[R1].Cells["distsales"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 6] = DV.Rows[R1].Cells["distclosingtax"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 7] = DV.Rows[R1].Cells["paymentreceived"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 8] = DV.Rows[R1].Cells["paymentpercent"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 9] = DV.Rows[R1].Cells["accountreceive"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 10] = DV.Rows[R1].Cells["ownercorrection"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 11] = DV.Rows[R1].Cells["settledsales"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 12] = DV.Rows[R1].Cells["settledtaxclosing"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 13] = DV.Rows[R1].Cells["tosettlesales"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 14] = DV.Rows[R1].Cells["tosettletaxclosing"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 15] = DV.Rows[R1].Cells["pendingtosales"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 16] = DV.Rows[R1].Cells["pendingtotaxclosing"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 17] = DV.Rows[R1].Cells["name"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 18] = DV.Rows[R1].Cells["status"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 19] = DV.Rows[R1].Cells["contractdate"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 20] = DV.Rows[R1].Cells["upgrade"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 21] = DV.Rows[R1].Cells["financetax"].Value.ToString();
                    hoja_trabajo.Cells[R + 1, 22] = DV.Rows[R1].Cells["exitprogram"].Value.ToString();
                    /*--------------Formato por cada linea----------------------------------------------------*/
                    Microsoft.Office.Interop.Excel.Range rango3 = aplicacion.Range["B" + (R + 1) + "", "P" + (R + 1) + ""];
                    rango3.NumberFormat = "#,##0.00";
                    Microsoft.Office.Interop.Excel.Range rango4 = aplicacion.Range["A" + (R + 1) + "", "V" + (R + 1) + ""];
                    rango4.Borders.LineStyle = BorderStyle.FixedSingle;
                    /*-------------------------------------------------------------------------------------------------------*/
                    R1 += 1;
                }
               
            }
            /*--------------------------Formato------------------------------------------------------------*/
            Microsoft.Office.Interop.Excel.Range rangos = aplicacion.Range["A1", "V1"];
            rangos.Columns.ColumnWidth = 12;
            rangos.RowHeight = 27.75;
            rangos.Columns.WrapText = true;
            rangos.Borders.LineStyle = BorderStyle.FixedSingle;
            rangos.Interior.Color = Color.Azure;
            rangos.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangos.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range rango2 = aplicacion.Range["A" + (R1 + 3) + "", "V" + (R1 + 3) + ""];
            rango2.Interior.Color = Color.Azure;
            rango2.Font.Bold = true;
            rango2.NumberFormat = "#,##0.00";
            rango2.Borders.LineStyle = BorderStyle.FixedSingle;
            /*--------------------------Totales----------------------------------------------------------------------------------------------------*/
            hoja_trabajo.Cells[R1 + 3, 1] = "Total";
            hoja_trabajo.Cells[R1 + 3, 2] = "=sum(B2:B" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 3] = "=sum(c2:C" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 4] = "=sum(D2:D" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 5] = "=sum(E2:E" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 6] = "=sum(F2:F" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 7] = "=sum(G2:G" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 8] = "=sum(H2:H" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 9] = "=sum(I2:I" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 10] = "=sum(J2:J" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 11] = "=sum(K2:K" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 12] = "=sum(L2:L" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 13] = "=sum(M2:M" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 14] = "=sum(N2:N" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 15] = "=sum(O2:O" + (R1 + 2) + ")";
            hoja_trabajo.Cells[R1 + 3, 16] = "=sum(P2:P" + (R1 + 2) + ")";
            /*-------------------------------------------------------------------------------------*/
            aplicacion.Visible = true;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(aplicacion);
        }

        /*===================================================================================================================================================================*/
        //public void Ejecutar()
        //{
        //    lstCollums = SQLCMD.SQLdata($"Sp_ChoosExportCollums {_FormId}").AsEnumerable().Select(x =>
        //                                                   new CollumnExportModel
        //                                                   {
        //                                                       Id = x.Field<Int64>("Id"),
        //                                                       FormCode = x.Field<int>("FormCode"),
        //                                                       CollumName = x.Field<string>("CollumName"),
        //                                                       Description = x.Field<string>("Description"),
        //                                                       Visibl = x.Field<bool>("Visibl"),
        //                                                       ColumNumber = x.Field<int>("ColumNumber")
        //                                                       ,
        //                                                       DefaultCollumns = x.Field<bool>("DefaultCollumns")
        //                                                   }).ToList();

        //}
    }
}
