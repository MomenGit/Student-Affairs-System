using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAffairsSystem.Shared.Entities;

namespace StudentAffairsSystem.Shared.EntitiesConfigs;

public class BaseDateTraceConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseDateTrace
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.CreationDate).ValueGeneratedOnAdd();
    }
}