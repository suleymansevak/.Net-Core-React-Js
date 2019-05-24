using LaurelManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaurelManagement.Data
{
    public class LaurelDbContext : DbContext
    {
        //public LaurelDbContext(DbContextOptions<LaurelDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=LaurelDatabase; Trusted_Connection=true");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users  { get; set; }  
        public DbSet<Product> Products { get; set; }
        
    }
}
