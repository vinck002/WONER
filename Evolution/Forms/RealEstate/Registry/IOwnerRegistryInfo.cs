using Persistence.DataBase.RealEstateMoldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Forms.RealEstate.Registry
{
    public interface IOwnerRegistryInfo
    {
        void OwnerRegistryInfo(RealEstateRegistryModel RealEstateRegistry,Int64 RealEstateAnualBenefitModelID, bool ComingFromSave= false);
    }
}
