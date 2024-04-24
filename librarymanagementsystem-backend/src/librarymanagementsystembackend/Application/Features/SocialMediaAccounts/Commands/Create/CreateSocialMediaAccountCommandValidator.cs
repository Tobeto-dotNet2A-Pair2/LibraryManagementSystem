using FluentValidation;

namespace Application.Features.SocialMediaAccounts.Commands.Create;

public class CreateSocialMediaAccountCommandValidator : AbstractValidator<CreateSocialMediaAccountCommand>
{
    public CreateSocialMediaAccountCommandValidator()
    {
        RuleFor(c => c.BranchId).NotEmpty();
        RuleFor(c => c.Logo).NotEmpty();
        RuleFor(c => c.Url).NotEmpty().Length(2, 300)
                           .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("Invalid URL format.")
                           .When(c => !string.IsNullOrEmpty(c.Url)); ;
    }
}