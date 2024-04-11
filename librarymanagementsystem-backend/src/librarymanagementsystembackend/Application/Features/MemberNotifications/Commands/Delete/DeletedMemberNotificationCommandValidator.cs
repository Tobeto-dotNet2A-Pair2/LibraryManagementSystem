using FluentValidation;

namespace Application.Features.MemberNotifications.Commands.Delete;

public class DeleteMemberNotificationCommandValidator : AbstractValidator<DeleteMemberNotificationCommand>
{
    public DeleteMemberNotificationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}