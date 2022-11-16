using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    internal sealed class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteCompanyHandler(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company =await _repositoryManager.Company.GetCompanyAsync(request.Id, request.TrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(request.Id);

             _repositoryManager.Company.DeleteCompany(company);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
