using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using EtherScanAPI.JSONModel;
using Newtonsoft.Json;

namespace EtherScanAPI.Controllers
{
   
   
    public class EtherAPI
    {
        private DateTime _cutOffDate = new DateTime(2017, 05, 1);
        private string apiKey = "9MMY4T9EI73BUKTQAU14IHDQ1857J8JAAN";
        private string stats = "stats&action=ethprice&apikey=";
        private string _account = "account&action=";
        private string _txlist = "txlist&address=";
        private string _balance = "balance&address=";
        private string baseUri = "https://api.etherscan.io/api?module=";
        
       

        JSONGetter _jSONGetter;
        public EtherAPI()
        {
            _jSONGetter = new JSONGetter();
        }
        /// <summary>
        /// gets a json object that contains etherToUSD 
        /// </summary>
        /// <returns></returns>
        public APIStats getEtherToUSD()
        {
            string Response = _jSONGetter.makeRequest(baseUri + stats + apiKey);

            var jresponse = JsonConvert.DeserializeObject<APIStats>(Response);
            return jresponse;


        }

        public List<APINormalTransactionsModel.res> getEtherTransactions(string etherAddress, string startBlock = "0")
        {
            Console.WriteLine("Getting transactions for " + etherAddress);
            string endPoint = baseUri + _account+_txlist + etherAddress + "&startblock=" + startBlock + "&endblock=99999999&sort=asc&apikey=" + apiKey;
            string response = string.Empty;
            response = _jSONGetter.makeRequest(endPoint);
            try
            {
                var jTransactions = JsonConvert.DeserializeObject<APINormalTransactionsModel>(response);
                return jTransactions.result.OrderByDescending(t => t.blockNumber).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception" + e.Message);
                response = _jSONGetter.makeRequest(endPoint);
            }


            return new List<APINormalTransactionsModel.res>();
        }

        public string getCurrentBalance(string etherAddress)
        {
            Console.WriteLine("Getting current balance for " + etherAddress);
            string endPoint = baseUri +  _account+ _balance  + etherAddress + "&tag=latest&apikey=" + apiKey;
            string response = string.Empty;
            response = _jSONGetter.makeRequest(endPoint);
            var Jbalance = JsonConvert.DeserializeObject<APIBalanceSingle>(response);
            // sets the current balance of the class equal to the returned long.  

            return Jbalance.result;
        }

    }



}
