using FluentValidation;

namespace Application.Features.SocialMediaAccounts.Commands.Update;

public class UpdateSocialMediaAccountCommandValidator : AbstractValidator<UpdateSocialMediaAccountCommand>
{
    public UpdateSocialMediaAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BranchId).NotEmpty();
        RuleFor(c => c.SocialMediaAccountLogo).Empty().Length(1,300);;
        RuleFor(c => c.SocialMediaAccountUrl).Empty().Length(1,300);
        RuleFor(c => c.SocialMediaAccountUrl).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(c => !string.IsNullOrEmpty(c.SocialMediaAccountUrl));

    }
}