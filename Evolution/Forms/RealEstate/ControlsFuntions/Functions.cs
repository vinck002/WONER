using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Evolution.Forms.RealEstate.ControlsFuntions
{
    public class Functions
    {

        public List<DateTime>FrequencyPayment(int frecuency) //TODO: sin TERMINAR
        {
            List<DateTime> frequencyPayment =  new List<DateTime>();
  
            DateTime dt = new DateTime(DateTime.Now.Year, (12/frecuency), 01);
            
            frequencyPayment.Add(dt);

            for (int i = frecuency; i <= 12; i += frecuency)
            {
                if (i != frecuency)
                {
                    dt.AddMonths(i);
                    frequencyPayment.Add(dt);
                }
                
            }

            return frequencyPayment;
        }

        public static void onleyDecimal(object sender, KeyPressEventArgs e)
        {
            char signo_decimal = (char)46; //Si pulsan el punto .
            if (char.IsNumber(e.KeyChar) |
            e.KeyChar == (char)Keys.Escape | e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false; // No hacemos nada y dejamos que el sistema controle la pulsación de tecla
                return;
            }
            else if (e.KeyChar == signo_decimal)
            {
                //Si no hay caracteres, o si ya hay un punto, no dejaremos poner el punto(.)
                if (((RadTextBox)sender).Text.Length == 0 | ((RadTextBox)sender).Text.LastIndexOf(signo_decimal) >= 0)
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



    }
}
