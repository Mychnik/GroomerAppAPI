using Groomer.Core.Functions.Users.Commands.EditUserInformation;
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
        [HttpPost("EditUserInformation", Name = "EditUserInformation")]
        public async Task<ActionResult> EditUserInformation([FromBody] EditCustomerInformationCommand editUserInformationCommand)
        {
            await _mediator.Send(editUserInformationCommand);
            return Ok();
        }
    }
}
