using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Semesters.Entities;
using Shared.EntitiesConfigs;

namespace Semesters.EntitiesConfigs;

public class SemesterConfiguration : BaseEntityConfiguration<Semester>
{
    public override void Configure(EntityTypeBuilder<Semester> builder)
    {
        base.Configure(builder);

        builder.Property(s => s.StartDate).IsRequired();
        builder.Property(s => s.EndDate).IsRequired();
        builder.Property(s => s.EnrollmentStartDate).IsRequired();
        builder.Property(s => s.EnrollmentEndDate).IsRequired();

        builder.Property(s => s.Season)
            .HasConversion<string>();
    }
}