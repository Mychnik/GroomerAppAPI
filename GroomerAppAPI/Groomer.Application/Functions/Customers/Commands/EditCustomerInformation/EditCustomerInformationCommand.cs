using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Groomer.Core.Functions.Users.Commands.EditUserInformation
{
    public class EditCustomerInformationCommand : IRequest<Unit>
    {
        public string customerId { get; set; }
        public string name { get; set; }
        public string surename { get; set; }
        public DateTime dateOfBirth { get; set; }
        public IFormFile Image { get; set; }
    }
}
