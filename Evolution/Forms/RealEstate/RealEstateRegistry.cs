using Services.RealEstate.OwnerBenefit;
using Services.RealEstate.OwnerBenefit.Dto;
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
    public partial class RealEstateRegistry : Form
    {
        private PaymentMethodFrequency PaymentMethodFrequency;
        private object[] _PropertyID;

        public object[] PropertyID { set => _PropertyID = value; get{ return _PropertyID; } }
        public RealEstateRegistry()
        {
            InitializeComponent();
        }

        private void PgPaymentInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PgTransferSetup_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RealEstateRegistry_Load(object sender, EventArgs e)
        {
            var OwnerBenefitPayment = new OwnerBenefitPaymentInfo();
            PaymentMethodFrequency = OwnerBenefitPayment.GetPaymentMethodFrequency();
            //--------------------------------------------Owner Benefits Area------------------------------------------
            cbPaymentMethod.DataSource = PaymentMethodFrequency.PaymentMethod;
            cbPaymentMethod.ValueMember = "PaymentMethodID";
            cbPaymentMethod.DisplayMember = "Description";

            cbPaymentFrequency.DataSource = PaymentMethodFrequency.RealEstatePaymentFrecuency.Where(x => x.Active == 1);
            cbPaymentFrequency.ValueMember = "RealEstatePaymentFrecuencyID";
            cbPaymentFrequency.DisplayMember = "description";
          
            //--------------------------------------------------------------------------------------
        }

        private void radPictureBox1_Click(object sender, EventArgs e)
        {
            RealEstatePropertyModal RealEstateProperty = new RealEstatePropertyModal();
            RealEstateProperty.ShowDialog();
        }
    }
}
