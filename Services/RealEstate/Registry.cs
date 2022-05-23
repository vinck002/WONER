using Microsoft.EntityFrameworkCore;
using OwnerDataExt;
using Persistence.DataBase.RealEstateMoldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RealEstate
{
    public class Registry
    {
        public RealEstateRegistryModel GetRealEstateRegistryById(Int64 Id)
        {
            using (var ctx = new OwneDbContext())
            {

                var OwnerRegistry = ctx.RealEstateRegistry.Where(x => x.RealEstateRegistryID == Id)
                    .FirstOrDefault();

                return OwnerRegistry;
            }
        }

        public static void Insert(DbContext ctx, object entity)
        {
            ctx.Add(entity);
            ctx.SaveChanges();
        }
        public static void Update(DbContext ctx, object entity)
        {
            ctx.Update(entity);
            ctx.SaveChanges();
        }
        public static void InsertOrUpdate(DbContext ctx, RealEstateRegistryModel entity)
        {
            ctx.Update(entity);
            ctx.SaveChanges();
        }


    }
}
