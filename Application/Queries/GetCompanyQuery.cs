using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries;

public sealed record GetCompanyQuery(int Id, bool TrackChanges) : IRequest<CompanyDto>;
