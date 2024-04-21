using FluentValidation;

namespace Application.Features.FavoriteListMaterials.Commands.Delete;

public class DeleteFavoriteListMaterialCommandValidator : AbstractValidator<DeleteFavoriteListMaterialCommand>
{
    public DeleteFavoriteListMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}