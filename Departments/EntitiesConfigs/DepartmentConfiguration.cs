using Departments.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.EntitiesConfigs;

namespace Departments.EntitiesConfigs;

public class DepartmentConfiguration : BaseEntityConfiguration<Department>
{
    public override void Configure(EntityTypeBuilder<Department> builder)
    {
        base.Configure(builder);
        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(32);
        builder.HasIndex(d => d.Name).IsUnique();

        builder.HasOne(d => d.Faculty)
            .WithMany()
            .HasForeignKey(d => d.FacultyId);
    }
}