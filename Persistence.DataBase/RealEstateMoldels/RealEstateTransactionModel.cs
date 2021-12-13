using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateTransactionModel
    {
        [Key]
        public Int64 RealEstateTransactionID { get; set; }
       
        public DateTime TransDate { get; set; }
        public string Description { get; set; }
        [MaxLength(25)]
        public string Reference { get; set; }
        public Int64 UserID { get; set; }
        public decimal Amount { get; set; }
        public int Active { get; set; }
        public Int64 RealEstateRegistryID { get; set; }
        public RealEstateRegistryModel RealEstateRegistry { get; set; }
        public int RealEstateTransactionTypeID { get; set; }
        public RealEstateTransactionTypeModel RealEstateTransactionType { get; set; }

    }
}
