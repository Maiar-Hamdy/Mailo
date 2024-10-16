﻿// <auto-generated />
using System;
using Mailo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mailo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mailo.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Mailo.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("DeliveryFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DiscountCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("EmpID")
                        .HasColumnType("int");

                    b.Property<string>("OrderAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmpID");

                    b.HasIndex("UserID");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderProduct", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.Productss", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("AdditionDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("Colors")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("decimal(18,2)")
                        .HasComputedColumnSql("[Price]-([Discount]/100)*[Price]");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ID", "Colors", "Size")
                        .IsUnique();

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.Review", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("[FName]+' '+[LName]");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Al-Rawda Street, Off the Nile Courniche, Beni Suef",
                            Email = "Yara.Emad4869@gmail.com",
                            FName = "Yara",
                            Gender = 1,
                            LName = "Emad Eldien",
                            Password = "YaraEmad4869",
                            PhoneNumber = "+201127769084",
                            RegistrationDate = new DateTime(2024, 10, 16, 14, 26, 15, 346, DateTimeKind.Local).AddTicks(8744),
                            UserType = 0,
                            Username = "Yara_Emad4869"
                        });
                });

            modelBuilder.Entity("Mailo.Models.Wishlist", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime>("AdditionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("Wishlist", (string)null);
                });

            modelBuilder.Entity("Mailo.Models.Order", b =>
                {
                    b.HasOne("Mailo.Models.Employee", "employee")
                        .WithMany("orders")
                        .HasForeignKey("EmpID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mailo.Models.User", "user")
                        .WithMany("orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("employee");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Mailo.Models.OrderProduct", b =>
                {
                    b.HasOne("Mailo.Models.Order", "order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mailo.Models.Productss", "product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Mailo.Models.Payment", b =>
                {
                    b.HasOne("Mailo.Models.User", "user")
                        .WithMany("payment")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Mailo.Models.Review", b =>
                {
                    b.HasOne("Mailo.Models.Productss", "product")
                        .WithMany("reviews")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mailo.Models.User", "user")
                        .WithMany("reviews")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Mailo.Models.Wishlist", b =>
                {
                    b.HasOne("Mailo.Models.Productss", "product")
                        .WithMany("wishlists")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mailo.Models.User", "user")
                        .WithMany("wishlist")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Mailo.Models.Employee", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Mailo.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Mailo.Models.Productss", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("reviews");

                    b.Navigation("wishlists");
                });

            modelBuilder.Entity("Mailo.Models.User", b =>
                {
                    b.Navigation("orders");

                    b.Navigation("payment");

                    b.Navigation("reviews");

                    b.Navigation("wishlist");
                });
#pragma warning restore 612, 618
        }
    }
}
