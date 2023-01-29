using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repository
{
    public class PayzeeProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=PayzeeProject;Trusted_Connection=true");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
