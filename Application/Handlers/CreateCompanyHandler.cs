using Application.Commands;
using AutoMapper;
using Contracts;
using Entities;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompanyDto>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public CreateCompanyHandler(
        IRepositoryManager repositoryManager,
        IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = _mapper.Map<Company>(request.Company);

        await _repositoryManager.Companies.AddAsync(company);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<CompanyDto>(company);
    }
}
