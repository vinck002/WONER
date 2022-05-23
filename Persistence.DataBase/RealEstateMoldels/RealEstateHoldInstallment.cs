using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels
{
    public class RealEstateHoldInstallment
    {
        [Key]
        public  Int64 HoldInstallmentID { get; set; }
        public Int64 RealEstateAnualBenefitID { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int Active { get; set; }
        public int UserID { get; set; }
        public int DeactiveUserID { get; set; }
        public DateTime CreationDate { get; set; }

        public RealEstateAnualBenefitModel RealEstateAnualBenefit { get; set; }


    }
}
