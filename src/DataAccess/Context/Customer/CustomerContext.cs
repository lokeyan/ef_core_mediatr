﻿using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace DataAccess.Context
{
    public class CustomerContext : DbContext
    {        public CustomerContext()
        {

        }

        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite().EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>(entity =>
           {
               entity.ToTable("Customers");

               entity.HasKey(c => c.Id);

               entity.Property(c => c.Id).ValueGeneratedOnAdd();

               entity.Property(e => e.FirstName).HasColumnType("VARCHAR (100)");

               entity.Property(e => e.LastName).HasColumnType("VARCHAR (100)");

               entity.Property(e => e.Email).HasColumnType("VARCHAR (100)");

               entity.Property(e => e.Phone).HasColumnType("VARCHAR (100)");

               entity.Property(c => c.SubscriptionLevel).HasConversion<string>();

               entity.HasOne(c => c.Subscription)
                      .WithMany()
                      .HasForeignKey(c => c.Subscription);
           });

            modelBuilder.Entity<Subscription>(entity =>
           {
               entity.ToTable("Subscriptions");

               entity.HasKey(c => c.Id);

               entity.Property(c => c.Id).ValueGeneratedOnAdd();

               entity.Property(c => c.Name).HasColumnType("VARCHAR (100)");

               entity.Property(c => c.PricePerMonth).HasColumnType("DECIMAL");

               entity.Property(c => c.NumberOfSimultaneousDevices).HasColumnType("INTEGER");

               entity.Property(c => c.NumberDevicesWithDownloadCapability).HasColumnType("INTEGER");

           });            

            base.OnModelCreating(modelBuilder);
        }

    }
}
