using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Evolution.Forms.BonusCommissions
{
    public partial class BonusCommissionReport : Form
    {
        public BonusCommissionReport()
        {
            InitializeComponent();
        }

        private void BonusCommissionReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            BonusTemplate bt = new BonusTemplate();
            bt.ClosePrint = false; 
        }
    }
}
