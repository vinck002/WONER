using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RealEstate.Owner.Dto
{
    public class RealEstateProcessContractDto
    {
        public Int64 RealEstateRegistryID { get; set; }
        public string PropertyDescription { get; set; }
        public string OwnerInfo { get; set; }
        public decimal AnualBenefit { get; set; }
        public Int64 RealEstateAnualBenefitID { get; set; }
        public int PaymentFrequency { get; set; }
        public string PayEvery { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal JanToFeb { get; set; }
        public decimal MarToApr { get; set; }
        public decimal MayToJun { get; set; }
        public decimal JulToAug { get; set; }
        public decimal SepToOct { get; set; }
        public decimal NovToDec { get; set; }
        public decimal DN { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal B_AnnualTotPaid	{get; set;}
        public decimal ExtraPay { get; set; }
        public string PaymentDescription { get; set; }
        public string PaymentExecution { get; set; }
        public string NameWTdetails { get; set; }
        public Int64 RealEstatePropertyID { get; set; }
        public int hold1 { get; set; }
        public int hold2 { get; set; }
        public int hold3 { get; set; }
        public int hold4 { get; set; }
        public int hold5 { get; set; }
        public int hold6 { get; set; }
        public int REtroactive { get; set; }



    }
}
