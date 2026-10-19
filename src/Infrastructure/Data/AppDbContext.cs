using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; } = null!;
    }
}