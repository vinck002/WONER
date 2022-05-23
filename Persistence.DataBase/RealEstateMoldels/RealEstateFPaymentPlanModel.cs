using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateFPaymentPlanModel
    {
        public RealEstateFPaymentPlanModel()
        {
            RealEstatePmtTransaction = new List<RealEstatePmtTransactionModel>();
        }
        [Key]
        public Int64 RealEstateFPaymentPlanID { get; set; }
        public Int64 RealEstateAnualBenefitID { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Int64 PaymentMethodID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserID { get; set; }
        public int? DeactiveUserId { get; set; }
        public DateTime? DesactiveDate { get; set; }
        public string Description { get; set; }

        public int Active { get; set; }
        [NotMapped]
        public int tempFPaymentPlanID { get; set; }
        [NotMapped]
        public int tempRealEstateAnualBenefitID { get; set; }
        public ICollection<RealEstatePmtTransactionModel> RealEstatePmtTransaction { get; set; }
        public RealEstateAnualBenefitModel RealEstateAnualBenefit { get; set; }

    }
}
