using FluentValidation;

namespace Application.Features.MaterialGenres.Commands.Delete;

public class DeleteMaterialGenreCommandValidator : AbstractValidator<DeleteMaterialGenreCommand>
{
    public DeleteMaterialGenreCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}