using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Groomer.Core.Functions.Accounts.Commands.DeleteAccount
{
   public class DeleteAccountCommand : IRequest<Unit>
    {
        public string id { get; set; }
        public string password { get; set; }
    }
}
