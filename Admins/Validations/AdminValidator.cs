using Admins.Entities;
using FluentValidation;

namespace Admins.Validations;

public class AdminValidator : AbstractValidator<Admin>
{
    public AdminValidator()
    {
        // Ensure that the Privileges list is not null or empty
        RuleFor(admin => admin.Privileges)
            .NotNull().WithMessage("Privileges list cannot be null")
            .NotEmpty().WithMessage("Privileges list must have at least one privilege");

        // Ensure that the Privileges list does not contain duplicates
        RuleFor(admin => admin.Privileges)
            .Must(privileges => privileges.Distinct().Count() == privileges.Count)
            .WithMessage("Privileges list contains duplicate entries");
    }
}