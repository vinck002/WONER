using Persistence.DataBase.RealEstateMoldels;
using Persistence.DataBase.RealEstateMoldels.Dto;
using Services.RealEstate.OwnerBenefit;
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
    public partial class RealEstatePropertyModal : Form
    {
        private List<RealEstateProjectTypeModel> _RealEstateProjectType;
        private List<RealEstatePropertyTypeModel> _RealEstatePropectyType;
        public List<RealEstatePropertyModel> lstRealEstateProperty= new List<RealEstatePropertyModel>();
        public Prop_Proj_Loc_Dto _InitialInfo;
        //private List<RealEstatePropertyModel> _RealEstateProperty;

        public RealEstatePropertyModal()
        {
           
             
            InitializeComponent();
            loadInitialInfo();
        }
        //-------------------METHOS AND FUNCT------------------------------------------------------------------
        #region DataFunction
        private void loadInitialInfo()
        {
            OwnerBenefitPaymentInfo OwnerBenefitPaymentInfo = new OwnerBenefitPaymentInfo();
            _InitialInfo = OwnerBenefitPaymentInfo.GetPropertyAndType();

            var location = _InitialInfo.lstRealEstateLocation.ToList();


            cbLocation.DataSource = location;
            cbLocation.DisplayMember = "description";
            cbLocation.ValueMember = "RealEstateLocationID";
            //.Where(x => x.RealEstateLocationID == Convert.ToInt32(cbLocation.SelectedValue))
            //var TextVarProperty = location
            //    .Select(x => x.RealEstateProperty).ToList();
            //  .Select(X =>X.Description).ToList();

            location.Where(x =>  x.RealEstateProperty != null).ToList()
                .ForEach(x => x.RealEstateProperty.ToList()
                .ForEach(p => lstRealEstateProperty.Add(new RealEstatePropertyModel
                { Description = p.Description
                , RealEstatePropertyID = p.RealEstatePropertyID
                ,Active= p.Active
                ,RealEstateLocationID =p.RealEstateLocationID
                ,RealEstatePropertyTypeID = p.RealEstatePropertyTypeID
                })));
               // .Select(x => x.RealEstateProperty)
               //.Select(X =>  new RealEstatePropertyModel { Description = X.Description, RealEstatePropertyID = X.RealEstatePropertyID }).ToList();
            cbProperty.DataSource = lstRealEstateProperty;
            cbProperty.DisplayMember = "Description";
            cbProperty.ValueMember = "RealEstatePropertyID";
            cbProperty.Tag = "RealEstateLocationID";
            cbProperty.Text = "";

        }
        #endregion

        //-- -----------------------------------------------------------

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RealEstatePropertyModal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void RealEstatePropertyModal_Load(object sender, EventArgs e)
        {

        }

        private void cbLocation_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            cbProperty.SelectedValue = cbLocation.SelectedValue;
        }
    }
}
