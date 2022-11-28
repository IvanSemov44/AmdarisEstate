namespace IvanRealEstate.Application.Handlers.EstateTypeHandler
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Shared.DataTransferObject.EstateType;
    using IvanRealEstate.Application.Commands.EstateTypeCommands;

    internal sealed class CreateEstateTypeHandler : IRequestHandler<CreateEstateTypeCommand, EstateTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CreateEstateTypeHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<EstateTypeDto> Handle(CreateEstateTypeCommand request, CancellationToken cancellationToken)
        {
            var estateType = _mapper.Map<EstateType>(request.EstateTypeForCreationDto);

            _repositoryManager.EstateType.CreateEstateType(estateType);
            await _repositoryManager.SaveAsync();

            var estateTypeForReturn = _mapper.Map<EstateTypeDto>(estateType);

            return estateTypeForReturn;
        }
    }
}
