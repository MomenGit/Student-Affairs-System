using Shared.Entities;

namespace Users.Entities;

public class User : BaseEntity
{
    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Password { get; set; }

    public DateTime BirthDate { get; set; }

    public string? Address { get; set; }

    public string? PictureUrl { get; set; }
}