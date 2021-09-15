using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Groomer.Domain.Entities;
using Groomer.Application.Interfaces;

namespace Groomer.Core.Functions.Employees.Queries.GetEmployeesInListQuery
{
    public class GetEmployeesInListQueryHandler : IRequestHandler<GetEmployeesInListQuery, List<EmployeersInListModel>>
    {
        private readonly IRepositoryAsync<Employee> _repository;
        private readonly IMapper _mapper;
        public GetEmployeesInListQueryHandler(IRepositoryAsync<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<EmployeersInListModel>> Handle(GetEmployeesInListQuery request, CancellationToken cancellationToken)
        {
            var employeers = await _repository.GetAllAsync();
            return _mapper.Map<List<EmployeersInListModel>>(employeers); 
        }
    }
}
