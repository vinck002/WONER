using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstatePaymentHistoryModel
    {
        [Key]
        public Int64 RealEstatePaymentHistory { get; set; }
        public decimal Amount { get; set; }
        public DateTime EfectiveDate { get; set; }
        public Int64 RealEstateRegistryID { get; set; }
        public RealEstateRegistryModel RealEstateRegistry { get; set; }
        public Int64 processCode { get; set; }
        public string Reference { get; set; }
        public Int64 UserID { get; set; }
        public DateTime CreationDate { get; set; }
        public int Active { get; set; }

    }
}
