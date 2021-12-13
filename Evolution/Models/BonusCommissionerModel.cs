using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Models
{
    public class BonusCommissionerModel
    {
       public Int64 CommissionerID { get; set; }
        public string FullName { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public string CreationDate { get; set; }
        public int Active { get; set; }
        public int ContractQuantity { get; set; }
        public int Selected { get; set; }
        public string Comment { get; set; }

    }
}
