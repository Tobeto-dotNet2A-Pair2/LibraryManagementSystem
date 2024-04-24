using FluentValidation;

namespace Application.Features.Notifications.Commands.Create;

public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationCommandValidator()
    {
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.SendingDate).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}