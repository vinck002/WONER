using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class FutureUse
    {

        //LINQ PARA REALIZAR LEFT JOIN
        //using (var ctx = new OwneDbContext()) 
        //        {

        //            var lstAvailableProperties = ctx.RealEstateProperty.FromSqlRaw("SP_RealEstateAvailableProperty").ToList();

        //var lstproperties = new List<RealEstatePropertyModel>();
        //lstproperties = (from pr in ctx.RealEstateProperty
        //                      join ben in ctx.RealEstateAnualBenefit on pr.RealEstatePropertyID equals ben.RealEstatePropertyID
        //                      into AnualBenProp
        //                      from abp in AnualBenProp.DefaultIfEmpty()                                 
        //                      select new PropertyBenefitDto
        //                      {
        //                          Description = pr.Description,
        //                          RealEstateAnualBenefitID= abp.RealEstateAnualBenefitID,
        //                          RealEstateLocation = abp.RealEstateProperty.RealEstateLocation,
        //                          RealEstateLocationID= abp.RealEstateProperty.RealEstateLocationID,
        //                          RealEstatePropertyID = pr.RealEstatePropertyID,
        //                          RealEstatePropertyType = pr.RealEstatePropertyType,
        //                          RealEstatePropertyTypeID =pr.RealEstatePropertyTypeID,
        //                          Active = pr.Active,
        //                          ContractDate=abp.ContractDate,
        //                          EfectiveDate=abp.EfectiveDate,
        //                          AnualbenefitActive = abp.Active
        //                      })
        //                      .Where(c =>c.RealEstateAnualBenefitID == null  || c.AnualbenefitActive == 0 ||  c.EfectiveDate < DateTime.Now)//Si  no existe en la tabla benefit  o si esta desactivada la propiedad en el contrato, entonces trae la propiedad
        //                      .Select(n=> new RealEstatePropertyModel { 
        //                      RealEstatePropertyID = n.RealEstatePropertyID,
        //                      Description = n.Description,
        //                      RealEstateLocation = n.RealEstateLocation,
        //                      RealEstateLocationID = n.RealEstateLocationID,
        //                      RealEstatePropertyType = n.RealEstatePropertyType,
        //                      RealEstatePropertyTypeID = n.RealEstatePropertyTypeID,
        //                      Active = n.Active
        //                      })
        //                      .ToList();

        //    return lstAvailableProperties;
        //}
    }
}
