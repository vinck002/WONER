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
    public partial class Wait : Form
    {
        public Wait()
        {
            InitializeComponent();
        }

        private void Wait_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27) { this.Close(); }
        }

        private void Wait_Load(object sender, EventArgs e)
        {
            
            radWaitingBar1.StartWaiting();

        }
    }
}
