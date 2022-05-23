using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Int64 RealEstateAnualBenefitID { get; set; }
        public RealEstateAnualBenefitModel RealEstateAnualBenefit { get; set; }
        public int RealEstateTransactionTypeID { get; set; }
        public RealEstateTransactionTypeModel RealEstateTransactionType { get; set; }
        //public Int64 RealEstateDocumentsID { get; set; }
        public RealEstateDocumentsModel RealEstateDocuments { get; set; }
        public int DeactiveUserID { get; set; }
        public DateTime DeactiveDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        [NotMapped]
        public virtual int TempID { get; set; }




    }
}
