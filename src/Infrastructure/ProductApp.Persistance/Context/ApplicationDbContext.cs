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
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Name = "Pen", Value = 10, Quantity = 100 ,CreateDate=DateTime.Now},
                new Product() { Id = Guid.NewGuid(), Name = "Pencil", Value = 7, Quantity = 50, CreateDate = DateTime.Now },
                new Product() { Id = Guid.NewGuid(), Name = "Paper", Value = 1, Quantity = 1000, CreateDate = DateTime.Now },
                new Product() { Id = Guid.NewGuid(), Name = "Book", Value = 50, Quantity = 500, CreateDate = DateTime.Now }
                );
            base.OnModelCreating(modelBuilder); 


        }


        public DbSet<Product> Products { get; set; }
    }
}
