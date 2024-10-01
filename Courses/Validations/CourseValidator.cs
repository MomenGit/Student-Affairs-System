using Courses.Entities;
using FluentValidation;

namespace Courses.Validations;

public class CourseValidator : AbstractValidator<Course>
{
    public CourseValidator()
    {
        // Name: Required and must have a maximum length
        RuleFor(course => course.Name)
            .NotEmpty().WithMessage("Course name is required")
            .MaximumLength(100).WithMessage("Course name must not exceed 100 characters");

        // Code: Required and must follow certain constraints
        RuleFor(course => course.Code)
            .NotEmpty().WithMessage("Course code is required")
            .MaximumLength(10).WithMessage("Course code must not exceed 10 characters");

        // Credits: Must be a positive integer
        RuleFor(course => course.Credits)
            .GreaterThan(0).WithMessage("Credits must be greater than 0");

        // RecommendedSemester: Must be a positive integer
        RuleFor(course => course.RecommendedSemester)
            .GreaterThan(0).WithMessage("Recommended semester must be greater than 0");

        // StudyProgramId: Ensure it's a valid Guid (non-empty)
        RuleFor(course => course.StudyProgramId)
            .NotEmpty().WithMessage("StudyProgramId is required");

        // Prerequisites: Optional, but if provided, they should not contain null values
        RuleForEach(course => course.Prerequisites)
            .NotNull().When(p => p.Prerequisites?.Count != 0)
            .WithMessage("Prerequisites cannot contain null values");
    }
}