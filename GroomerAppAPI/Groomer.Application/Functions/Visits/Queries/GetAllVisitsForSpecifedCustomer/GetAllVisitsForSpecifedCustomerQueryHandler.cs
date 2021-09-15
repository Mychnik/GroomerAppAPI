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

namespace Groomer.Application.Functions.Visits.Queries.GetAllVisitsForSpecifedCustomer
{
    class GetAllVisitsForSpecifedCustomerQueryHandler : IRequestHandler<GetAllVisitsForSpecifedCustomerQuery, List<VisitInListFromSpecifedCustomerModel>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Visit> _reposiotry;
        public GetAllVisitsForSpecifedCustomerQueryHandler(IMapper mapper, IRepositoryAsync<Visit> repository)
        {
            _mapper = mapper;
            _reposiotry = repository;
        }
        //public async Task<List<VisitInListFromSpecifedCustomerModel>> Handle(GetAllVisitsForSpecifedCustomerQuery request, CancellationToken cancellationToken)
        //{
        //    var visits = await _reposiotry.GetAllAsync();
        //    //var filteredVisits = visits.Where(x => x.ownerId == request.customerId).OrderBy(x => x.visitStartDate);
        //    var filteredVisits = visits.Where(x => x.customerId == request.customerId).OrderBy(x => x.visitStartDate);
        //    return _mapper.Map<List<VisitInListFromSpecifedCustomerModel>>(filteredVisits);
        //}

        public async Task<List<VisitInListFromSpecifedCustomerModel>> Handle(GetAllVisitsForSpecifedCustomerQuery request, CancellationToken cancellationToken)
        {
            var visits = await _reposiotry.GetAllAsync();
            //var filteredVisits = visits.Where(x => x.ownerId == request.customerId).OrderBy(x => x.visitStartDate);
            var filteredVisits = visits.Where(x => x.customerId == request.customerId).OrderBy(x => x.visitStartDate);
            return _mapper.Map<List<VisitInListFromSpecifedCustomerModel>>(filteredVisits);
        }
    }
}
