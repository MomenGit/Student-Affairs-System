using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAffairsSystem.Domain.AcademicStructure.Entities;
using StudentAffairsSystem.Shared.EntitiesConfigs;

namespace StudentAffairsSystem.Domain.AcademicStructure.EntitiesConfigs;

public class FacultyConfiguration : BaseEntityConfiguration<Faculty>
{
    public override void Configure(EntityTypeBuilder<Faculty> builder)
    {
        base.Configure(builder);
        builder.Property(f => f.Name).IsRequired();
    }
}