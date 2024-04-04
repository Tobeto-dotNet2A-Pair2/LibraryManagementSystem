using FluentValidation;

namespace Application.Features.SocialMediaAccounts.Commands.Create;

public class CreateSocialMediaAccountCommandValidator : AbstractValidator<CreateSocialMediaAccountCommand>
{
    public CreateSocialMediaAccountCommandValidator()
    {
        RuleFor(c => c.BranchId).NotEmpty();
        RuleFor(c => c.SocialMediaAccountLogo).Empty().Length(1,300);;
        RuleFor(c => c.SocialMediaAccountUrl).Empty().Length(1,300);
        RuleFor(c => c.SocialMediaAccountUrl).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(c => !string.IsNullOrEmpty(c.SocialMediaAccountUrl));

    }
}