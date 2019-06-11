
using EtherScanAPI.DBmodel;
using EtherScanAPI.JSONModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace EtherScanAPI.Controllers
{
    public class Class1
    {
        // date used for searching highest balances too. 
        private DateTime _cutOffDate = new DateTime(2017,05,1);

        public const int MIN_LENGTH = 13;
        public const int MAX_LENGTH = 18;
        public enum isError
        {
            OK = 0
        }
        public enum tranactionStatus
        {
            OK=1
        }



        EtherAPI etherAPI;
        public Class1()
        {

            etherAPI = new EtherAPI();


        }
     
        
        /// <summary>
        /// converts ether amount stored as a long to an double
        /// </summary>
        /// <param name="etherAmount"></param>
        /// <returns></returns>
        public double convertToDouble(long etherAmount)
        {

            double result= etherAmount/Math.Pow(10, MAX_LENGTH - MIN_LENGTH);
            return result;
        }

        // converts string to a long returns - 1 in the event of a error.  
        public long convertToLong(string etherAmount)
        {
            if (etherAmount.Length<= MIN_LENGTH)
            {
                return 0;
            }
            else
            {
                etherAmount = etherAmount.Remove(etherAmount.Length - MIN_LENGTH);
                long result=-1;// value if error has occurred 
                try
                {
                    result = Convert.ToInt64(etherAmount);
                    Console.WriteLine(" ether amoount in is "+ result);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("{0} is outside the range of the Int64 type.", etherAmount);
                }
                catch (FormatException)
                {
                    Console.WriteLine("The {0} value '{1}' is not in a recognizable format.",
                                      etherAmount.GetType().Name, etherAmount);
                }
                return result;
            }
        }





        public long getHighestBalance(List<APINormalTransactionsModel.res> transList, string etherAddress, long curBalance)
        {
            int latestBlock = -1;
            var firstTrans = transList.FirstOrDefault(); //transList.First().blockNumber;
            if (firstTrans!=null)
            {
                 latestBlock = firstTrans.blockNumber;

            }
            long highestBalance = curBalance;
            long curBlockBal = highestBalance;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var unixDateTime = (_cutOffDate.ToUniversalTime() - epoch).TotalSeconds;

            foreach (var transaction in transList)
            {

                if (isValidTransation(unixDateTime, transaction.timeStamp, (int)transaction.isError))
                {
                    if (etherAddress.Equals(transaction.from, StringComparison.OrdinalIgnoreCase))
                    {
                        curBlockBal += convertToLong(transaction.value);
                    }
                    if (etherAddress.Equals(transaction.to, StringComparison.OrdinalIgnoreCase))
                    {
                        curBlockBal -= convertToLong(transaction.value);
                    }

                    if (curBlockBal > highestBalance)
                    {
                        highestBalance = curBlockBal;
                    }
                }
            }
            return highestBalance;
        }

        public int getLatestBlk(List<APINormalTransactionsModel.res> listTrans)
        {

            var firstTrans = listTrans.FirstOrDefault();
            int blockNum = -1;
            if (firstTrans != null)
            {
                blockNum = firstTrans.blockNumber;
            }
            return blockNum;
        }
        public string processWalletDetails(WalletDetails theWallet)
        {
            
            long bal = convertToLong(etherAPI.getCurrentBalance(theWallet.etherAddress));
            theWallet.etherBalance = convertToDouble(bal);
            Thread.Sleep(300);
            var listTrans = etherAPI.getEtherTransactions(theWallet.etherAddress);
            
            Thread.Sleep(200);
          
            theWallet.blockNumber = getLatestBlk(listTrans);
            if (listTrans.Count() != 0)
            {
                theWallet.highestBalance =convertToDouble( getHighestBalance(listTrans, theWallet.etherAddress, bal));
            }
            else theWallet.highestBalance = 0;
            
            return " Successfully processed all data. "; 
        }

       

        private bool isValidTransation(double earliestTime, long transTime, int status)
        {
            return ((earliestTime < transTime) && status == (int)isError.OK);
        }
      
    }
}
