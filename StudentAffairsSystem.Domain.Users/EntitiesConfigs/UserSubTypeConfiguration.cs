using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAffairsSystem.Domain.Users.Entities;
using StudentAffairsSystem.Shared.EntitiesConfigs;

namespace StudentAffairsSystem.Domain.Users.EntitiesConfigs;

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