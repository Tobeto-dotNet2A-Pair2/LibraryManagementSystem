using FluentValidation;

namespace Application.Features.Genres.Commands.Delete;

public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
{
    public DeleteGenreCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}