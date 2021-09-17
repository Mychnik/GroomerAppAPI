using Groomer.Core.Functions.Users.Commands.EditUserInformation;
using Groomer.Core.Functions.Users.Queries.GetUserInformations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groomer.API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("EditCustomerInformation", Name = "EditCustomerInformation")]
        public async Task<ActionResult> EditUserInformation([FromBody] EditCustomerInformationCommand editUserInformationCommand)
        {
            await _mediator.Send(editUserInformationCommand);
            return Ok();
        }
        [HttpGet("GetCustomerInformation", Name = "GetCustomerInformation")]
        public async Task<ActionResult<CustomerInformations>> GetCustomerInformation([FromBody] GetCustomerInformationQuery getCustomerInformationQuery)
        {
            var result = await _mediator.Send(getCustomerInformationQuery);
            return result;
        }
    }
}
