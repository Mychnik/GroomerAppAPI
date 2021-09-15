using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Groomer.Core.Functions.Accounts.Commands.LogOut
{
    public class LogOutCommandHandler : IRequestHandler<LogOutCommand>
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public LogOutCommandHandler(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<Unit> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();

            return Unit.Value;
        }
    }
}
