using MediatR;

namespace Application.Notifications;

public sealed record CompanyDeletedNotification(int Id, bool TrackChanges) : INotification;
