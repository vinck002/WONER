using Persistence.DataBase.RealEstateMoldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExchangeRate
{
    public interface IExchangeRateDay
    {
        decimal GetCurrency();
        List<ExchangeRateDayModel> CurrencyList();
        List<ExchangeRateDayModel> CurrencyListByRange(DateTime start, DateTime End);

    }
}
