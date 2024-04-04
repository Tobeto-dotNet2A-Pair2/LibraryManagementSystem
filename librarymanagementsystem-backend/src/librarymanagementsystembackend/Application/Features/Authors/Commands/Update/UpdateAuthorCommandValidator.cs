using FluentValidation;

namespace Application.Features.Authors.Commands.Update;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.LastName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.AuthorCountry).NotEmpty().MinimumLength(2).MaximumLength(50);
    }
}