using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Models
{
    public class BonusCommssionDetailModel
    {
    public Int64 BonusCommissionDetailID { get; set; }
    public Int64 CommissionerID { get; set; }
     public string   CommissionerName { get; set; }
    public decimal CommissionAmount { get; set; }
    public int ContractQuantity { get; set; }
     public Int64   BonusCommissionID { get; set; }
    public string Comment { get; set; }
    }
}
