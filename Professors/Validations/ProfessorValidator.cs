using FluentValidation;
using Professors.Entities;
using Shared.Utilities;

namespace Professors.Validations;

public class ProfessorValidator : AbstractValidator<Professor>
{
    public ProfessorValidator()
    {
        // DepartmentId: Ensure it's a valid Guid (non-empty)
        RuleFor(professor => professor.DepartmentId)
            .NotEmpty().WithMessage("DepartmentId is required");

        // DocumentsUrls: Optional, but if provided, ensure it's a valid collection
        RuleForEach(professor => professor.DocumentsUrls)
            .NotNull().WithMessage("Document URLs cannot contain null values")
            .Must(Utils.BeAValidUrl).WithMessage("Each document URL must be a valid URL");
    }
}