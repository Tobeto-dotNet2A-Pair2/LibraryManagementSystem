using FluentValidation;

namespace Application.Features.PublisherMaterials.Commands.Delete;

public class DeletePublisherMaterialCommandValidator : AbstractValidator<DeletePublisherMaterialCommand>
{
    public DeletePublisherMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}