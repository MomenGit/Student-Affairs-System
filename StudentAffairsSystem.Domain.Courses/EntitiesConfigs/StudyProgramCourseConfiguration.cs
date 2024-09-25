using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAffairsSystem.Domain.Courses.Entities;
using StudentAffairsSystem.Shared.EntitiesConfigs;

namespace StudentAffairsSystem.Domain.Courses.EntitiesConfigs;

public class StudyProgramCourseConfiguration : BaseDateTraceConfiguration<StudyProgramCourse>
{
    public override void Configure(EntityTypeBuilder<StudyProgramCourse> builder)
    {
        builder.HasKey(spc => new { spc.StudyProgramId, spc.CourseId });

        builder.HasOne(spc => spc.StudyProgram)
            .WithMany()
            .HasForeignKey(spc => spc.StudyProgramId);

        builder.HasOne(spc => spc.Course)
            .WithMany()
            .HasForeignKey(spc => spc.CourseId);
    }
}