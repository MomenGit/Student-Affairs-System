using Courses.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.EntitiesConfigs;

namespace Courses.EntitiesConfigs;

public class CourseConfiguration : BaseEntityConfiguration<Course>
{
    public override void Configure(EntityTypeBuilder<Course> builder)
    {
        base.Configure(builder);

        // Define the many-to-many relationship for prerequisites
        builder
            .HasMany(c => c.Prerequisites)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "CoursePrerequisite", // Join table
                j =>
                    j.HasOne<Course>().WithMany().HasForeignKey("PrerequisiteId"),
                j =>
                    j.HasOne<Course>().WithMany().HasForeignKey("CourseId"));

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.Credits)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(c => c.Credits)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(c => c.RecommendedSemester)
            .IsRequired();

        builder.HasOne(s => s.StudyProgram)
            .WithMany()
            .HasForeignKey(s => s.StudyProgramId);
    }
}