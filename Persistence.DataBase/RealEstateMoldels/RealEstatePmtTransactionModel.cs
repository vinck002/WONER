using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstatePmtTransactionModel
    {
        [Key]
        public Int64 RealEstatePmtTransactionID { get; set; }
        public string Description { get; set; }
        public Int64 RealEstateFPaymentPlanID { get; set; }
        public RealEstateFPaymentPlanModel RealEstateFPaymentPlan { get; set;}
        public decimal Amount { get; set; }
        [NotMapped]
        public bool Undo { get; set; }
        public Int64 PaymentMethodID { get; set; }
        public int Active { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime TransDate { get; set; }
        public int? DeactiveUserID { get; set; }
        public DateTime? DeactiveDate { get; set; }
        public int UserID { get; set; }
        public string PaymentMethodReference { get; set; }
        //public ICollection<RealEstateFPaymentMadeModel> RealEstateFPaymentMade { get; set; }

    }
}
