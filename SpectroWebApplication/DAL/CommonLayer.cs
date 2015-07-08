using SpectroWebApplication.Models;
using System.Data.Entity;

namespace SpectroWebApplication.DAL
{
    public class SpectroContext : DbContext
    {
        public SpectroContext() : base("DefaultConnection")
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}