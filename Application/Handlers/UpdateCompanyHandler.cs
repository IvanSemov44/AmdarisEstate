using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Handlers
{
    internal sealed class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateCompanyHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntity = _repositoryManager.Company.GetCompanyAsync(request.Id, request.TrackChanges);
            if (companyEntity is null)
                throw new CompanyNotFoundException(request.Id);

            await _mapper.Map(request.CompanyForUpdate, companyEntity);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
