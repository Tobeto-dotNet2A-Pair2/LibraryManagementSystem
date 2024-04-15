using FluentValidation;

namespace Application.Features.SocialMediaAccounts.Commands.Create;

public class CreateSocialMediaAccountCommandValidator : AbstractValidator<CreateSocialMediaAccountCommand>
{
    public CreateSocialMediaAccountCommandValidator()
    {
        RuleFor(c => c.BranchId).NotEmpty();
        RuleFor(c => c.SocialMediaAccountLogo).NotEmpty().Length(2, 300);
        RuleFor(c => c.SocialMediaAccountUrl).NotEmpty().Length(2, 300).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(c => !string.IsNullOrEmpty(c.SocialMediaAccountUrl)); ;
    }
}