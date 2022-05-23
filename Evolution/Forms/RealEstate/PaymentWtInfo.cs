using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution.Forms.RealEstate
{
    public partial class PaymentWtInfo : Form
    {
        RealEstateRegistry _RealEstateRegistry;
        public PaymentWtInfo()
        {
            InitializeComponent();
        }
        public PaymentWtInfo(RealEstateRegistry RealEstateRegistry) :this()
        {
            _RealEstateRegistry = RealEstateRegistry;
        }

        private void PanelPayment_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btnnew_Click(object sender, EventArgs e)
        {

        }

        private void Btnsave_Click(object sender, EventArgs e)
        {

        }
    }
}
