using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Groomer.Core.Functions.Accounts.Commands.Login
{
    public class LogInCommandHandler : IRequestHandler<LogInCommand, SignInResult>
    {
        //private readonly UserManager<IdentityUser> _uManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public LogInCommandHandler(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<SignInResult> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            var singInResult = await _signInManager.PasswordSignInAsync(request.username, request.password, false, false);
            return singInResult;
        }
    }
}
