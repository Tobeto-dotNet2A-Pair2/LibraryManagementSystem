using FluentValidation;

namespace Application.Features.Branches.Commands.Create;

public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
{
    public CreateBranchCommandValidator()
    {
        RuleFor(c => c.BranchName).NotEmpty();
        RuleFor(c => c.WorkingHours).NotEmpty();
        RuleFor(c => c.Telephone).NotEmpty();
        RuleFor(c => c.WebSiteUrl).NotEmpty();
        RuleFor(c => c.AddressId).NotEmpty();
        RuleFor(c => c.LibraryId).NotEmpty();
    }
}