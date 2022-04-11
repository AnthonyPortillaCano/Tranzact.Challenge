﻿// <auto-generated />
using System;
using Challenge.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Challenge.Data.Migrations
{
    [DbContext(typeof(StoreDatabaseContext))]
    [Migration("20220410001051_pruebaSqlMigration")]
    partial class pruebaSqlMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Challenge.Data.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Challenge.Data.Models.ProductDetail", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("ProductId");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("Challenge.Data.Models.ProductDetail", b =>
                {
                    b.HasOne("Challenge.Data.Models.Product", "Product")
                        .WithOne("ProductDetail")
                        .HasForeignKey("Challenge.Data.Models.ProductDetail", "ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductDetail_Product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Challenge.Data.Models.Product", b =>
                {
                    b.Navigation("ProductDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
