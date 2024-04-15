using FluentValidation;

namespace Application.Features.MemberNotifications.Commands.Create;

public class CreateMemberNotificationCommandValidator : AbstractValidator<CreateMemberNotificationCommand>
{
    public CreateMemberNotificationCommandValidator()
    {
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.NotificationId).NotEmpty();
    }
}