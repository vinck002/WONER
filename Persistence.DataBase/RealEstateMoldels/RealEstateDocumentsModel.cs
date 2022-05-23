using System;
using System.ComponentModel.DataAnnotations;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateDocumentsModel
    {
        [Key]
        public Int64 RealEstateDocumentsID { get; set; }
        public string FileName { get; set; }
        public string FilePath  { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 RealEstateTransactionID { get; set; }
        public RealEstateTransactionModel RealEstateTransaction { get; set; }

    }
}
