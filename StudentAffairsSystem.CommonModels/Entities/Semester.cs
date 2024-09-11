using System.ComponentModel.DataAnnotations;

namespace StudentAffairsSystem.CommonModels.Entities;

public class Semester : BaseEntity
{
    public string Name => $"{Season.ToString()} {StartDate.Year}";

    [Required] public SemesterSeason Season { get; set; }

    [Required] public DateOnly StartDate { get; set; }

    [Required] public DateOnly EndDate { get; set; }
}

public enum SemesterSeason
{
    Winter = 0,
    Spring = 1,
    Summer = 2,
    Autumn = 3
}