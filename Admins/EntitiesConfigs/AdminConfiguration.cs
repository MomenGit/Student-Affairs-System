using Admins.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.EntitiesConfigs;

namespace Admins.EntitiesConfigs;

public class AdminConfiguration : UserSubTypeConfiguration<Admin>
{
    public override void Configure(EntityTypeBuilder<Admin> builder)
    {
        base.Configure(builder);

        builder.Property(ad => ad.Privileges)
            .HasConversion<string>();
    }
}