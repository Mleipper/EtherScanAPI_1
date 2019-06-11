using EtherScanAPI.JSONModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtherScanAPI.Controllers
{
    public class CurrencyAPI
    {
        
        JSONGetter jSONGetter;
        public CurrencyAPI()
        {

            jSONGetter = new JSONGetter();
        }

        private string APIKey = "?access_key=4c127497a24a5c6b42745ca8cec76dd4";
        private string URLBase = "http://data.fixer.io/api/";
        private string currencies = "&symbols=USD,GBP,CAD,CNY,AUD,JPY";
        /// <summary>
        /// gets a JSON containing the values of USD,GBP,CAD,CNY,AUD,JPY against the EURO
        /// </summary>
        /// <returns>Currency object</returns>
        public Currency getLatestRates()
        {
             string response = jSONGetter.makeRequest(URLBase + "latest" + APIKey + currencies);
            var Jbalance = JsonConvert.DeserializeObject<Currency>(response);
            return Jbalance;
        }

    }
}
