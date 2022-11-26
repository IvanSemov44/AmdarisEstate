﻿using Application.Commands.CompanyCommands;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Handlers.CompanyHandlers
{
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