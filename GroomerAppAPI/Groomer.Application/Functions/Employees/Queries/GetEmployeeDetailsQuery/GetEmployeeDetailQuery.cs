using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Groomer.Core.Functions.Employees.Queries.GetEmployeeDetailsQuery
{
  public  class GetEmployeeDetailQuery : IRequest<EmployeeDetailModel>
    {
        public string employeeId { get; set; }
    }
}
