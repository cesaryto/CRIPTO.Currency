﻿// <auto-generated />
using Currency.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Currency.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Currency")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Currency.Domain.Coin", b =>
                {
                    b.Property<int>("coinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("csupply")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("market_cap_usd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("msupply")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("percent_change_1h")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("percent_change_24h")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("percent_change_7d")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("price_btc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("price_usd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rank")
                        .HasColumnType("int");

                    b.Property<string>("symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tsupply")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("volume24")
                        .HasColumnType("int");

                    b.Property<int>("volume24a")
                        .HasColumnType("int");

                    b.HasKey("coinId");

                    b.ToTable("Coins");
                });
#pragma warning restore 612, 618
        }
    }
}
