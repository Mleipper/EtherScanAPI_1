using EtherScanAPI.Data;
using EtherScanAPI.DBmodel;
using EtherScanAPI.JSONModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtherScanAPI.Controllers
{
    class ExchangeRateUpdater
    {
        private CurrencyAPI currencyAPI;
        private EtherAPI etherAPI;
        public ExchangeRateUpdater()
        {
            currencyAPI = new CurrencyAPI();
            etherAPI = new EtherAPI();

        }

        public void EtherExchangeRateUpdate()
        {
            Currency rates = currencyAPI.getLatestRates();
            
            Console.WriteLine("1 Euro is equal to "+ rates.rates.USD +" US Dollars");
           APIStats EtherRate = etherAPI.getEtherToUSD();
            double EtherUSD = EtherRate.result.ethusd;
            Console.WriteLine("The current rate of Ether in US Dollars is " + EtherUSD);
            double EtherToEuro = EtherUSD / rates.rates.USD;// converts ether usd to ether euro the base for api request.
            using (var context = new ApplicationDbContext())
            {
                ExchangeRates newRates = new ExchangeRates();
                newRates.TimeStamp = rates.timestamp;
                newRates.EtherToUSD = EtherUSD;
                newRates.EtherToEuro = EtherToEuro;
                newRates.EtherToAUD = EtherToEuro * rates.rates.AUD;
                newRates.EtherToCAD = EtherToEuro * rates.rates.CAD;
                newRates.EtherToCNY = EtherToEuro * rates.rates.CNY;
                newRates.ETherToGBP = EtherToEuro * rates.rates.GBP;
                newRates.EtherToJPY = EtherToEuro * rates.rates.JPY;
                context.Add(newRates);
                context.SaveChanges();
            }
            
        }

    }
}
