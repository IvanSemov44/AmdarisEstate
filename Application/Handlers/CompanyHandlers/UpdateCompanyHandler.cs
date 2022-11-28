namespace IvanRealEstate.Application.Handlers.CompanyHandlers
{
    using Application.Commands.CompanyCommands;
    using AutoMapper;
    using Contracts;
    using Entities.Exceptions;
    using MediatR;

    internal sealed class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateCompanyHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntity = await _repositoryManager.Company.GetCompanyAsync(request.Id, request.TrackChanges);
            if (companyEntity is null)
                throw new CompanyNotFoundException(request.Id);

            _mapper.Map(request.CompanyForUpdate, companyEntity);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
