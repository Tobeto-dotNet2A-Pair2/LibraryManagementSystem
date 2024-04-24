using FluentValidation;

namespace Application.Features.MaterialGenres.Commands.Update;

public class UpdateMaterialGenreCommandValidator : AbstractValidator<UpdateMaterialGenreCommand>
{
    public UpdateMaterialGenreCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.GenreId).NotEmpty();
        RuleFor(c => c.MaterialId).NotEmpty();
    }
}