namespace IvanRealEstate.Application.Handlers.EstateHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Shared.DataTransferObject.Estate;
    using IvanRealEstate.Application.Commands.EstateCommands;
    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;

    public sealed class CreateEstateHandler : IRequestHandler<CreateEstateCommand, EstateDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateEstateHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<EstateDto> Handle(CreateEstateCommand request, CancellationToken cancellationToken)
        {
            var estateEntity = _mapper.Map<Estate>(request.EstateForCreationDto);

            estateEntity.Created = DateTime.UtcNow;
            estateEntity.Changed = DateTime.UtcNow;

            _repositoryManager.Estate.CreateEstate(estateEntity);
            await _repositoryManager.SaveAsync();

            var estateForReturn = _mapper.Map<EstateDto>(estateEntity);

            return estateForReturn;
        }
    }
}
