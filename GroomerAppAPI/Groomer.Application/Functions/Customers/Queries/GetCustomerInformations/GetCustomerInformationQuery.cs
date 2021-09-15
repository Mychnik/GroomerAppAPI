using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Groomer.Core.Functions.Users.Queries.GetUserInformations
{
  public  class GetCustomerInformationQuery : IRequest<CustomerInformations>
    {
        public string id { get; set; }
    }
}
