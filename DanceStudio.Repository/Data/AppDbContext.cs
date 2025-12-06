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
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
    }
}
