using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RealEstate.Owner.Dto
{
    public class TransactionDto
    {
        public Int64 RealEstateTransactionID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int TransactionTypeID { get; set; }
        public string TransactionType { get; set; }
        public Int64 RealEstateAnualBenefitID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int Active { get; set; }
        public int TempID { get; set; }
        public string Type { get; set; }
        public string TempPath { get; set; }
        public string NewPath { get; set; }
        public Int64? RealEstateDocumentID { get; set; }
        public string FileName { get; set; }
        public int  AnualBenStatus { get; set; }
        public DateTime TransDate { get; set; }


    }
}
