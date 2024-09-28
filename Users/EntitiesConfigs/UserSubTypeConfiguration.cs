using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.EntitiesConfigs;
using Users.Entities;

namespace Users.EntitiesConfigs;

public class UserSubTypeConfiguration<TEntity> : BaseEntityConfiguration<TEntity>
    where TEntity : UserSubType
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId);
    }
}