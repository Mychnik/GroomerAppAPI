using Groomer.Application.Common;
using Groomer.Application.Functions.Visits.Commands;
using Groomer.Application.Functions.Visits.Commands.ArrangeVisit;
using Groomer.Application.Functions.Visits.Commands.CancelVisit;
using Groomer.Application.Functions.Visits.Queries.GetAllVisitsForSpecifedCustomer;
using Groomer.Application.Functions.Visits.Queries.GetAllVisitsForSpecifedEmployee;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groomer.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class VisitsController : Controller
    {
        private readonly IMediator _mediator;
        public VisitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllVisitsFromSpecifiedCustomer", Name = "GetAllVisitsFromSpecifedCustomer")]
        [Authorize(Roles = IdentityConstantHelper.CustomerRoleConst)]
        public async Task<ActionResult<List<VisitInListFromSpecifedCustomerModel>>> GetAllVisitsFromSpecifiedCustomer([FromBody] GetAllVisitsForSpecifedCustomerQuery getVisitsFromSpecifiedCustomer)
        {
            var result = await _mediator.Send(getVisitsFromSpecifiedCustomer);
            return result;
        }


        [HttpGet("GetAllVisitsFromSpecifedEmployee", Name = "GetAllVisitsFromSpecifedEmployee")]
        [Authorize(Roles = IdentityConstantHelper.EmployeeRoleConst)]
        public async Task<ActionResult<List<VisitsInListFromSpecifedEmployeeModel>>> GetAllVisitsForSpecifedEmployee([FromBody] GetAllVisitsForSpecifedEmployeeQuery getAllVisitsForSpecifedEmployeeQuery)
        {
            var result = await _mediator.Send(getAllVisitsForSpecifedEmployeeQuery);
            return Ok(result);
        }


        [HttpPost("AddNewVisitType", Name = "AddNewVisitType")]
        [Authorize(Roles = IdentityConstantHelper.EmployeeRoleConst)]
        public async Task<ActionResult> AddNewVisitType([FromBody] AddNewVisitTypeCommand addNewVisitTypeCommand)
        {
            await _mediator.Send(addNewVisitTypeCommand);
            return Ok();
        }


        [HttpPost("ArrangeVisit", Name = "ArrangeVisit")]
        [Authorize(Roles = IdentityConstantHelper.CustomerRoleConst)]
        public async Task<ActionResult> ArrangeVisit([FromBody] ArrangeVisitCommand arrangeVisitCommand)
        {
            await _mediator.Send(arrangeVisitCommand);
            return Ok();
        }


        [HttpDelete("CancelVisit", Name = "CancelVisit")]
        [Authorize(Roles = IdentityConstantHelper.CustomerRoleConst)]
        public async Task<ActionResult> CancelVisit([FromBody] CancelVisitCommand cancelVisitCommand)
        {
            await _mediator.Send(cancelVisitCommand);
            return Ok();
        }
    }
}
