using FluentValidation;

namespace Application.Features.SocialMediaAccounts.Commands.Delete;

public class DeleteSocialMediaAccountCommandValidator : AbstractValidator<DeleteSocialMediaAccountCommand>
{
    public DeleteSocialMediaAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}