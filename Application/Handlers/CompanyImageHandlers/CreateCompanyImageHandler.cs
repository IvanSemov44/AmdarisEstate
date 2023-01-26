namespace IvanRealEstate.Application.Handlers.CompanyImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Application.Handlers.CompanyHandlers;
    using IvanRealEstate.Shared.DataTransferObject.CompanyImage;
    using IvanRealEstate.Application.Commands.CompanyImageCommands;

    public sealed class CreateCompanyImageHandler : IRequestHandler<CreateCompanyImageCommand, CompanyImageDto>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CreateCompanyImageHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<CompanyImageDto> Handle(CreateCompanyImageCommand request, CancellationToken cancellationToken)
        {
            await CheckerForCompany
               .CheckIfCompanyExistAndReturnIt(_repositoryManager, request.CompanyId, request.TrackChanges);

            var image = _mapper.Map<CompanyImage>(request.CompanyImageForCreationDto);

            _repositoryManager.CompanyImage.CreateCompanyImage(request.CompanyId, image);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<CompanyImageDto>(image);
        }
    }
}
