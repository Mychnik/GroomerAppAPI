using AutoMapper;
using Groomer.Application.Common;
using Groomer.Application.Models;
using Groomer.Core.Functions.Accounts.Commands.ChangePassword;
using Groomer.Core.Functions.Accounts.Commands.Login;
using Groomer.Core.Functions.Accounts.Commands.LogOut;
using Groomer.Core.Functions.Accounts.Commands.Register;
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
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(IMediator mediator, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _mediator = mediator;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("Login", Name = "Login")]

        public async Task<ActionResult<Microsoft.AspNetCore.Identity.SignInResult>> Login([FromBody] LogInCommand logInCommand)
        {
            var result = await _mediator.Send(logInCommand);
            return Ok(result);
        }
        [HttpPost("RegisterCustomer", Name = "RegisterCustomer")]

        public async Task<ActionResult<IdentityResult>> RegisterCustomer([FromBody] RegisterAccountViewModel registerData)
        {
            var command = new RegisterAccountCommand();
            command.isEmployee = true;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("RegisterEmployee", Name = "RegisterEmployee")]
        [Authorize(Roles = IdentityConstantHelper.BossRoleConst)]
        public async Task<ActionResult<IdentityResult>> RegisterEmployee([FromBody] RegisterAccountViewModel registerData)
        {
            var command = new RegisterAccountCommand();
            command.isEmployee = false;
            command = _mapper.Map(registerData, command);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("LogOut", Name = "LogOut")]
        public async Task<ActionResult<Unit>> Logout()
        {
            var result = await _mediator.Send(new LogOutCommand());
            return result;
        }
        [HttpPut("ChangePassword", Name = "ChangePassword")]

        public async Task<ActionResult<Unit>> ChangePassword([FromBody] ChangePasswordViewModel dataFromView)
        {
            var request = new ChangePasswordCommand();
            request.accountId = _userManager.GetUserId(HttpContext.User);
            var result = _mapper.Map(dataFromView, request);
            await _mediator.Send(result);
            return Ok();
        }
        //[HttpGet]
        //public ActionResult Test()
        //{
        //    var id = _userManager.GetUserId(HttpContext.User);
        //    return Ok(id);
        //}
    }
}
