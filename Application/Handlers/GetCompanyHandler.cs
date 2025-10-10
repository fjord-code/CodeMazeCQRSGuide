using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class GetCompanyHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public GetCompanyHandler(
        IRepositoryManager repositoryManager,
        IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }


    public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _repositoryManager.Companies.GetByIdAsync(request.Id, request.TrackChanges);

        if (company is null)
        {
            throw new CompanyNotFoundException(request.Id);
        }

        return _mapper.Map<CompanyDto>(company);
    }
}
