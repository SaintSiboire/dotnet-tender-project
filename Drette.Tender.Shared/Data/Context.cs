﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drette.Tender.Shared.Models;

namespace Drette.Tender.Shared.Data
{
    public class Context : IdentityDbContext<User>
    {
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<InventoryInput> InventoryInputs { get; set; }
        public DbSet<InventoryOutput> InventoryOutputs { get; set; }
        public DbSet<ProductModification> ProductModifications { get; set; }

        public Context()
            :base("Context")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Removing the pluralizing table name convention 
            // so our table names will use our entity class singular names.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Using the fluent API to configure entity properties...

            modelBuilder.Entity<ProductModification>()
                .Property(i => i.ModificationDate)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Product>()
                .Property(i => i.Date)
                .HasColumnType("datetime2");

            modelBuilder.Entity<InventoryInput>()
            .Property(i => i.Date)
            .HasColumnType("datetime2");
        }
    }
}
