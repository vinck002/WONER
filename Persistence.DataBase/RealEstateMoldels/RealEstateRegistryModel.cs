using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateRegistryModel
    {

        public RealEstateRegistryModel()
        {
            RealEstateAnualBenefit = new List<RealEstateAnualBenefitModel>();
            RealEstateContactInfo = new List<RealEstateContactInfoModel>();
            RealEstateBanksTransference = new List<RealEstateBankTranferenceModel>();
            RealEstateRegOwneInfo = new RealEstateRegOwneInfoModel();
            RealEstateBanksTransference = new List<RealEstateBankTranferenceModel>();
        }
        [Key]
        public Int64 RealEstateRegistryID { get; set; }
        public string RegistryDescription { get; set; }
        public string Reference { get; set; }
        public DateTime CreationDate { get; set; }
        public int Active { get; set; }
        public Int64 UserId { get; set; }

        public RealEstateRegOwneInfoModel RealEstateRegOwneInfo { get; set; }

        public ICollection<RealEstateAnualBenefitModel> RealEstateAnualBenefit{ get; set; }
        public ICollection<RealEstateContactInfoModel> RealEstateContactInfo { get; set; }

        public ICollection<RealEstateBankTranferenceModel> RealEstateBanksTransference { get; set; }
        
        












    }
}
