using Microsoft.EntityFrameworkCore;
using DanceStudioManager.Models;

namespace DanceStudioManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DanceClass> DanceClasses { get; set; }
    }
}
