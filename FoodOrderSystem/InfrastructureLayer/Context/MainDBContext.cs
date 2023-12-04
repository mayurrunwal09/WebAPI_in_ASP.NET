using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Context
{
    public  class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions option):base(option) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()           
                .HasMany(o=>o.Orders)
                .WithOne(d=>d.Customer)
                .HasForeignKey(C => C.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Food>()
                .HasMany(c=>c.Orders)
                .WithOne(f=>f.Food)
                .HasForeignKey(d=>d.FoodId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
