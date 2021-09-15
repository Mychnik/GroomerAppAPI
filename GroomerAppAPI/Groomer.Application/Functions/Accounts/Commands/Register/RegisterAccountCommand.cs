using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Groomer.Core.Functions.Accounts.Commands.Register
{
   public class RegisterAccountCommand : IRequest<IdentityResult>
    {
        public string email { get; set; }
        public string  username { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public bool isEmployee { get; set; }
    }
}
