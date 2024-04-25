using FluentValidation;

namespace Application.Features.Genres.Commands.Create;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().Length(2, 150);
    }
}