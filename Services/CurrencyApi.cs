using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Ajax.Utilities;
using Ninject;
using Persistence.DataBase.Web;
using Services.Web;

namespace Services
{
   public  class CurrencyApi
    {

        IUSDRate _CurrencyRate;
        public CurrencyApi(IUSDRate currencyRate):this()
        {
            _CurrencyRate = currencyRate;
        }
        public CurrencyApi()
        {
          
        }
        public async Task<CurrencyRatedModel> getCurrencyOthers()
        {
            CurrencyRatedModel currencyRated;
            CurrencyRatedModel eistCurrencyToday = _CurrencyRate.ExistUSdRate(DateTime.Today);
            if (eistCurrencyToday == null)
            {
                string Url = "https://do.scotiabank.com/banca-personal/tarifas/tasas-de-cambio.html";
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
                client.DefaultRequestHeaders.Accept.Clear();
                var response = await client.GetStringAsync(Url);

                currencyRated = new CurrencyRatedModel()
                {
                    CurrencyName= "USD"
                    ,dateCheck= DateTime.Today,
                    Price=  ParceHtml(response)

                };

                currencyRated = await _CurrencyRate.InsertRateCurrency(currencyRated);
            }
            else
            {
                currencyRated = eistCurrencyToday;
            }


            //****************************************************************************************************
            //*********************************

            return currencyRated;

        }
        public async Task<BackCentralUsdDto> getCurrencyFromCentralB()
        {
            using (var client = new HttpClient())
            {
                BackCentralUsdDto currencyRated;

                string Url = "https://bancentral.gov.do/HOME/GETACTUALeXCHANGERATE";
                HttpResponseMessage respons = client.GetAsync(Url).Result;
                
                if (respons.IsSuccessStatusCode)
                {
                    var ccurrencyRated = await respons.Content.ReadAsStringAsync();
                    currencyRated = JsonSerializer.Deserialize<BackCentralUsdDto>(ccurrencyRated);
                }
                else
                {
                    return null;
                }


                return currencyRated;
            }
            

        }
        public decimal ParceHtml(string html)
        {
            decimal result = 0;
            try
            {
                HtmlDocument htmldoc = new HtmlDocument();
                htmldoc.LoadHtml(html);
                var ele = htmldoc.DocumentNode.Descendants("tr")
                    .Where(n => n.InnerText.Contains("Dólar (USD) Canales Digitales*")).ToList();

                int index = ele[0].InnerText.Trim().IndexOf('*');
                result = Convert.ToDecimal(ele[0].InnerText.Substring(index + 3, 5));

            }
            catch (Exception)
            {

                result = 0;
            }


            return result;




        }
    }
}
