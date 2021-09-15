using AutoMapper;
using Groomer.Application.Common;
using Groomer.Application.Models;
using Groomer.Core.Functions.Employees.Commands.FillEmplyeeInformations;
using Groomer.Core.Functions.Employees.Commands.VacationApplicationCommand;
using Groomer.Core.Functions.Employees.Queries.GetEmployeeDetailsQuery;
using Groomer.Core.Functions.Employees.Queries.GetEmployeesInListQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groomer.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [Authorize(Roles = IdentityConstantHelper.EmployeeRoleConst)]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public EmployeeController(IMediator mediator, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet("GetAllEmployees", Name = "GetAllEmployees")]
        [AllowAnonymous]
        public async Task<ActionResult<List<EmployeersInListModel>>> GetAllEmployees()
        {
            var result = await _mediator.Send(new GetEmployeesInListQuery());
            return Ok(result);
        }

        [HttpGet("GetCurrentEmployeeDetails", Name = "GetCurrentEmployeeDetails")]

        public async Task<ActionResult<EmployeeDetailModel>> GetCurrentEmployeeDetails()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var request = new GetEmployeeDetailQuery();
            request.employeeId = currentUserId;
            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpPost("FillEmployeeInformations", Name = "FillEmployeeInformations")]
        public async Task<ActionResult> FillEmployeeInformations([FromBody] FillEmployeeInformationViewModel fillEmployeeInformations)
        {
            var command = new FillEmployeeInformationsCommand();
            var employeeId = _userManager.GetUserId(HttpContext.User);
            command.id = employeeId;
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost("VacationApplication", Name = "VacationApplication")]

        public async Task<ActionResult> VacationApplication([FromBody] VacationApplicationViewModel vacationApplication)
        {

            var command = new VacationAplicationCommand();
            var employeeId = _userManager.GetUserId(HttpContext.User);
            //command.Id = employeeId;
            await _mediator.Send(command);
            return Ok();
        }
    }
}
