using System.Text.RegularExpressions;
using FluentValidation;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c => c.RegisterDto.User.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.RegisterDto.User.Password)
            .NotEmpty()
            .MinimumLength(6)
            .Must(StrongPassword)
            .WithMessage(
                "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character."
            );
        RuleFor(c => c.RegisterDto.PhoneNumber).NotEmpty()
                                  .Matches(@"^+?\d{10,15}$").WithMessage("Please enter a valid phone number (should be between 10 and 15 digits, starting with '+' if present).");
        RuleFor(c => c.RegisterDto.NationalIdentity).NotEmpty().Must(ValidateTurkishIdentityNumber);
    }


    private bool ValidateTurkishIdentityNumber(string identityNumber)
    {
        if (string.IsNullOrEmpty(identityNumber) || identityNumber.Length != 11 || identityNumber[0] == '0')
        {
            return false;
        }

        int sumFirst = identityNumber.Where((c, index) => index % 2 == 0 && index < 9).Sum(c => c - '0');
        int sumSecond = identityNumber.Where((c, index) => index % 2 == 1 && index < 8).Sum(c => c - '0');

        int sumTotal = sumFirst + sumSecond + (identityNumber[9] - '0');
        int lastDigit = sumTotal % 10;

        return lastDigit == identityNumber[10] - '0';
    }
    private bool StrongPassword(string value)
    {
        Regex strongPasswordRegex = new("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", RegexOptions.Compiled);

        return strongPasswordRegex.IsMatch(value);
    }
}
