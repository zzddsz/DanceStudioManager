using DanceStudio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DanceStudio.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

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

            // ==============================================================
            // FORÇANDO A CRIAÇÃO DAS TABELAS (Sem depender de arquivos Map)
            // ==============================================================

            // Tabela DanceClass
            modelBuilder.Entity<DanceClass>(entity =>
            {
                entity.ToTable("DanceClass"); // Nome exato no banco
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            // Tabela Student
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            // Tabela Teacher
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            // Tabela Enrollment
            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("Enrollment");
                entity.HasKey(e => e.Id);

                // Relacionamentos
                entity.HasOne(e => e.Student)
                      .WithMany()
                      .HasForeignKey(e => e.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.DanceClass)
                      .WithMany()
                      .HasForeignKey(e => e.DanceClassId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}