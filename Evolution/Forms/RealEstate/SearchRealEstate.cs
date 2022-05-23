using Evolution.Forms.RealEstate.Registry;
using Persistence.DataBase.RealEstateMoldels;
using Persistence.DataBase.RealEstateMoldels.Dto;
using Services.RealEstate.Owner;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Evolution.Forms.RealEstate
{

    public partial class SearchRealEstate : Form
    {
        List<OwnerInfoDto> lstOwnerInfoDto;
        Owner _Owner;
        IOwnerRegistryInfo _IOwnerRegistryInfo;
        OwnerInfoDto _ownerInfoDto;
        List<RealEstatePropertyTypeModel> getPropertyFilter;
        List<RealEstatePropertyModel> lstRealEstateProperty;
        RadToolTip toolTip;

        bool fromExtForm = false;
        public SearchRealEstate()
        {
            InitializeComponent();
            _Owner = new Owner();
            LoadFilterInfo();
            toolTip = new RadToolTip();
            cbFilterBy.SelectedIndex = 0;
        }

        public SearchRealEstate(OwnerInfoDto ownerInfoDto)
            : this()
        {
            _ownerInfoDto = ownerInfoDto;
            //fromExtForm = true;
            if (ownerInfoDto.lastName.Trim().Length == 0 && ownerInfoDto.Name.Trim().Length == 0 && ownerInfoDto.ContractReference.Length == 0)
            {
                SearchContract(0);
            }else if (ownerInfoDto.ContractReference.Length > 0)
            {
                SearchContract(3);

            }
            else if(ownerInfoDto.Name.Trim().Length > 0)
            {
                SearchContract(2);
            }
            //dtgOwnerResult.DataSource = _wnerInfoDto;
        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radLabel23_Click(object sender, EventArgs e)
        {

        }

        private void dtgOwnerResult_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                ExecuteSelect();
            }


        }
        void ExecuteSelect()
        {
            _IOwnerRegistryInfo = this.Owner as IOwnerRegistryInfo;
            RealEstateRegistryModel RealEstateRegistry = _Owner.GetRealEstateRegistryById(Convert.ToInt64(dtgOwnerResult.CurrentRow.Cells[0].Value));
            _IOwnerRegistryInfo.OwnerRegistryInfo(RealEstateRegistry,Convert.ToInt64(dtgOwnerResult.CurrentRow.Cells[9].Value));
            this.Close();
        }

        private void dtgOwnerResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dtgOwnerResult.Rows.Count > 0)
                {
                    if (dtgOwnerResult.CurrentRow.Index >= 0)
                    {
                        ExecuteSelect();
                    }
                }
              
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchContract((int)cbFilterBy.SelectedIndex);
        }


        #region FUNCTION
        void SearchContract(int option = 0)  //BUSCA CONTRATO FILTRADOS
        {
            
            if (option < 0)
            {
                cbFilterBy.BackColor = Color.FromArgb(255, 255, 192);
                cbFilterBy.Focus();
                toolTip.Show("Select an option!", 2000);
                return;
            }
  
            _ownerInfoDto = new OwnerInfoDto();
            if (option == 1) //by property
            {

                if (cbPropertyMultyC.SelectedIndex < 0 && txtDescription.Text.Trim() == string.Empty)
                {
                    cbPropertyMultyC.Focus();
                    cbPropertyMultyC.BackColor = Color.FromArgb(255, 255, 192);
                    return;
                }
                if (cbPropertyMultyC.SelectedIndex != -1)
                {
                    _ownerInfoDto.PropertyDescription = cbPropertyMultyC.MultiColumnComboBoxElement.Rows[cbPropertyMultyC.SelectedIndex].Cells["Description"].Value.ToString();
                }
                else
                {
                    _ownerInfoDto.PropertyDescription = txtDescription.Text;
                }

            }
            else if (option == 2) // by Name
            {
                if (!fromExtForm)
                {
                    _ownerInfoDto.Name = txtDescription.Text;
                }
            }
            else if (option == 3) //By Contract
            {
                if (!fromExtForm)
                {
                    _ownerInfoDto.ContractReference = txtDescription.Text;
                }
               
            }
            dtgOwnerResult.DataSource = _Owner.SearhOwnerInfo(_ownerInfoDto,option);
            fromExtForm = false;
        }

        void LoadFilterInfo()  /////Conbo filter info 
        {
            getPropertyFilter = _Owner.getPropertyFilter();

            CPropertyType.ValueMember = "RealEstatePropertyTypeID";
            CPropertyType.DisplayMember = "Description";
            CPropertyType.DataSource = getPropertyFilter;
        }
        #endregion

        private void cbPropertyMultyC_Enter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
            lstRealEstateProperty = new List<RealEstatePropertyModel>();

            lstRealEstateProperty = getPropertyFilter.SelectMany(a => a.RealEstateProperty.Where(pt => pt.RealEstatePropertyTypeID == Convert.ToInt32(CPropertyType.SelectedValue))).ToList();

            cbPropertyMultyC.ValueMember = "RealEstatePropertyTypeID";
            cbPropertyMultyC.DisplayMember = "Description";
            cbPropertyMultyC.DataSource = lstRealEstateProperty;
        }

        private void CPropertyType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            cbPropertyMultyC.Text = "";
            cbPropertyMultyC.DataSource = null;

            if (true)
            {

            }
        }

        private void cbFilterBy_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Select filter option!", 2000);

        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDescription.Text = string.Empty;
            CPropertyType.SelectedIndex = -1;
            cbFilterBy.SelectedIndex = 0;
        }
    }
}
