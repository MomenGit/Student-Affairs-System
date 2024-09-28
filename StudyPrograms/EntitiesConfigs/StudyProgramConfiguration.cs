using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.EntitiesConfigs;
using StudyPrograms.Entities;

namespace StudyPrograms.EntitiesConfigs;

public class StudyProgramConfiguration : BaseEntityConfiguration<StudyProgram>
{
    public override void Configure(EntityTypeBuilder<StudyProgram> builder)
    {
        base.Configure(builder);

        builder.Property(sp => sp.Name)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(sp => sp.Degree)
            .HasConversion<string>();

        builder.Property(sp => sp.DefaultSemesterStartSeason)
            .HasConversion<string>();

        builder.HasOne(sp => sp.Department)
            .WithMany()
            .HasForeignKey(sp => sp.DepartmentId);
    }
}