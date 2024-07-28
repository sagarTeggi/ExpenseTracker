using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
    public class DBContext : DbContext
    {
        
        public DBContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Category> Category { get; set; }


    }
}
