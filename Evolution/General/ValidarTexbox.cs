using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution.General
{
  public  class ValidarTexbox
    {

        public void Solonumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            { e.Handled = true; MessageBox.Show("Just Number","OWNER",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        public void Solonumerosentero(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            { e.Handled = true; MessageBox.Show("Just Number", "OWNER", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
    }
}
