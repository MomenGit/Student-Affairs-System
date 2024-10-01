using Departments.Entities;
using FluentValidation;

namespace Departments.Validations;

public class DepartmentValidator : AbstractValidator<Department>
{
    public DepartmentValidator()
    {
        // Name: Required and must not exceed 32 characters
        RuleFor(department => department.Name)
            .NotEmpty().WithMessage("Department name is required")
            .MaximumLength(32).WithMessage("Department name must not exceed 32 characters");

        // FacultyId: Ensure it's a valid Guid (non-empty)
        RuleFor(department => department.FacultyId)
            .NotEmpty().WithMessage("FacultyId is required");
    }
}