﻿namespace IvanRealEstate.Application.Handlers.CompanyHandlers
{
    using MediatR;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions.NotFound;
    using IvanRealEstate.Application.Commands.CompanyCommands;

    internal sealed class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteCompanyHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(request.Id, request.TrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(request.Id);

            _repositoryManager.Company.DeleteCompany(company);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
