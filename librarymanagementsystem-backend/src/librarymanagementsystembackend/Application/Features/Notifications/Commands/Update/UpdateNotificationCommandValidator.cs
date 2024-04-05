using FluentValidation;

namespace Application.Features.Notifications.Commands.Update;

public class UpdateNotificationCommandValidator : AbstractValidator<UpdateNotificationCommand>
{
    public UpdateNotificationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.NotificationType).NotEmpty();
        RuleFor(c => c.NotificationDate).NotEmpty();
        RuleFor(c => c.Message).NotEmpty().Length(1, 500);
        RuleFor(c => c.Status).NotEmpty();
    }
}