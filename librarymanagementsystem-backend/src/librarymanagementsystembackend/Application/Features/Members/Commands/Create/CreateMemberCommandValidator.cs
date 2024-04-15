using FluentValidation;

namespace Application.Features.Members.Commands.Create;

public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
{
    public CreateMemberCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().Length(2, 150);
        RuleFor(c => c.LastName).NotEmpty().Length(2, 150);
        RuleFor(c => c.TC).NotEmpty().Must(ValidateTurkishIdentityNumber);
        RuleFor(c => c.PhoneNumber).NotEmpty()
                                   .Matches(@"^+?\d{10,15}$").WithMessage("Please enter a valid phone number (should be between 10 and 15 digits, starting with '+' if present).");
        RuleFor(c => c.Photo).NotEmpty()
                            .Matches(@".(jpg|jpeg|png|gif)$").WithMessage("Please provide a valid photo file (jpg, jpeg, png, gif).");
        RuleFor(c => c.Position).NotEmpty().Length(2, 50);
        RuleFor(c => c.TotalDebt).GreaterThanOrEqualTo(0);
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
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

}