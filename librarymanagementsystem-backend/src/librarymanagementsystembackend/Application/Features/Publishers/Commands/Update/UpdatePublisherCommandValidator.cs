using FluentValidation;

namespace Application.Features.Publishers.Commands.Update;

public class UpdatePublisherCommandValidator : AbstractValidator<UpdatePublisherCommand>
{
    public UpdatePublisherCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PublisherName).NotEmpty().MinimumLength(2).MaximumLength(150);
        RuleFor(c => c.PublicationPlace).NotEmpty().MinimumLength(2).MaximumLength(150);
    }
}