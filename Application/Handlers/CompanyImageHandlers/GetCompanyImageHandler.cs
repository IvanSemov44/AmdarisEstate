namespace IvanRealEstate.Application.Handlers.CompanyImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.CompanyHandlers;
    using IvanRealEstate.Application.Queries.CompanyImageQuery;
    using IvanRealEstate.Shared.DataTransferObject.CompanyImage;

    public sealed class GetCompanyImageHandler : IRequestHandler<GetCompanyImageQuery, CompanyImageDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetCompanyImageHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<CompanyImageDto> Handle(GetCompanyImageQuery request, CancellationToken cancellationToken)
        {
            await CheckerForCompany.CheckIfCompanyExistAndReturnIt(_repositoryManager, request.CompanyId, request.TrackChanges);

            var image = await CheckerForCompanyImage.CheckIfCompanyImageExistAndReturnIt(_repositoryManager, request.CompanyId, request.CompanyImageId, request.TrackChanges);

            var imageForReturn = _mapper.Map<CompanyImageDto>(image);

            return imageForReturn;
        }
    }
}
