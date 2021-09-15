using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Application.Functions.Visits.Queries.GetAllVisitsForSpecifedCustomer
{
    class GetAllVisitsForSpecifedCustomerQuery : IRequest<List<VisitInListFromSpecifedCustomerModel>>
    {
        public string customerId { get; set; }
    }
}
