﻿// <auto-generated />
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(CustomerContext))]
    [Migration("20220614132548_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("DataAccess.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR (100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR (100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR (100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("VARCHAR (100)");

                    b.Property<int>("SubscriptionLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionLevel");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("DataAccess.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR (100)");

                    b.Property<int>("NumberDevicesWithDownloadCapability")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfSimultaneousDevices")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PricePerMonth")
                        .HasColumnType("DECIMAL");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions", (string)null);
                });

            modelBuilder.Entity("DataAccess.Models.Customer", b =>
                {
                    b.HasOne("DataAccess.Models.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionLevel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });
#pragma warning restore 612, 618
        }
    }
}
