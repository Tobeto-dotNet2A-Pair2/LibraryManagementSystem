using FluentValidation;

namespace Application.Features.Publishers.Commands.Create;

public class CreatePublisherCommandValidator : AbstractValidator<CreatePublisherCommand>
{
    public CreatePublisherCommandValidator()
    {
        RuleFor(c => c.PublisherName).NotEmpty().Length(2,150);
        RuleFor(c => c.PublicationPlace).NotEmpty().Length(2,150);
    }
}