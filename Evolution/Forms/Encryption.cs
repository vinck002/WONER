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
    public partial class Encryption : Form
    {
        public Encryption()
        {
            InitializeComponent();
        }

        private void bEncrypt_Click(object sender, EventArgs e)
        {
            encriptardatos(Encryptdata.Text);
            /*-------------------------------------------*/
            //Function Encriptar(DataValue As Variant) As Variant
            //Dim x As Long
            //Dim temp As String
            //Dim TempNum As Integer
            //Dim TempChar As String
            //Dim TempChar2 As String

            //For x = 1 To Len(DataValue)
            //TempChar2 = Mid(DataValue, x, 1)
            //TempNum = Int(Asc(TempChar2) / 16)
            //If((TempNum * 16) < Asc(TempChar2)) Then

            //    TempChar = ConvToHex(Asc(TempChar2) - (TempNum * 16))
            //    temp = temp & ConvToHex(TempNum) & TempChar
            //Else
            //    temp = temp & ConvToHex(TempNum) & "0"

            //End If
            //Next x
            //Encriptar = temp
            //End Function
        }
        private void encriptardatos(string datos)
        {
            int X;
            int TempNum;
            string temp="", TempChar, TempChar2;
            for (X = 1; X < datos.Length; X++)
            {
                TempChar2 = datos.Substring( X, 1);
                TempNum = (char)char.Parse(TempChar2) /16;
                if((TempNum * 16) < (char)char.Parse(TempChar2))
                {
                    TempChar = ((char)char.Parse(TempChar2) - (TempNum * 16)).ToString("x");
                    temp = temp + "" + TempNum.ToString("x") + "" + TempChar;

                }else { temp = temp + "" + TempNum.ToString("x") + "0"; }
            }
            Decryptdata.Text = temp;
            /*----------------------------------------------------*/
            //string result = string.Empty;
            //byte[] encryted = System.Text.Encoding.Unicode.GetBytes(datos);
            //result = Convert.ToBase64String(encryted);
            //Decryptdata.Text = result;
        }
        /*--------------------------------------------------------------*/
        private void desemcriptar(string datos)
        {
            //            Function Desencriptar(DataValue As Variant) As Variant


            //    Dim x As Long
            //    Dim temp As String
            //    Dim HexByte As String
            //     For x = 1 To Len(DataValue)Step 2
            //     HexByte = Mid(DataValue, x, 2)
            //        temp = temp & Chr(ConvToInt(HexByte))
            //       Next x
            //    ' retorno
            //    Desencriptar = temp
            //End Function
            /*-------------------------------------------------*/
            int X;
            string temp = "", HexByte="";
            for (X=1; X<= datos.Length; X++)
            {
                HexByte = datos.Substring(X,2);
               // MessageBox.Show(char.ConvertFromUtf32(int.Parse(HexByte)));
                temp = temp + "" + char.ConvertFromUtf32 (int.Parse(HexByte));

            }
            Encryptdata.Text = temp;
            /*---------------------------------------------------*/
            /* string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(datos);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            Encryptdata.Text = result; */
        }

        private void bDecrypt_Click(object sender, EventArgs e)
        {
            desemcriptar(Decryptdata.Text);
          //  MessageBox.Show( char.ConvertFromUtf32(65));
            //MessageBox.Show(char.ConvertToUtf32 (Encryptdata.Text));
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*-------------------------------------------------------------------------------------------------------*/
    }
}
