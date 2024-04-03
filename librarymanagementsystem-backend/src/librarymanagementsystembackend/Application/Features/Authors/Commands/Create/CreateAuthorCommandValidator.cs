using FluentValidation;

namespace Application.Features.Authors.Commands.Create;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.LastName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(c => c.AuthorCountry).NotEmpty().MinimumLength(2).MaximumLength(50);
    }
}

