using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateRegistryModel
    {
        [Key]
        public Int64 RealEstateRegistryID { get; set; }
        public string RegistryDescription { get; set; }
        public string Reference { get; set; }
        public DateTime CreationDate { get; set; }
        public int Active { get; set; }
        public Int64 UserId { get; set; }
        //public int RealEstateLocationID { get; set; }
        //public RealEstateLocationModel RealEstateLocation { get; set; }

        //public ICollection<RealEstateAnualBenefitModel> RealEstateAnualBenefit { get; set; }
        public PaymentMethodModel PaymentMethod { get; set; }

        //public Int64 RealEstatePaymentFrecuencyID { get; set; }
        //public RealEstatePaymentFrecuencyModel RealEstatePaymentFrecuency { get; set; }
          
        
        public ICollection<RealEstateContactInfoModel> RealEstateContactInfo { get; set; }

        public ICollection<RealEstateTransactionModel> RealEstateTransaction { get; set; }
        public ICollection<RealEstatePaymentHistoryModel> RealEstatePaymentHistory { get; set; }
        public ICollection<RealEstateRegOwneInfoModel> RealEstateRegOwneInfo { get; set; }
        public ICollection<RealEstateBanksTransferenceModel> RealEstateBanksTransference { get; set; }
        public ICollection<RealStateDocumentsModel> RealStateDocuments { get; set; }












    }
}
