using FluentValidation;

namespace Application.Features.Notifications.Commands.Create;

public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationCommandValidator()
    {
        RuleFor(c => c.NotificationType).NotEmpty();
        RuleFor(c => c.NotificationDate).NotEmpty();
        RuleFor(c => c.Message).NotEmpty().Length(1, 500);
        RuleFor(c => c.Status).NotEmpty();
    }
}