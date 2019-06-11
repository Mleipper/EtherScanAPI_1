using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EtherScanAPI.DBmodel
{
    public class WalletDetails
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string etherAddress { get; set; }
        public double etherBalance { get; set; }
        public int blockNumber { get; set; }
        public double highestBalance { get; set; }


    }
}
