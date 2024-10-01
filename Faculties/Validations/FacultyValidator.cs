using Faculties.Entities;
using FluentValidation;

namespace Faculties.Validations;

public class FacultyValidator : AbstractValidator<Faculty>
{
    public FacultyValidator()
    {
        // Name: Required and must have a minimum length of 2 characters
        RuleFor(faculty => faculty.Name)
            .NotEmpty().WithMessage("Faculty name is required")
            .MinimumLength(2).WithMessage("Faculty name must be at least 2 characters long");

        // Description: Optional, but if provided, should have a max length constraint
        RuleFor(faculty => faculty.Description)
            .MaximumLength(500).WithMessage("Description can't exceed 500 characters")
            .When(faculty => !string.IsNullOrEmpty(faculty.Description));
    }
}