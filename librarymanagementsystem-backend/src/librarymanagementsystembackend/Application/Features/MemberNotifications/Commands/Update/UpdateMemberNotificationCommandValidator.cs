using FluentValidation;

namespace Application.Features.MemberNotifications.Commands.Update;

public class UpdateMemberNotificationCommandValidator : AbstractValidator<UpdateMemberNotificationCommand>
{
    public UpdateMemberNotificationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.NotificationId).NotEmpty();
    }
}