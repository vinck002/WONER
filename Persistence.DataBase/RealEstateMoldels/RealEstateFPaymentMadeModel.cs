using System;
using System.ComponentModel.DataAnnotations;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateFPaymentMadeModel
    {
        [Key]
        public Int64 FPaymentMadeID { get; set; }
        public Int64 RealEstatePmtTransactionID { get; set; }
        public decimal DetailAmount { get; set; }
        public RealEstatePmtTransactionModel RealEstatePmtTransaction { get;set; }

    }
}
