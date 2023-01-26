namespace IvanRealEstate.Application.Handlers.OwnerImageHandlers
{
    using MediatR;
    using AutoMapper;

    using IvanRealEstate.Contracts;
    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Shared.DataTransferObject.OwnerImage;
    using IvanRealEstate.Application.Commands.OwnerImageCommands;

    public sealed class CreateOwnerImageHandler : IRequestHandler<CreateOwnerImageCommand, OwnerImageDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CreateOwnerImageHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<OwnerImageDto> Handle(CreateOwnerImageCommand request, CancellationToken cancellationToken)
        {
            var image = _mapper.Map<OwnerImage>(request.OwnerImageForCreationDto);

            _repositoryManager.OwnerImage.CreateOwnerImage(request.OwnerId, image);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<OwnerImageDto>(image);
        }
    }
}
