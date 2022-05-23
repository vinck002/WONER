using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBase.RealEstateMoldels.Dto
{
    public class OwnerInfoDto
    {
        public Int64 RealEstateRegistryID { get; set; }
        public string DocumentID { get; set; }
        public string PropertyDescription { get; set; }
        public string PropertyTipeDescript { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        public string ContractReference { get; set; }
        public DateTime? ContractDate { get; set; }
        public DateTime? EfectiveDate { get; set; }
        public Int64 RealEstateAnualBenefitID { get;set;}
    }
}
