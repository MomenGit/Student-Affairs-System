using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class Semester : BaseEntity
{
    public string Name => $"{Season.ToString()} {StartDate.Year}";

    [Required] public SemesterSeason Season { get; set; }

    [Required] public DateOnly StartDate { get; set; }

    [Required] public DateOnly EndDate { get; set; }
    
    [Required] public DateOnly EnrollmentStartDate { get; set; }
    
    [Required] public DateOnly EnrollmentEndDate { get; set; }
    
    [InverseProperty("Semester")] public ICollection<SemesterCourse>? SemesterCourses { get; set; }
}

public enum SemesterSeason
{
    Winter = 0,
    Spring = 1,
    Summer = 2,
    Autumn = 3
}