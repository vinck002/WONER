using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Models
{
    public class BonusCommissionModel
    {
      public Int64  BonusCommissionID { get; set; }
      public int  ContractQuantity { get; set; }
        public string  AgreementsIdBatch { get; set; }
        public DateTime  DateFrom { get; set; }
        public DateTime  DateTo { get; set; }
        public string  Code { get; set; }
        public Int64  UserId { get; set; }
        public decimal  TotalPaidToContracts { get; set; }
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }
        public string User { get; set; }
        public int Processed { get; set; }
        public List<BonusCommssionDetailModel> BonusCommisionDetail { get; set; }
    }
}
