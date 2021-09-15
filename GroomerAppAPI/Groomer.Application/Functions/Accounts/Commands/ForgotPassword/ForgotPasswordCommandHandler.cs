//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Vet.Core.Functions.Accounts.Commands.ForgotPassword
//{
//    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Unit>
//    {
//        private readonly UserManager<IdentityUser> _uManager;
//        public ForgotPasswordCommandHandler(UserManager<IdentityUser> uManager)
//        {
//            _uManager = uManager;
//        }
//        public async Task<Unit> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
//        {
//            var user = await _uManager.FindByEmailAsync(request.emailAddress);
//        }
//    }
//}
