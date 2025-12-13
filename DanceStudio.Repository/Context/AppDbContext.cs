using DanceStudio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DanceStudio.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DanceClass> DanceClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;database=studio;user=root;password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DanceClass>(entity =>
            {
                entity.ToTable("DanceClass");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(e => e.Teacher)
                      .WithMany(t => t.DanceClass)
                      .HasForeignKey(e => e.TeacherId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Student>(e => {
                e.ToTable("Student");
                e.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Teacher>(e => {
                e.ToTable("Teacher");
                e.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Enrollment>(e => {
                e.ToTable("Enrollment");
                e.HasKey(x => x.Id);
                e.HasOne(x => x.Student).WithMany().HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(x => x.DanceClass).WithMany().HasForeignKey(x => x.DanceClassId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}