using FluentValidation;

namespace Application.Features.Publishers.Commands.Update;

public class UpdatePublisherCommandValidator : AbstractValidator<UpdatePublisherCommand>
{
    public UpdatePublisherCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PublisherName).NotEmpty();
        RuleFor(c => c.PublicationPlace).NotEmpty();
    }
}