using MediatR;

namespace Application.Commands;

public record DeleteCompanyCommand(int Id, bool TrackChanges) : IRequest;
