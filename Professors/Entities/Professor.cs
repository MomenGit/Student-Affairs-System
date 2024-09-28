using System.ComponentModel.DataAnnotations.Schema;
using Departments.Entities;
using Users.Entities;

namespace Professors.Entities;

public class Professor : UserSubType
{
    [ForeignKey("Department")] public Guid DepartmentId { get; set; }

    public ICollection<string>? DocumentsUrls { get; set; }

    public Department? Department { get; set; }
}