using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAffairsSystem.Domain.AcademicStructure.Entities;
using StudentAffairsSystem.Shared.EntitiesConfigs;

namespace StudentAffairsSystem.Domain.AcademicStructure.EntitiesConfigs;

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