using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAffairsSystem.Shared.Entities;

namespace StudentAffairsSystem.Shared.EntitiesConfigs;

public class BaseEntityConfiguration<TEntity> : BaseDateTraceConfiguration<TEntity>
    where TEntity : BaseEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
    }
}