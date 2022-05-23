using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateAnualBenefitModel
    {
        public RealEstateAnualBenefitModel()
        {
            RealEstateFPaymentPlan = new List<RealEstateFPaymentPlanModel>();
            RealEstateTransaction = new List<RealEstateTransactionModel>();
            RealEstateHoldInstallment = new List<RealEstateHoldInstallment>();
        }
        [Key]
        public Int64 RealEstateAnualBenefitID { get; set; }
        [NotMapped]
        public Int64 TMPRealEstateAnualBenefitID { get; set; }
        public decimal AnnualBenefit { get; set; }
        public decimal Amount { get; set; }
        public int Active { get; set; }
        public DateTime EfectiveDate { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime CreationDate { get; set; }

 
        public int Status { get; set; }

        public int ModifiedUserID { get; set; }
        public string ModifiedUserName  { get; set; }
        public Int64 PrevieusAnualBenefitdID { get; set; }
        public int Sequence { get; set; }
   
        public Int64 RealEstatePropertyID { get; set; }
        public RealEstatePropertyModel RealEstateProperty { get; set; }

        public Int64 RealEstateRegistryID {get;set;}
        public RealEstateRegistryModel RealEstateRegistry { get; set; }

        public Int64 PaymentMethodID { get; set; }
        //public PaymentMethodModel PaymentMethod { get; set; }

        public Int64 RealEstatePaymentFrecuencyID { get; set; }
        public RealEstatePaymentFrecuencyModel RealEstatePaymentFrecuency { get; set; }
        //public IList<RealEstatePropertyOBenefitModel> RealEstatePropertyOBenefit { get; set; }
        public ICollection<RealEstateTransactionModel> RealEstateTransaction { get; set; }

        public  ICollection<RealEstateHoldInstallment> RealEstateHoldInstallment { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public ICollection<RealEstateFPaymentPlanModel> RealEstateFPaymentPlan { get; set; }

    }
}
