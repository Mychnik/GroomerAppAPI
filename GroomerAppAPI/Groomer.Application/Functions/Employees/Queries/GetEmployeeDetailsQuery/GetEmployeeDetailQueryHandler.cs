using AutoMapper;
using Groomer.Application.Interfaces;
using Groomer.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Groomer.Core.Functions.Employees.Queries.GetEmployeeDetailsQuery
{
    public class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeDetailModel>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Employee> _repository;

        public GetEmployeeDetailQueryHandler(IMapper mapper, IRepositoryAsync<Employee> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<EmployeeDetailModel> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
        {
            var employeeDetails = await _repository.GetByIdAsync(request.employeeId);
            return _mapper.Map<EmployeeDetailModel>(employeeDetails);
        }
    }
}
