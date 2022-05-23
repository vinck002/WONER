using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels.Dto
{
    public class RealEstatePmtTransactionDto
    {
        public Int64 RealEstatePmtTransactionID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool Undo { get; set; }
        public Int64 PaymentMethodID { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string User { get; set; }

        public Int64 RealEstateFPaymentPlanID { get; set; }
        public string PaymentMethodReference { get; set; }

    }
}
