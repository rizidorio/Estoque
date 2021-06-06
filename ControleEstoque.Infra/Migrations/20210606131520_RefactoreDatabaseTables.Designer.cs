﻿// <auto-generated />
using System;
using ControleEstoque.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleEstoque.Infra.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20210606131520_RefactoreDatabaseTables")]
    partial class RefactoreDatabaseTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("ControleEstoque.Domain.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("ChangeDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2021, 6, 6, 10, 15, 20, 405, DateTimeKind.Local).AddTicks(5401));

                    b.Property<decimal>("Cust")
                        .HasColumnType("decimal(15,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Inactive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("SKU")
                        .IsUnique();

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entity.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entity.StockMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateMovement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2021, 6, 6, 10, 15, 20, 411, DateTimeKind.Local).AddTicks(6666));

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.Property<int>("StokId")
                        .HasColumnType("int");

                    b.Property<string>("TypeStokMov")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("StockMovement");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entity.StockMovement", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entity.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId");

                    b.Navigation("Stock");
                });
#pragma warning restore 612, 618
        }
    }
}
