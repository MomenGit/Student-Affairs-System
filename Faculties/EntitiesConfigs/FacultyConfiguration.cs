using Faculties.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.EntitiesConfigs;

namespace Faculties.EntitiesConfigs;

public class FacultyConfiguration : BaseEntityConfiguration<Faculty>
{
    public override void Configure(EntityTypeBuilder<Faculty> builder)
    {
        base.Configure(builder);
        builder.Property(f => f.Name).IsRequired();
    }
}