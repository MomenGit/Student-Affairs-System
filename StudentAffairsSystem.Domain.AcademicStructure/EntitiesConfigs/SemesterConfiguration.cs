using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAffairsSystem.Domain.AcademicStructure.Entities;
using StudentAffairsSystem.Shared.EntitiesConfigs;

namespace StudentAffairsSystem.Domain.AcademicStructure.EntitiesConfigs;

public class SemesterConfiguration : BaseEntityConfiguration<Semester>
{
    public override void Configure(EntityTypeBuilder<Semester> builder)
    {
        base.Configure(builder);

        builder.Property(s => s.Name).HasMaxLength(20).IsRequired();
        builder.Property(s => s.StartDate).IsRequired();
        builder.Property(s => s.EndDate).IsRequired();
        builder.Property(s => s.EnrollmentStartDate).IsRequired();
        builder.Property(s => s.EnrollmentEndDate).IsRequired();

        builder.Property(s => s.Season)
            .HasConversion<string>();
    }
}