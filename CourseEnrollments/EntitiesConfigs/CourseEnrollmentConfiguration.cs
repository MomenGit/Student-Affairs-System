using CourseEnrollments.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.EntitiesConfigs;

namespace CourseEnrollments.EntitiesConfigs;

public class CourseEnrollmentConfiguration : BaseEntityConfiguration<CourseEnrollment>
{
    public override void Configure(EntityTypeBuilder<CourseEnrollment> builder)
    {
        base.Configure(builder);

        // builder.HasKey(ce => new { ce.StudentId, ce.SemesterCourseId });

        builder.Property(ce => ce.Comment).HasMaxLength(255);

        builder.HasOne(ce => ce.Student)
            .WithMany()
            .HasForeignKey(ce => ce.StudentId);

        builder.HasOne(ce => ce.SemesterCourse)
            .WithMany()
            .HasForeignKey(ce => ce.SemesterCourseId);

        // Configure EnrollmentDate to be required
        builder
            .Property(ce => ce.EnrollmentDate)
            .IsRequired();

        // Configure Score and GradeValue to be required
        builder
            .Property(ce => ce.Score)
            .IsRequired()
            .HasPrecision(5, 2); // For example, maximum of 999.99

        builder
            .Property(ce => ce.GradeValue)
            .IsRequired()
            .HasPrecision(4, 2); // Adjust according to the maximum grade


        builder.Property(enrollment => enrollment.Status)
            .HasConversion<string>();
    }
}