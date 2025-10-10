using Application.Notifications;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Handlers;

internal sealed class DeleteCompanyHandler : INotificationHandler<CompanyDeletedNotification>
{
    private readonly IRepositoryManager _repositoryManager;

    public DeleteCompanyHandler(
        IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task Handle(CompanyDeletedNotification notification, CancellationToken cancellationToken)
    {
        var company = await _repositoryManager.Companies.GetByIdAsync(notification.Id, notification.TrackChanges);

        if (company is null)
        {
            throw new CompanyNotFoundException(notification.Id);
        }

        await _repositoryManager.Companies.DeleteAsync(company);
        await _repositoryManager.SaveAsync();
    }
}
