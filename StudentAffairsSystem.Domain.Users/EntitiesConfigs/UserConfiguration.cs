using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAffairsSystem.Domain.Users.Entities;
using StudentAffairsSystem.Shared.EntitiesConfigs;

namespace StudentAffairsSystem.Domain.Users.EntitiesConfigs;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public new void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(u => u.MiddleName)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.Address)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.BirthDate)
            .IsRequired();

        builder.Property(u => u.PictureUrl)
            .HasMaxLength(20);
    }
}