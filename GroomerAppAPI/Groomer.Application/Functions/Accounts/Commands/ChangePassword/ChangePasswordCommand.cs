using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Groomer.Core.Functions.Accounts.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Unit>
    {
        public string accountId { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string newPasswordConfirm { get; set; }
    }
}
