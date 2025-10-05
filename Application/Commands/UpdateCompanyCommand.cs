using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record UpdateCompanyCommand(int Id, CompanyForUpdateDto Company, bool TrackChanges) : IRequest;
