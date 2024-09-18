using System.ComponentModel.DataAnnotations;

namespace StudentAffairsSystem.CommonModels.Entities;

public class User : BaseEntity
{
    [Required] [MaxLength(50)] public string? FirstName { get; set; }

    [Required] [MaxLength(50)] public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string? Email { get; set; }

    [Required] [Phone] [MaxLength(50)] public string? PhoneNumber { get; set; }

    [Required] [MaxLength(50)] public string? Password { get; set; }

    [Required] public DateTime BirthDate { get; set; }

    [Required] public string? Address { get; set; }

    public string? PictureUrl { get; set; }
}