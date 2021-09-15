using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Groomer.Application.Common;
using Groomer.Application.Interfaces;
using Groomer.Domain.Entities;

namespace Groomer.Core.Functions.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit>
    {
       
        private readonly UserManager<IdentityUser> _uManager;
        private readonly IRepositoryAsync<Customer> _customerRepository;
        private readonly IRepositoryAsync<Employee> _employeeRepository;
        public DeleteAccountCommandHandler (UserManager<IdentityUser> uManager, IRepositoryAsync<Customer> customerRepository, IRepositoryAsync<Employee> employeeRepository)
        {
            _uManager = uManager;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _uManager.FindByIdAsync(request.id);
            bool isEmployee = await _uManager.IsInRoleAsync(user, IdentityConstantHelper.EmployeeRoleConst);
            if (user.PasswordHash == request.password)
            {
                await _uManager.DeleteAsync(user);
                if(isEmployee)
                {
                    var userToDelete = await _employeeRepository.GetByIdAsync(request.id);
                    await _employeeRepository.DeleteAsync(userToDelete);
                    return Unit.Value;
                }
                else if(!isEmployee)
                {
                    var userToDelete = await _customerRepository.GetByIdAsync(request.id);
                    await _customerRepository.DeleteAsync(userToDelete);
                    return Unit.Value;
                }
                return Unit.Value;
            }
            else
                //wyjatek?
                return Unit.Value;
           
        }
    }
}
