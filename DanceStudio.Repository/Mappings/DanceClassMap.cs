using DanceStudio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanceStudio.Repository.Mapping
{
    public class DanceClassMap : IEntityTypeConfiguration<DanceClass>
    {
        public void Configure(EntityTypeBuilder<DanceClass> builder)
        {
            builder.ToTable("DanceClass");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(prop => prop.Teacher)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(prop => prop.DayOfWeek)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(prop => prop.Time)
                .IsRequired();

            builder.Property(prop => prop.MaxStudents)
                .IsRequired();
        }
    }
}