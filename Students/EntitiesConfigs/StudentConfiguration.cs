using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Entities;
using Users.EntitiesConfigs;

namespace Students.EntitiesConfigs;

public class StudentConfiguration : UserSubTypeConfiguration<Student>
{
    public override void Configure(EntityTypeBuilder<Student> builder)
    {
        base.Configure(builder);

        builder.HasOne(s => s.StudyProgram)
            .WithMany()
            .HasForeignKey(s => s.StudyProgramId);

        builder.Property(s => s.Status)
            .HasConversion<string>();
    }
}