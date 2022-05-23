using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RealEstate.Owner.Dto
{
    public class PaymentSelectionDto
    {
        public Int64 FuturesPmtPlanID { get; set; }
        public bool Check { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; } 
        public decimal Paying { get; set; }
        public string description { get; set; }

    }
}
