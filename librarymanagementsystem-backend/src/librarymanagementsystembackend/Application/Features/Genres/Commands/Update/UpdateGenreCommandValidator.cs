using FluentValidation;

namespace Application.Features.Genres.Commands.Update;

public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.GenreName).NotEmpty();
    }
}