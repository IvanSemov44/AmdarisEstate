namespace IvanRealEstate.Application.Handlers.CompanyImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.CompanyHandlers;
    using IvanRealEstate.Application.Commands.CompanyImageCommands;

    public sealed class UpdateCompanyImageHandler:IRequestHandler<UpdateCompanyImageCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateCompanyImageHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateCompanyImageCommand request, CancellationToken cancellationToken)
        {
            await CheckerForCompany.CheckIfCompanyExistAndReturnIt(_repositoryManager, request.CompanyId, request.CompanyTrackChanges);

            var image = await CheckerForCompanyImage.CheckIfCompanyImageExistAndReturnIt(_repositoryManager, request.CompanyId, request.CompanyImageId, request.CompanyImageTrackChanges);

            _mapper.Map(request.CompanyImageForUpdateDto, image);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
