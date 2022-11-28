using Application.Commands.CityCommands;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Handlers.CityHandlers
{
    public sealed class UpdateCityHandler : IRequestHandler<UpdateCityCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateCityHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _repositoryManager.City.GetCityAsync(request.CityId, request.TrackChanges);
            if (city is null)
                throw new CityNotFoundException(request.CityId);

            _mapper.Map(request.CityForUpdateDto, city);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
