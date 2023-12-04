using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndService.Context
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options):base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<SupplierItem> Suppliers { get; set; }
        public DbSet<ItemImage> ItemImages { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<CustomerItem> customerItems { get; set; }
        public DbSet<Catagery> catageries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(s => s.UserType)
                .WithMany(s => s.Users)
                .HasForeignKey(s => s.UserTypeId)
                .IsRequired();

            modelBuilder.Entity<SupplierItem>()
                .HasOne(s => s.User)
                .WithMany(s => s.Suppliers)
                .HasForeignKey(s => s.UserId)
                .IsRequired();
                
            modelBuilder.Entity<CustomerItem>()
                .HasOne(s=>s.User)
                .WithMany(s=>s.CustomerItems)
                .HasForeignKey(s => s.UserId)
                .IsRequired();

            modelBuilder.Entity<SupplierItem>()
                .HasOne(b => b.Item)
                .WithOne(b => b.SupplierItem)
                .HasForeignKey<SupplierItem>(s => s.ItemId)
                .IsRequired();

            modelBuilder.Entity<CustomerItem>()
                .HasOne(b => b.Item)
                .WithOne(b => b.CustomerItem)
                .HasForeignKey<CustomerItem>(s => s.ItemId)
                .IsRequired();

            modelBuilder.Entity<ItemImage>()
                .HasOne(b => b.Item)
                .WithMany(b => b.Images)
                .HasForeignKey(s => s.ItemId)
                .IsRequired();

            modelBuilder.Entity<Catagery>()
                .HasMany(b => b.Items)
                .WithOne(b => b.Catagery)
                .HasForeignKey(s => s.catageryId)
                .IsRequired();






        }
    }
}
