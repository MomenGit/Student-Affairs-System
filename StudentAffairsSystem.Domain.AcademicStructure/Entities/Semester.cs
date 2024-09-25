using System.ComponentModel.DataAnnotations;
using StudentAffairsSystem.Shared.Entities;

namespace StudentAffairsSystem.Domain.AcademicStructure.Entities;

public class Semester : BaseEntity
{
    public string Name => $"{Season.ToString()} {StartDate.Year}";

    [Required] public SemesterSeason Season { get; set; }

    [Required] public DateOnly StartDate { get; set; }

    [Required] public DateOnly EndDate { get; set; }

    [Required] public DateOnly EnrollmentStartDate { get; set; }

    [Required] public DateOnly EnrollmentEndDate { get; set; }
}

public enum SemesterSeason
{
    Winter = 0,
    Spring = 1,
    Summer = 2,
    Autumn = 3
}