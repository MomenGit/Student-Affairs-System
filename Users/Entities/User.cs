using System.ComponentModel.DataAnnotations;
using Shared.Entities;

namespace Users.Entities;

public class User : BaseEntity
{
    [Required] [MaxLength(50)] public string? FirstName { get; set; }

    [Required] [MaxLength(50)] public string? MiddleName { get; set; }

    [Required] [MaxLength(50)] public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string? Email { get; set; }

    [Required] [Phone] [MaxLength(50)] public string? PhoneNumber { get; set; }

    [Required] [MaxLength(50)] public string? Password { get; set; }

    [Required] public DateTime BirthDate { get; set; }

    [Required] [MaxLength(100)] public string? Address { get; set; }

    [MaxLength(50)] public string? PictureUrl { get; set; }
}