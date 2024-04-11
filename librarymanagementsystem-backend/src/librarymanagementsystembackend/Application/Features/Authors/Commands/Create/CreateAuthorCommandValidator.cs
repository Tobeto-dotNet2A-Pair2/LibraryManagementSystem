using FluentValidation;

namespace Application.Features.Authors.Commands.Create;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().Length(2,50);
        RuleFor(c => c.LastName).NotEmpty().Length(2, 50);
        RuleFor(c => c.AuthorCountry).NotEmpty().Length(2, 50);
    }
}