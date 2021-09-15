using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Groomer.Core.Functions.Employees.Queries.GetEmployeesInListQuery
{
   public class GetEmployeesInListQuery : IRequest<List<EmployeersInListModel>>
    {
    }
}
