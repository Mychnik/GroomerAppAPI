using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Groomer.Core.Functions.Accounts.Commands.Login
{
    public class LogInCommand : IRequest<SignInResult>
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
