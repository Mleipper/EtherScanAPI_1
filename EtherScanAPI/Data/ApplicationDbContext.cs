using System;
using System.Collections.Generic;
using System.Text;
using EtherScanAPI.DBmodel;
using Microsoft.EntityFrameworkCore;

namespace EtherScanAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string _connString;

        public DbSet<WalletDetails> WalletDetails { get; set; }
        public DbSet<ExchangeRates> ExchangeRates { get; set; }

        public ApplicationDbContext()
        {
            _connString = "Server=.\\MIKE_BMS;persist security info=True;Database=AirdropTestdb2;Trusted_Connection=True;MultipleActiveResultSets=true;App=EntityFramework";
        }

        public ApplicationDbContext(string connection) : base()
        {
            _connString = connection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }
    }
}
