using Application.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers;

internal sealed class EmailHandler : INotificationHandler<CompanyDeletedNotification>
{
    private readonly ILogger<EmailHandler> _logger;

    public EmailHandler(
        ILogger<EmailHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(CompanyDeletedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogWarning($"Delete action for the company with id {notification.Id} has occured.");

        await Task.CompletedTask;
    }
}
