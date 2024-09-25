using System.ComponentModel.DataAnnotations.Schema;
using StudentAffairsSystem.Domain.AcademicStructure.Entities;

namespace StudentAffairsSystem.Domain.Users.Entities;

public class Professor : UserSubType
{
    [ForeignKey("Department")] public Guid DepartmentId { get; set; }

    public ICollection<string>? DocumentsUrls { get; set; }

    public Department? Department { get; set; }
}