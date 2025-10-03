using Application.Queries;
using AutoMapper;
using Contracts;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class GetCompaniesHandler : IRequestHandler<GetCompaniesQuery, IEnumerable<CompanyDto>>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public GetCompaniesHandler(
        IRepositoryManager repositoryManager,
        IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _repositoryManager.Companies.GetAllAsync(request.TrackChanges);

        return _mapper.Map<IEnumerable<CompanyDto>>(companies);
    }
}
