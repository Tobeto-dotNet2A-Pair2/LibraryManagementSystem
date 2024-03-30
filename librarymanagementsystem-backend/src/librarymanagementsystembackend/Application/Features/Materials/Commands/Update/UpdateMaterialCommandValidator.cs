using FluentValidation;

namespace Application.Features.Materials.Commands.Update;

public class UpdateMaterialCommandValidator : AbstractValidator<UpdateMaterialCommand>
{
    public UpdateMaterialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.PublicationDate).NotEmpty();
        RuleFor(c => c.PunishmentAmount).NotEmpty();
        RuleFor(c => c.IsBorrowable).NotEmpty();
        RuleFor(c => c.BorrowDay).NotEmpty();
        RuleFor(c => c.PenaltyId).NotEmpty();
    }
}