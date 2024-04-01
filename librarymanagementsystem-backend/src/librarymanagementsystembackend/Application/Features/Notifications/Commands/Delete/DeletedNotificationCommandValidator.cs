using FluentValidation;

namespace Application.Features.Notifications.Commands.Delete;

public class DeleteNotificationCommandValidator : AbstractValidator<DeleteNotificationCommand>
{
    public DeleteNotificationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}