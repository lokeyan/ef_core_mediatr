using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace DataAccess.Context
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set;}
        public DbSet<Subscription> Subscriptions { get; set; }

        public CustomerContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite()
             .EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>()
                .ToTable("Customers");

            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Customer>()
                .Property(c => c.SubscriptionLevel)
                .HasConversion<string>();

            modelBuilder.Entity<Subscription>()
                .ToTable("SubscriptionLevels");

            modelBuilder.Entity<Subscription>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Subscription)
                .WithMany()
                .HasForeignKey(c => c.Subscription);

            base.OnModelCreating(modelBuilder);
        }

    }
}
