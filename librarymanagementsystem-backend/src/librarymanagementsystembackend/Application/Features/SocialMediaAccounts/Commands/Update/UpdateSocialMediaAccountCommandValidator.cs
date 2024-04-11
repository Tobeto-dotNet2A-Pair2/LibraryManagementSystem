using FluentValidation;

namespace Application.Features.SocialMediaAccounts.Commands.Update;

public class UpdateSocialMediaAccountCommandValidator : AbstractValidator<UpdateSocialMediaAccountCommand>
{
    public UpdateSocialMediaAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BranchId).NotEmpty();
        RuleFor(c => c.SocialMediaAccountLogo).NotEmpty();
        RuleFor(c => c.SocialMediaAccountUrl).NotEmpty();
    }
}