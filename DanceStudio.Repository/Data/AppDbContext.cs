using DanceStudio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DanceStudio.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<DanceClass> DanceClasses { get; set; }
    }
}
