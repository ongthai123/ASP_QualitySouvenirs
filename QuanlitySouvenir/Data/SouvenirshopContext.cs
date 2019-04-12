using System;
using Microsoft.EntityFrameworkCore;
using QuanlitySouvenir.Models;

namespace QuanlitySouvenir.Data
{
    public class SouvenirshopContext:DbContext
    {
        public SouvenirshopContext(DbContextOptions<SouvenirshopContext> options):base(options)
        {
        }

        //DbSet<TEntity> classes are added as properties to the DbContext and are mapped by default to database tables that take the name of the DbSet<TEntity> property
        public DbSet<Souvenir> Souvenirs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Souvenir>().ToTable("Souvenir");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
        }
    }
}
