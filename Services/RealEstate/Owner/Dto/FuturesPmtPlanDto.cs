using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RealEstate.Owner.Dto
{
    public class FuturesPmtPlanDto
    {
        public Int64 FuturesPmtPlanID { get; set; }
        public bool Paid { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Int64 PropertyID { get; set; } 
        public decimal AmountPaid { get; set; }
         public string PaymentMethod { get; set; }
        public Int64 PaymentMethodID { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }
        public string user { get; set; }
        public Int64 RealEstateAnualBenefitID { get; set; }
        public bool Undo { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int tempID { get; set; }
        public int anualbenefitTempID { get; set; }

    }
}
