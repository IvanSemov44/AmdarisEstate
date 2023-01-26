namespace IvanRealEstate.Application.Handlers.CompanyImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Application.Handlers.CompanyHandlers;
    using IvanRealEstate.Application.Queries.CompanyImageQuery;
    using IvanRealEstate.Shared.DataTransferObject.CompanyImage;

    public sealed class GetAllCompanyImagesHandler : IRequestHandler<GetAllCompanyImagesQuery, IEnumerable<CompanyImageDto>>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetAllCompanyImagesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<CompanyImageDto>> Handle(GetAllCompanyImagesQuery request, CancellationToken cancellationToken)
        {
            await CheckerForCompany.CheckIfCompanyExistAndReturnIt(_repositoryManager, request.CompanyId, request.TrackChanges);

            var imagesForEstate = await _repositoryManager.CompanyImage.GetCompanyImagesAsync(request.CompanyId, request.TrackChanges);

            var imageForReturn = _mapper.Map<IEnumerable<CompanyImageDto>>(imagesForEstate);

            return imageForReturn;
        }
    }
}
