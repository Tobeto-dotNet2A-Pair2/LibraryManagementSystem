using FluentValidation;

namespace Application.Features.Authors.Commands.Update;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty().Length(2, 50);
        RuleFor(c => c.LastName).NotEmpty().Length(2, 50);
        RuleFor(c => c.Country).NotEmpty().Length(2, 50);
    }
}