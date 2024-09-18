using System.ComponentModel.DataAnnotations;

namespace StudentAffairsSystem.CommonModels.DTOs;

public class StudentDTO
{
    [Required] public Guid Id { get; init; }
    [Required] [MaxLength(50)] public string? FirstName { get; set; }

    [Required] [MaxLength(50)] public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string? Email { set; get; }

    [Required] [Phone] [MaxLength(50)] public string? PhoneNumber { get; set; }

    [Required] public DateTime DateOfBirth { get; set; }

    [Required] public string? Address { get; set; }

    public string? PictureUrl { get; set; }

    [Required] public string? ProgramOfStudy { get; set; }

    [Required] public int CurrentLevel { get; set; }

    public DateOnly EnrollmentDate { get; set; }
}