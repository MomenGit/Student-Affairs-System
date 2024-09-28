using System.ComponentModel.DataAnnotations;
using Shared.Entities;

namespace Faculties.Entities;

public class Faculty : BaseEntity
{
    [Required] public string? Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Department>? Departments { get; set; }
}