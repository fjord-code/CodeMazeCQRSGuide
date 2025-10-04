using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record class CreateCompanyCommand(CompanyForCreationDto Company) : IRequest<CompanyDto>;
