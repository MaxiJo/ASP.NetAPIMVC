using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Context
{
    public class APIContext : DbContext
    {
        public APIContext() : base("myConection") { }
        public DbSet<Supplier> Suppliers{ get; set; }
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasRequired<Supplier>(d => d.Suppliers)
                .WithMany(i => i.Items)
                .HasForeignKey<int>(e => e.supplierId);
        }
    }
}