using Application.Commands;
using Contracts;
using MediatR;
using Shared.Exceptions;

namespace Application.Handlers;

internal sealed class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public DeleteCompanyHandler(
        IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _repositoryManager.Companies.GetByIdAsync(request.Id, request.TrackChanges);

        if (company is null)
        {
            throw new CompanyNotFoundException(request.Id);
        }

        await _repositoryManager.Companies.DeleteAsync(company);
        await _repositoryManager.SaveAsync();

        return Unit.Value;
    }
}
