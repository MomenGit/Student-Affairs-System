using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SemesterCourses.Entities;
using Shared.EntitiesConfigs;

namespace SemesterCourses.EntitiesConfigs;

public class SemesterCourseConfiguration : BaseEntityConfiguration<SemesterCourse>
{
    public override void Configure(EntityTypeBuilder<SemesterCourse> builder)
    {
        base.Configure(builder);

        // builder.HasKey(sc => new { sc.CourseId, sc.SemesterId, sc.ProfessorId });

        builder.HasOne(sc => sc.Semester)
            .WithMany()
            .HasForeignKey(sc => sc.SemesterId);

        builder.HasOne(sc => sc.Course)
            .WithMany()
            .HasForeignKey(sc => sc.CourseId);

        builder.HasOne(sc => sc.Professor)
            .WithMany()
            .HasForeignKey(sc => sc.ProfessorId);
    }
}