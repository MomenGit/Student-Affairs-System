using FluentValidation;
using Semesters.Entities;

namespace Semesters.Validations;

public class SemesterValidator : AbstractValidator<Semester>
{
    public SemesterValidator()
    {
        // Season: Ensure it's a valid enum value
        RuleFor(semester => semester.Season)
            .IsInEnum().WithMessage("Invalid semester season");

        // StartDate: Ensure it's not in the past (optional rule)
        RuleFor(semester => semester.StartDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Semester start date cannot be in the past");

        // EndDate: Ensure it's after StartDate
        RuleFor(semester => semester.EndDate)
            .GreaterThan(semester => semester.StartDate)
            .WithMessage("End date must be after the start date");

        // EnrollmentStartDate: Ensure it's within the semester period
        RuleFor(semester => semester.EnrollmentStartDate)
            .GreaterThanOrEqualTo(semester => semester.StartDate)
            .WithMessage("Enrollment start date must be on or after the semester start date");

        // EnrollmentEndDate: Ensure it's within the semester period and after EnrollmentStartDate
        RuleFor(semester => semester.EnrollmentEndDate)
            .GreaterThanOrEqualTo(semester => semester.EnrollmentStartDate)
            .WithMessage("Enrollment end date must be after enrollment start date")
            .LessThanOrEqualTo(semester => semester.EndDate)
            .WithMessage("Enrollment end date must be on or before the semester end date");
    }
}