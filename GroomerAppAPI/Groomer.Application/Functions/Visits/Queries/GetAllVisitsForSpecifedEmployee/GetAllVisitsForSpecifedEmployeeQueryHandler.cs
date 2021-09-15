using AutoMapper;
using Groomer.Application.Interfaces;
using Groomer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Groomer.Application.Functions.Visits.Queries.GetAllVisitsForSpecifedEmployee
{
    public class GetAllVisitsForSpecifedEmployeeQueryHandler : IRequestHandler<GetAllVisitsForSpecifedEmployeeQuery, List<VisitsInListFromSpecifedEmployeeModel>>
    {
        private readonly IRepositoryAsync<Visit> _repository;
        private readonly IMapper _mapper;
        public GetAllVisitsForSpecifedEmployeeQueryHandler(IRepositoryAsync<Visit> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<VisitsInListFromSpecifedEmployeeModel>> Handle(GetAllVisitsForSpecifedEmployeeQuery request, CancellationToken cancellationToken)
        {
            var visits = await _repository.GetAllAsync();
            var filteredVisits = visits.Where(x => x.employeeId == request.employeeId && x.visitStartDate <= DateTime.Now).ToList();
            return _mapper.Map<List<VisitsInListFromSpecifedEmployeeModel>>(filteredVisits);
        }
    }
}
