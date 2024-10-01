using Shared.Entities;

namespace Faculties.Entities;

public class Faculty : BaseEntity
{
    public string? Name { get; set; }

    public string? Description { get; set; }
}