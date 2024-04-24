using FluentValidation;

namespace Application.Features.Publishers.Commands.Update;

public class UpdatePublisherCommandValidator : AbstractValidator<UpdatePublisherCommand>
{
    public UpdatePublisherCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().Length(2, 150);
        RuleFor(c => c.PublicationPlace).NotEmpty().Length(2, 150);
    }
}