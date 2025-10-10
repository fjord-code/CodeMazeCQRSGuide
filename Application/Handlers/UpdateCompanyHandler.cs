using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Handlers;

internal sealed class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public UpdateCompanyHandler(
        IRepositoryManager repositoryManager, 
        IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _repositoryManager.Companies.GetByIdAsync(request.Id, request.TrackChanges);

        if (company is null)
        {
            throw new CompanyNotFoundException(request.Id);
        }

        _mapper.Map(request.Company, company);
        await _repositoryManager.SaveAsync();

        return Unit.Value;
    }
}
