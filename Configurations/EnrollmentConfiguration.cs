using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TmsApi.Entities.Models;

namespace TmsApi.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        // Composite Primary Key
        builder.HasKey(e => new { e.StudentId, e.CourseId });

        // EnrolledAt configuration
        builder.Property(e => e.EnrolledAt)
            .IsRequired();

        // Student → Enrollment (1-to-many)
        builder.HasOne(e => e.Student)
            .WithMany(static s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Course → Enrollment (1-to-many)
        builder.HasOne(e => e.Course)
            .WithMany(static c => c.Enrollments)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}