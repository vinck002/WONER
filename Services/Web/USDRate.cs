using Microsoft.EntityFrameworkCore;
using OwnerDataExt;
using Persistence.DataBase.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Web
{
    public class USDRate : IUSDRate
    {
        public async Task<List<CurrencyRatedModel>> getUSdRate()
        {
            using (var ctx = new OwneDbContext())
            {
               var result = await ctx.CurrencyRate.ToListAsync();
                return result;
            }

           
        }
        public CurrencyRatedModel ExistUSdRate(DateTime todayDate)
        {
            using (var ctx = new OwneDbContext())
            {
                var result =  ctx.CurrencyRate.Where(x=> x.dateCheck == todayDate).FirstOrDefault();
                return result;
            }
        }

        public async Task<CurrencyRatedModel> InsertRateCurrency(CurrencyRatedModel currencyRated)
        {
            using (var ctx = new OwneDbContext())
            {
                CurrencyRatedModel Entity = currencyRated;
                 await ctx.CurrencyRate.AddAsync(Entity);
                await ctx.SaveChangesAsync();
                return Entity;
            }
        }
    }
}
