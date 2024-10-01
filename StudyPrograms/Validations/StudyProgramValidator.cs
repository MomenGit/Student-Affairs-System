using FluentValidation;
using StudyPrograms.Entities;

namespace StudyPrograms.Validations;

public class StudyProgramValidator : AbstractValidator<StudyProgram>
{
    public StudyProgramValidator()
    {
        // Name: Required and must have a maximum length
        RuleFor(sp => sp.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters");

        // ProgramDuration: Must be a positive integer
        RuleFor(sp => sp.ProgramDuration)
            .GreaterThan(0).WithMessage("Program duration must be greater than 0");

        // Application start and end dates: Optional but must be valid if provided
        RuleForEach(sp => sp.ApplicationStartDates)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Application start date cannot be in the future");

        RuleForEach(sp => sp.ApplicationEndDates)
            .GreaterThanOrEqualTo(sp => DateOnly.MinValue)
            .WithMessage("Application end date must be after the start date");

        // Degree: Must be a valid enum value
        RuleFor(sp => sp.Degree)
            .IsInEnum().WithMessage("Invalid degree type");

        // DepartmentId: Ensure it's a valid GUID
        RuleFor(sp => sp.DepartmentId)
            .NotEmpty().WithMessage("DepartmentId is required");
    }
}