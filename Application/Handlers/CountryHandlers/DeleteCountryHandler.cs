using Application.Commands.CountryCommands;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Handlers.CountryHandlers
{
    public sealed class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, Unit>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public DeleteCountryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _repositoryManager.Country.GetCountryAsync(request.CountryId, request.TrackChanges);
            if (country is null)
                throw new CountryNotFoundException(request.CountryId);

            _repositoryManager.Country.DeleteCountry(country);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
