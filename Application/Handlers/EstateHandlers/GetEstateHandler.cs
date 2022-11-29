namespace IvanRealEstate.Application.Handlers.EstateHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Exceptions;
    using IvanRealEstate.Application.Queries.EstateQuery;
    using IvanRealEstate.Shared.DataTransferObject.Estate;

    internal sealed class GetEstateHandler : IRequestHandler<GetEstateQuery, EstateDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetEstateHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<EstateDto> Handle(GetEstateQuery request, CancellationToken cancellationToken)
        {
            var estate = await _repositoryManager.Estate.GetEstateAsync(request.EstateId, request.TrackChanges);
            if (estate is null)
                throw new EstateTypeNotFoundException(request.EstateId);

            var estateForReturn = _mapper.Map<EstateDto>(estate);

            return estateForReturn;
        }
    }
}
