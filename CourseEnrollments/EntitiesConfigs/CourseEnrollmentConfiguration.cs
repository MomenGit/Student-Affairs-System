using CourseEnrollments.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.EntitiesConfigs;

namespace CourseEnrollments.EntitiesConfigs;

public class CourseEnrollmentConfiguration : BaseDateTraceConfiguration<CourseEnrollment>
{
    public override void Configure(EntityTypeBuilder<CourseEnrollment> builder)
    {
        base.Configure(builder);

        builder.HasKey(ce => new { ce.StudentId, ce.SemesterCourseId });

        builder.Property(ce => ce.Comment).HasMaxLength(255);

        builder.HasOne(ce => ce.Student)
            .WithMany()
            .HasForeignKey(ce => ce.StudentId);

        builder.HasOne(ce => ce.SemesterCourse)
            .WithMany()
            .HasForeignKey(ce => ce.SemesterCourseId);


        builder.Property(enrollment => enrollment.Status)
            .HasConversion<string>();
    }
}