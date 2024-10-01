using CourseEnrollments.Entities;
using FluentValidation;

namespace CourseEnrollments.Validations;

public class CourseEnrollmentValidator : AbstractValidator<CourseEnrollment>
{
    public CourseEnrollmentValidator()
    {
        // StudentId: Required
        RuleFor(ce => ce.StudentId)
            .NotEmpty().WithMessage("Student ID is required.");

        // SemesterCourseId: Required
        RuleFor(ce => ce.SemesterCourseId)
            .NotEmpty().WithMessage("Semester Course ID is required.");

        // EnrollmentDate: Required
        RuleFor(ce => ce.EnrollmentDate)
            .NotEmpty().WithMessage("Enrollment date is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Enrollment date cannot be in the future.");

        // Score: Required and must be within a valid range (e.g., 0 to 100)
        RuleFor(ce => ce.Score)
            .GreaterThanOrEqualTo(0).WithMessage("Score must be greater than or equal to 0.")
            .LessThanOrEqualTo(100).WithMessage("Score must be less than or equal to 100.");

        // GradeValue: Required and must be within a valid range (adjust as necessary)
        RuleFor(ce => ce.GradeValue)
            .GreaterThanOrEqualTo(0).WithMessage("Grade value must be greater than or equal to 0.")
            .LessThanOrEqualTo(4.0f)
            .WithMessage("Grade value must be less than or equal to 4.0."); // Assuming 4.0 is the maximum grade

        // Comment: Optional, but can have a maximum length if necessary
        RuleFor(ce => ce.Comment)
            .MaximumLength(500).WithMessage("Comment cannot exceed 500 characters.");
    }
}