using FluentValidation;
using Shared.Utilities;
using Users.Entities;

namespace Users.Validations;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        // First Name: Required and must have a minimum length of 2 characters
        RuleFor(user => user.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .MinimumLength(2).WithMessage("First name must be at least 2 characters long");

        // Middle Name: Optional, but if present, must be at least 2 characters long
        RuleFor(user => user.MiddleName)
            .NotEmpty().WithMessage("Middle name is required")
            .MinimumLength(2).WithMessage("Middle name must be at least 2 characters long");

        // Last Name: Required and must have a minimum length of 2 characters
        RuleFor(user => user.LastName)
            .NotEmpty().WithMessage("Last name is required")
            .MinimumLength(2).WithMessage("Last name must be at least 2 characters long");

        // Email: Required and must be a valid email address format
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required");

        // Phone Number: Optional but must be in valid phone number format if provided
        RuleFor(user => user.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^\+?\d{10,15}$")
            .WithMessage("Phone number must be a valid format (e.g., +1234567890)");

        // Password: Required, at least 6 characters long, and must contain at least one number and one special character
        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches(@"\d").WithMessage("Password must contain at least one number")
            .Matches(@"[\W]").WithMessage("Password must contain at least one special character");

        // Birth Date: Must be a valid date and the user must be at least 18 years old
        RuleFor(user => user.BirthDate)
            .Must(BeAtLeast18YearsOld).WithMessage("User must be at least 18 years old");

        // Address: Optional, no validation rules
        RuleFor(user => user.Address)
            .NotEmpty().WithMessage("Address is required")
            .MaximumLength(250).WithMessage("Address cannot exceed 250 characters");

        // Picture URL: Optional, but must be a valid URL if provided
        RuleFor(user => user.PictureUrl)
            .Must(Utils.BeAValidUrl).When(user => !string.IsNullOrEmpty(user.PictureUrl))
            .WithMessage("Picture URL must be a valid URL");
    }

    // Custom validation for BirthDate to ensure user is at least 18 years old
    private static bool BeAtLeast18YearsOld(DateTime birthDate)
    {
        return birthDate <= DateTime.Today.AddYears(-18);
    }
}