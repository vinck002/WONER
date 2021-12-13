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
    public partial class OwnerCircleReservation : Form
    {
        public OwnerCircleReservation()
        {
            InitializeComponent();
        }

        private void OwnerCircleReservation_Load(object sender, EventArgs e)
        {
            //tabla memberservicefeereservation
        }

        private void OwnerCircleReservation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }
    }
}
