﻿using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Database
{
    public class PartShopDbContext : DbContext
    {
        public PartShopDbContext() : base("DBConnection") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasMany(x => x.Parts).WithMany(x => x.Orders).Map(
                m =>
                {
                    m.ToTable("PartsInOrder")
                    .MapLeftKey("OrderId")
                    .MapRightKey("PartId");
                });

        }
    }
}
