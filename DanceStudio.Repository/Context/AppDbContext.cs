using DanceStudio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DanceStudio.Repository.Context
{
    public class AppDbContext : DbContext
    {
        // 1. CONSTRUTOR VAZIO (Essencial para Migrations)
        public AppDbContext() { }

        // 2. CONSTRUTOR PADRÃO (Essencial para o App)
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

            // --- AULA (DanceClass) ---
            modelBuilder.Entity<DanceClass>(entity =>
            {
                entity.ToTable("DanceClass");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();

                // IMPORTANTE: Se deletar o Professor, o campo na aula vira NULL (não apaga a aula)
                entity.HasOne(e => e.Teacher)
                      .WithMany(t => t.DanceClass)
                      .HasForeignKey(e => e.TeacherId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // --- ALUNO (Student) ---
            modelBuilder.Entity<Student>(e => {
                e.ToTable("Student");
                e.HasKey(x => x.Id);
            });

            // --- PROFESSOR (Teacher) ---
            modelBuilder.Entity<Teacher>(e => {
                e.ToTable("Teacher");
                e.HasKey(x => x.Id);
            });

            // --- MATRÍCULA (Enrollment) ---
            modelBuilder.Entity<Enrollment>(e => {
                e.ToTable("Enrollment");
                e.HasKey(x => x.Id);
                // Se apagar aluno ou aula, apaga a matrícula junto (Cascade)
                e.HasOne(x => x.Student).WithMany().HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(x => x.DanceClass).WithMany().HasForeignKey(x => x.DanceClassId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}