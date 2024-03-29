﻿// <auto-generated />
using LaptopWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaptopWeb.Migrations
{
    [DbContext(typeof(LaptopContext))]
    [Migration("20230526054851_InitialCreate44")]
    partial class InitialCreate44
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LaptopWeb.Models.Laptop", b =>
                {
                    b.Property<int>("LaptopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LaptopId"));

                    b.Property<int>("TrademarkId")
                        .HasColumnType("int");

                    b.Property<string>("card")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpu_compact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link_img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("memory_compact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("past_price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price_real")
                        .HasColumnType("int");

                    b.Property<string>("ram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ram_compact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("screen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("screen_compact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("series")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LaptopId");

                    b.HasIndex("TrademarkId");

                    b.ToTable("Laptops");
                });

            modelBuilder.Entity("LaptopWeb.Models.Trademark", b =>
                {
                    b.Property<int>("TrademarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrademarkId"));

                    b.Property<string>("TrademarkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TrademarkName");

                    b.HasKey("TrademarkId");

                    b.ToTable("Trademarks");
                });

            modelBuilder.Entity("LaptopWeb.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TrademarkName");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Role");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LaptopWeb.Models.Laptop", b =>
                {
                    b.HasOne("LaptopWeb.Models.Trademark", "Trademark")
                        .WithMany("Laptops")
                        .HasForeignKey("TrademarkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trademark");
                });

            modelBuilder.Entity("LaptopWeb.Models.Trademark", b =>
                {
                    b.Navigation("Laptops");
                });
#pragma warning restore 612, 618
        }
    }
}
