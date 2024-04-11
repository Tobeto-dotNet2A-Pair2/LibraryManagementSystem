using FluentValidation;

namespace Application.Features.FavoriteLists.Commands.Update;

public class UpdateFavoriteListCommandValidator : AbstractValidator<UpdateFavoriteListCommand>
{
    public UpdateFavoriteListCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ListName).NotEmpty().Length(2, 150);
        RuleFor(c => c.MemberId).NotEmpty();
    }
}