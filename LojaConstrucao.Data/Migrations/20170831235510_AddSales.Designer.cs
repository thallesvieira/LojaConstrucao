using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LojaConstrucao.Data.Contexts;

namespace LojaConstrucao.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170831235510_AddSales")]
    partial class AddSales
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LojaConstrucao.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LojaConstrucao.Domain.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("StockQuantity");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LojaConstrucao.Domain.Sales.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientName");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int?>("ItemId");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("LojaConstrucao.Domain.Sales.SaleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleItem");
                });

            modelBuilder.Entity("LojaConstrucao.Domain.Products.Product", b =>
                {
                    b.HasOne("LojaConstrucao.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("LojaConstrucao.Domain.Sales.Sale", b =>
                {
                    b.HasOne("LojaConstrucao.Domain.Sales.SaleItem", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("LojaConstrucao.Domain.Sales.SaleItem", b =>
                {
                    b.HasOne("LojaConstrucao.Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
        }
    }
}
