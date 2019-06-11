using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EtherScanAPI.DBmodel
{
    public class ExchangeRates
    {
        [Key]
        public int id { get; set; }
        public int TimeStamp { get; set; }
        public double EtherToUSD { get; set; }// ether to US Dollar 
        public double ETherToGBP { get; set; }// ether to Great British Pound 
        public double EtherToCNY { get; set; }// ether to Chinese Yuan
        public double EtherToAUD { get; set; }// ether to Aussie Dollar
        public double EtherToJPY { get; set; }// ether to japanese yen
        public double EtherToCAD { get; set; }// ether to canadian dollar
        public double EtherToEuro { get; set; }// ether to Euro
    }
}
