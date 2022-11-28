namespace Application.Handlers.EmployeeForCompanyHandlers
{
    using Application.Commands.EmployeeForCompanyCommands;
    using AutoMapper;
    using Contracts;
    using Entities.Exceptions;
    using MediatR;

    internal sealed class DeleteEmployeeForCompanyHandler : IRequestHandler<DeleteEmployeeForCompanyCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public DeleteEmployeeForCompanyHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(DeleteEmployeeForCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(request.CompanyId, request.TrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(request.CompanyId);

            var employee = await _repositoryManager.Employee.GetEmployeeAsync(request.CompanyId, request.EmployeeId, request.TrackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(request.EmployeeId);

            _repositoryManager.Employee.DeleteEmployee(employee);
            await _repositoryManager.SaveAsync();

            return Unit.Value;
        }
    }
}
