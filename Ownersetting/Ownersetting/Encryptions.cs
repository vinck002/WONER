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
    public partial class Encryptions : Form
    {
        public Encryptions()
        {
            InitializeComponent();
        }

        private void bEncrypt_Click(object sender, EventArgs e)
        {
            encriptardatos(Encryptdata.Text);
        }

        private void bDecrypt_Click(object sender, EventArgs e)
        {
            desemcriptar(Decryptdata.Text);
        }
        private void encriptardatos(string datos)
        {
            
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(datos);
            result = Convert.ToBase64String(encryted);
            Decryptdata.Text = result;
        }
        /*--------------------------------------------------------------*/
        private void desemcriptar(string datos)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(datos);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            Encryptdata.Text = result;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
