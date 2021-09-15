using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Application.Functions.Visits.Queries.GetAllVisitsForSpecifedEmployee
{
    public class GetAllVisitsForSpecifedEmployeeQuery : IRequest<List<VisitsInListFromSpecifedEmployeeModel>>
    {
        public string employeeId { get; set; }
    }
}
