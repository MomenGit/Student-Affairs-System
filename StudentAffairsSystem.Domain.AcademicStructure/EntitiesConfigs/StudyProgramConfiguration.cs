using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAffairsSystem.Domain.AcademicStructure.Entities;
using StudentAffairsSystem.Shared.EntitiesConfigs;

namespace StudentAffairsSystem.Domain.AcademicStructure.EntitiesConfigs;

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
            .WithMany(d => d.StudyPrograms)
            .HasForeignKey(sp => sp.DepartmentId);
    }
}