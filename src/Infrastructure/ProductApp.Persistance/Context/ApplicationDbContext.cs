using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Persistance.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.ChangeTracker.LazyLoadingEnabled = true;
            this.ChangeTracker.AutoDetectChangesEnabled = true;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableDetailedErrors();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }


        public DbSet<Product> Product { get; set; }
    }
}
