using FluentValidation;
using Shared.Utilities;
using Students.Entities;

namespace Students.Validations;

public class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator()
    {
        // StudyProgramId: Ensure it is a valid Guid (non-empty)
        RuleFor(student => student.StudyProgramId)
            .NotEmpty().WithMessage("StudyProgramId is required");

        // Status: Ensure it is a valid StudentStatus (this is automatically handled by enum, but adding this rule improves clarity)
        RuleFor(student => student.Status)
            .IsInEnum().WithMessage("Invalid student status");

        // // EnrollmentDate: Ensure it's not a future date
        // RuleFor(student => student.EnrollmentDate)
        //     .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
        //     .WithMessage("Enrollment date cannot be in the future");

        // DocumentsUrls: Optional, but if provided, ensure each document URL is valid
        RuleForEach(student => student.DocumentsUrls)
            .Must(Utils.BeAValidUrl).When(student => student.DocumentsUrls != null)
            .WithMessage("Invalid document URL");
    }
}