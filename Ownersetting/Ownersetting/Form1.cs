using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ownersetting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Login cifrado = new Login();
            //cifrado.MdiParent = this;
            //cifrado.Show();
            Encryptions cifrar = new Encryptions();
            cifrar.MdiParent = this;
            cifrar.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
