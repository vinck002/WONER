using Persistence.DataBase.RealEstateMoldels;
using Services.RealEstate.Owner.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Forms.RealEstate.Registry
{
    public interface IPropertyBenefit
    {
        void SelectBenefit(RealEstateRegistryModel _owner, int PropID, List<FuturesPmtPlanDto> FuturesPmtPlanDto = null);
    }
}
