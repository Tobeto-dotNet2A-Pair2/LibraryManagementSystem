using FluentValidation;

namespace Application.Features.MaterialGenres.Commands.Create;

public class CreateMaterialGenreCommandValidator : AbstractValidator<CreateMaterialGenreCommand>
{
    public CreateMaterialGenreCommandValidator()
    {
        RuleFor(c => c.GenreId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}