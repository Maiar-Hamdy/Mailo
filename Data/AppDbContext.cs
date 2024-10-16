﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Mailo.Data.Enums;
using Mailo.Models;

namespace Mailo.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Productss>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
			modelBuilder.Entity<OrderProduct>().ToTable("OrderProduct");
			modelBuilder.Entity<Review>().ToTable("Review");
			modelBuilder.Entity<Payment>().ToTable("Payment");
			modelBuilder.Entity<Wishlist>().ToTable("Wishlist");
            //modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<User>().ToTable("User");


            modelBuilder.Entity<Productss>()
          .HasKey( p => new { p.ID });
            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderID, op.ProductID });
			modelBuilder.Entity<OrderProduct>()
		   .HasOne(op => op.order)
		   .WithMany(o => o.OrderProducts)
		   .HasForeignKey(op => op.OrderID);

			modelBuilder.Entity<OrderProduct>()
				.HasOne(op => op.product)
				.WithMany(p => p.OrderProducts)
				.HasForeignKey(op => op.ProductID);

		

			

			modelBuilder.Entity<Wishlist>().HasKey(op => new { op.UserID, op.ProductID });
			modelBuilder.Entity<Wishlist>()
		   .HasOne(w => w.user)
		   .WithMany(u => u.wishlist)
		   .HasForeignKey(w => w.UserID);

			modelBuilder.Entity<Wishlist>()
				.HasOne(w => w.product)
				.WithMany(p => p.wishlists)
				.HasForeignKey(w => w.ProductID);

			modelBuilder.Entity<Review>().HasKey(op => new { op.UserID, op.ProductID });
			modelBuilder.Entity<Review>()
		   .HasOne(r => r.user)
		   .WithMany(u => u.reviews)
		   .HasForeignKey(r => r.UserID);

			modelBuilder.Entity<Review>()
				.HasOne(r => r.product)
				.WithMany(p => p.reviews)
				.HasForeignKey(r => r.ProductID);
            modelBuilder.Entity<User>()
            .HasIndex(u => u.PhoneNumber)
            .IsUnique();
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
            modelBuilder.Entity<Productss>()
            .HasIndex(u => u.Name)
            .IsUnique();
            modelBuilder.Entity<Productss>()
            .HasIndex(op => new { op.ID, op.Colors,op.Size })
            .IsUnique();
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
            modelBuilder.Entity<Productss>().Property(x => x.TotalPrice).HasComputedColumnSql("[Price]-([Discount]/100)*[Price]");
            modelBuilder.Entity<User>().Property(x => x.FullName).HasComputedColumnSql("[FName]+' '+[LName]");

            #region User Data
            modelBuilder.Entity<User>()
				.HasData(
					new User { ID = 1, FName = "Yara", LName = "Emad Eldien", Username = "Yara_Emad4869", PhoneNumber = "+201127769084", Email = "Yara.Emad4869@gmail.com", Password = "YaraEmad4869", Gender = Gender.Female, UserType = UserType.Client, Address = "Al-Rawda Street, Off the Nile Courniche, Beni Suef" }
				);
			#endregion
			
			foreach (var rel in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				rel.DeleteBehavior = DeleteBehavior.Restrict;
			}
		}

		public DbSet<User> Users { get; set; }
        public DbSet<Productss> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Review>Reviews { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
