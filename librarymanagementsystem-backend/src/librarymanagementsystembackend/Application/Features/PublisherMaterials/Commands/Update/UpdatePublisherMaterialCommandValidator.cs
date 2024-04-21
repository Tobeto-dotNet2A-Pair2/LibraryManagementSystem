using FluentValidation;

namespace Application.Features.PublisherMaterials.Commands.Update;

public class UpdatePublisherMaterialCommandValidator : AbstractValidator<UpdatePublisherMaterialCommand>
{
    public UpdatePublisherMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PublisherId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}