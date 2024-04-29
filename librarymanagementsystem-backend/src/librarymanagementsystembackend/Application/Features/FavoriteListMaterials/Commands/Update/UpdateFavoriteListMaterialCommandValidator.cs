using FluentValidation;

namespace Application.Features.FavoriteListMaterials.Commands.Update;

public class UpdateFavoriteListMaterialCommandValidator : AbstractValidator<UpdateFavoriteListMaterialCommand>
{
    public UpdateFavoriteListMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FavoriteListId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}