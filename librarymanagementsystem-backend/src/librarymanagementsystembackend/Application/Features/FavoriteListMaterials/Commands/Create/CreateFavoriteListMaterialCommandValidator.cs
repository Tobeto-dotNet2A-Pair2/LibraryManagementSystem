using FluentValidation;

namespace Application.Features.FavoriteListMaterials.Commands.Create;

public class CreateFavoriteListMaterialCommandValidator : AbstractValidator<CreateFavoriteListMaterialCommand>
{
    public CreateFavoriteListMaterialCommandValidator()
    {
        RuleFor(c => c.FavoriteListId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}