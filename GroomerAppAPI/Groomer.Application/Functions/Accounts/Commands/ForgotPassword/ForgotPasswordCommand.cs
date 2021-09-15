using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Groomer.Core.Functions.Accounts.Commands.ForgotPassword
{
  public  class ForgotPasswordCommand : IRequest<Unit>
    {
        public string emailAddress { get; set; }
    }
}
