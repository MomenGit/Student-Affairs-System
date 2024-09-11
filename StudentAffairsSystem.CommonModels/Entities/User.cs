using System.ComponentModel.DataAnnotations;

namespace StudentAffairsSystem.CommonModels.Entities;

public class User : BaseEntity
{
    [Required] [MaxLength(50)] public string? FirstName { get; init; }

    [Required] [MaxLength(50)] public string? LastName { get; init; }

    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string? Email { init; get; }

    [Required] [Phone] [MaxLength(50)] public string? PhoneNumber { get; init; }

    [Required] [MaxLength(50)] public string? Password { get; set; }

    [Required] public DateTime DateOfBirth { get; set; }

    [Required] public string? Address { get; set; }

    public string? PictureUrl { get; set; }
}