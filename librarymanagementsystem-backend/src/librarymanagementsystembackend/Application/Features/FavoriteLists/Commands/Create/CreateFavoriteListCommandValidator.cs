using FluentValidation;

namespace Application.Features.FavoriteLists.Commands.Create;

public class CreateFavoriteListCommandValidator : AbstractValidator<CreateFavoriteListCommand>
{
    public CreateFavoriteListCommandValidator()
    {
        RuleFor(c => c.ListName).NotEmpty().Length(2, 150);
        RuleFor(c => c.MemberId).NotEmpty();
    }
}