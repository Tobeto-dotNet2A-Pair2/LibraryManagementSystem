using FluentValidation;

namespace Application.Features.Branches.Commands.Update;

public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BranchName).NotEmpty();
        RuleFor(c => c.WorkingHours).NotEmpty();
        RuleFor(c => c.Telephone).NotEmpty();
        RuleFor(c => c.WebSiteUrl).NotEmpty();
        RuleFor(c => c.AddressId).NotEmpty();
        RuleFor(c => c.LibraryId).NotEmpty();
    }
}