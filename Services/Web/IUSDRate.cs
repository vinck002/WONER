using Persistence.DataBase.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Web
{
    public interface IUSDRate
    {
        Task<List<CurrencyRatedModel>> getUSdRate();
        CurrencyRatedModel ExistUSdRate(DateTime today);
        Task<CurrencyRatedModel> InsertRateCurrency(CurrencyRatedModel currencyRated);
    }
}
