using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.DBContext
{
    public class DBContext : DbContext
    {
        
        public DBContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Category> Category { get; set; }


    }
}
