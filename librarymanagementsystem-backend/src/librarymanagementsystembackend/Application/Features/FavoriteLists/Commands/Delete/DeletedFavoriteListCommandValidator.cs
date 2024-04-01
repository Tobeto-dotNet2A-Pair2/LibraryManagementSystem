using FluentValidation;

namespace Application.Features.FavoriteLists.Commands.Delete;

public class DeleteFavoriteListCommandValidator : AbstractValidator<DeleteFavoriteListCommand>
{
    public DeleteFavoriteListCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}