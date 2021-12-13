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
    public partial class CommissionProjected : Form
    {
        public CommissionProjected()
        {
            InitializeComponent();
        }

        private void CommissionProjected_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) { this.Close(); }
            if (e.KeyChar == 13) { SendKeys.Send("{Tab}"); }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {

        }

        private void CommissionProjected_Load(object sender, EventArgs e)
        {

        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        /*===============================================================================================================================================*/
    }
}
