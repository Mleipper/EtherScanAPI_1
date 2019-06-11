﻿// <auto-generated />
using EtherScanAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EtherScanAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EtherScanAPI.DBmodel.ExchangeRates", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ETherToGBP");

                    b.Property<double>("EtherToAUD");

                    b.Property<double>("EtherToCAD");

                    b.Property<double>("EtherToCNY");

                    b.Property<double>("EtherToEuro");

                    b.Property<double>("EtherToJPY");

                    b.Property<double>("EtherToUSD");

                    b.Property<int>("TimeStamp");

                    b.HasKey("id");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("EtherScanAPI.DBmodel.WalletDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("blockNumber");

                    b.Property<string>("etherAddress")
                        .IsRequired();

                    b.Property<double>("etherBalance");

                    b.Property<double>("highestBalance");

                    b.HasKey("id");

                    b.ToTable("WalletDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
