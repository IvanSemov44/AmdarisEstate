using Application.Commands.EmployeeForCompanyCommands;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Handlers.EmployeeForCompanyHandlers
{
    internal sealed class UpdateEmployeeForCompanyHandler : IRequestHandler<UpdateEmployeeForCompanyCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateEmployeeForCompanyHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateEmployeeForCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(request.CompanyId, request.CompanyTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(request.CompanyId);

            var employeeFromDb = await _repositoryManager.Employee.GetEmployeeAsync(request.CompanyId, request.EmployeeId, request.EmployeeTrackChanges);
            if (employeeFromDb is null)
                throw new EmployeeNotFoundException(request.EmployeeId);

            _mapper.Map(request.Employee, employeeFromDb);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
