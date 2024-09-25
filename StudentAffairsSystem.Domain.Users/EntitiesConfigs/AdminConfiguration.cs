using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAffairsSystem.Domain.Users.Entities;

namespace StudentAffairsSystem.Domain.Users.EntitiesConfigs;

public class AdminConfiguration : UserSubTypeConfiguration<Admin>
{
    public override void Configure(EntityTypeBuilder<Admin> builder)
    {
        base.Configure(builder);

        builder.Property(ad => ad.Privileges)
            .HasConversion<string>();
    }
}