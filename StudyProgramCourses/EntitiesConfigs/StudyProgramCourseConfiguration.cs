using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.EntitiesConfigs;
using StudyProgramCourses.Entities;

namespace StudyProgramCourses.EntitiesConfigs;

public class StudyProgramCourseConfiguration : BaseEntityConfiguration<StudyProgramCourse>
{
    public override void Configure(EntityTypeBuilder<StudyProgramCourse> builder)
    {
        // builder.HasKey(spc => new { spc.StudyProgramId, spc.CourseId });

        builder.HasOne(spc => spc.StudyProgram)
            .WithMany()
            .HasForeignKey(spc => spc.StudyProgramId);

        builder.HasOne(spc => spc.Course)
            .WithMany()
            .HasForeignKey(spc => spc.CourseId);
    }
}