using DanceStudio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanceStudio.Repository.Mapping
{
    public class EnrollmentMap : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Date)
                .IsRequired();


            builder.HasOne(prop => prop.Student)
                .WithMany()
                .HasForeignKey(prop => prop.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(prop => prop.DanceClass)
                .WithMany()
                .HasForeignKey(prop => prop.DanceClassId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}