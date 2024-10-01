using FluentValidation;
using SemesterCourses.Entities;

namespace SemesterCourses.Validations;

public class SemesterCourseValidator : AbstractValidator<SemesterCourse>
{
    public SemesterCourseValidator()
    {
        // CourseId: Required
        RuleFor(sc => sc.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");

        // SemesterId: Required
        RuleFor(sc => sc.SemesterId)
            .NotEmpty().WithMessage("Semester ID is required.");

        // ProfessorId: Optional
        RuleFor(sc => sc.ProfessorId)
            .NotNull().WithMessage("Professor ID must be provided if assigned.")
            .When(sc => sc.ProfessorId.HasValue);

        // AvailableSeats: Optional, but can add logic if needed
        RuleFor(sc => sc.AvailableSeats)
            .GreaterThanOrEqualTo(0).WithMessage("Available seats cannot be negative.")
            .When(sc => sc.AvailableSeats.HasValue);
    }
}