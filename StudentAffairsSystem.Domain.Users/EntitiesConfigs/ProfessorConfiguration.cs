using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAffairsSystem.Domain.Users.Entities;

namespace StudentAffairsSystem.Domain.Users.EntitiesConfigs;

public class ProfessorConfiguration : UserSubTypeConfiguration<Professor>
{
    public override void Configure(EntityTypeBuilder<Professor> builder)
    {
        base.Configure(builder);

        builder.HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<Professor>(p => p.UserId);

        builder.HasOne(p => p.Department)
            .WithMany()
            .HasForeignKey(p => p.DepartmentId);
    }
}