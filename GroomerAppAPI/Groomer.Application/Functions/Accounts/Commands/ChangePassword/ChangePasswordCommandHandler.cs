using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Groomer.Core.Functions.Accounts.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
    {

        private readonly UserManager<IdentityUser> _uManager;
        public ChangePasswordCommandHandler(UserManager<IdentityUser> uManager)
        {
            _uManager = uManager;
        }
        
        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _uManager.FindByIdAsync(request.accountId);
            
            if (request.newPassword == request.newPasswordConfirm)
            {
                await _uManager.ChangePasswordAsync(user, request.oldPassword, request.newPassword);
            }
            return Unit.Value;
        }
    }
}
