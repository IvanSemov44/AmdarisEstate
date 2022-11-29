using AutoMapper;
using IvanRealEstate.Application.Queries.EstateTypeQuery;
using IvanRealEstate.Contracts;
using IvanRealEstate.Shared.DataTransferObject.EstateType;
using MediatR;

namespace IvanRealEstate.Application.Handlers.EstateTypeHandler
{
    internal sealed class GetEstateTypesHandler : IRequestHandler<GetEstateTypesQuery,IEnumerable<EstateTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetEstateTypesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<EstateTypeDto>> Handle(GetEstateTypesQuery request, CancellationToken cancellationToken)
        {
            var estateTypes = await _repositoryManager.EstateType.GetEstateTypesAsync(request.TrackChanges);

            var estateTypesForReturn = _mapper.Map<IEnumerable<EstateTypeDto>>(estateTypes);

            return estateTypesForReturn;
        }
    }
}
