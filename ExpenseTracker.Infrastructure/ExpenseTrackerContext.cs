using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure
{
    public class ExpenseTrackerContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Database=localhost;Database=ExpenseTracker;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
