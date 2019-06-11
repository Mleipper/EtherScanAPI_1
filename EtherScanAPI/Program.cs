using EtherScanAPI.Controllers;
using EtherScanAPI.Data;
using EtherScanAPI.DBmodel;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EtherScanAPI
{//0x126bF276bA4C7111dbddbb542718CfF678C9b3Ce,0xde0b295669a9fd93d5f28d9ec85e40f4cb697bae
    class Program
    {
       
        
        static void Main(string[] args)
        {   string testEther = "0x9B497Cb396E5f28e4129e75F0B65F1aa6a244059";
            Controllers.Class1 etherScan = new Controllers.Class1();
            //Controllers.API etherScan = new Controllers.API();
            //etherScan.endPoint = "https://api.etherscan.io/api?module=account&action=balance&address=0xde0b295669a9fd93d5f28d9ec85e40f4cb697bae&tag=latest&apikey=YourApiKeyToken";
            string strResponse = string.Empty;
            WalletDetails walletDetails = new WalletDetails()
            {
                etherAddress = testEther
            };

            using (var context = new ApplicationDbContext())
            {
                Seed(context);
                foreach(var wallet in context.WalletDetails.ToList())
                {
                    strResponse = etherScan.processWalletDetails(wallet);
                    context.Update(wallet);
                    context.SaveChanges();
                }               
            }
            //ExchangeRateUpdater updater = new ExchangeRateUpdater();
            //updater.EtherExchangeRateUpdate();
            //CurrencyAPI currency = new CurrencyAPI();
            //currency.getLatestRates();
            //strResponse = etherScan.makeRequest();
            //Console.WriteLine(strResponse);
            //strResponse = etherScan.getCurrentBalance();

            Console.WriteLine("");
            Console.WriteLine(strResponse);
            //string json = etherScan.deserializeJSON(strResponse);
           // Console.WriteLine(json);
            

            //long longResponse = etherScan.convertToLong("10");
            Console.WriteLine("");
            //Console.WriteLine(longResponse);
            //longResponse = etherScan.convertToLong("1000000000000000000000000000");
            //Console.WriteLine("");
            //Console.WriteLine(longResponse);
            Console.ReadLine();
        }


        public static void Seed(ApplicationDbContext context)
        {
            if(!context.WalletDetails.Any())
            {
                
                using (StreamReader r = new StreamReader(".\\json1.json"))
                {
                    var json = r.ReadToEnd();
                    var ethers = JsonConvert.DeserializeObject<dynamic>(json);
                    foreach (var ether in ethers.ether)
                    {
                        Console.WriteLine("{0}", ether);
                        var wallet1 = new WalletDetails()
                        {
                            etherAddress = ether
                        };

                        context.Add(wallet1);
                    }
                }



                context.SaveChanges();
            }
        }
    }
}
