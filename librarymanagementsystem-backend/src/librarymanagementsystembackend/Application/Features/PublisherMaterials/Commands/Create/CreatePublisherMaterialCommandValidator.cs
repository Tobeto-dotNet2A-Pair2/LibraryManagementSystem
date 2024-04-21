using FluentValidation;

namespace Application.Features.PublisherMaterials.Commands.Create;

public class CreatePublisherMaterialCommandValidator : AbstractValidator<CreatePublisherMaterialCommand>
{
    public CreatePublisherMaterialCommandValidator()
    {
        RuleFor(c => c.PublisherId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}