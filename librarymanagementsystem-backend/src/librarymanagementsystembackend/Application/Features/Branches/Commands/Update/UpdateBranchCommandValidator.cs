using FluentValidation;

namespace Application.Features.Branches.Commands.Update;

public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BranchName).NotEmpty().Length(2, 150);
        RuleFor(c => c.WorkingHours).NotEmpty();
        RuleFor(c => c.Telephone).NotEmpty().Matches(@"^+?\d{10,15}$").WithMessage("Please enter a valid phone number (should be between 10 and 15 digits, starting with '+' if present).");
        RuleFor(c => c.WebSiteUrl).NotEmpty()
                                  .Matches(@"^(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$")
                                  .WithMessage("Please enter a valid website URL");
        RuleFor(c => c.AddressId).NotEmpty();
        RuleFor(c => c.LibraryId).NotEmpty();
    }
}