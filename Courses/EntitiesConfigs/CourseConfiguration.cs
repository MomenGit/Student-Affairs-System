using Courses.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.EntitiesConfigs;

namespace Courses.EntitiesConfigs;

public class CourseConfiguration : BaseEntityConfiguration<Course>
{
    public override void Configure(EntityTypeBuilder<Course> builder)
    {
        base.Configure(builder);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Description).IsRequired().HasMaxLength(1000);
        builder.Property(c => c.Credits).IsRequired().HasMaxLength(10);
        builder.HasOne(s => s.StudyProgram)
            .WithMany()
            .HasForeignKey(s => s.StudyProgramId);
    }
}