using FluentValidation;

namespace Application.Features.Publishers.Commands.Create;

public class CreatePublisherCommandValidator : AbstractValidator<CreatePublisherCommand>
{
    public CreatePublisherCommandValidator()
    {
        RuleFor(c => c.PublisherName).NotEmpty().MinimumLength(2).MaximumLength(150);
        RuleFor(c => c.PublicationPlace).NotEmpty().MinimumLength(2).MaximumLength(150); 
    }
}