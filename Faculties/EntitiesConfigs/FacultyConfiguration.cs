using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.EntitiesConfigs;
using Faculties.Entities;

namespace Faculties.EntitiesConfigs;

public class FacultyConfiguration : BaseEntityConfiguration<Entities.Faculty>
{
    public override void Configure(EntityTypeBuilder<Entities.Faculty> builder)
    {
        base.Configure(builder);
        builder.Property(f => f.Name).IsRequired();
    }
}