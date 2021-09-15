using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Groomer.Application.Common;
using Groomer.Domain.Entities;
using Groomer.Application.Interfaces;

namespace Groomer.Core.Functions.Accounts.Commands.Register
{
    //handler obsługuje RegisterAccountCommant, zwraca IdentityResult
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, IdentityResult>
    {
        private readonly UserManager<IdentityUser> _uManager;
        private readonly IRepositoryAsync<Customer> _customerRepository;
        private readonly IRepositoryAsync<Employee> _employeeRepository;



        //Basic repository stworzyc jedno i przypisać na podstawei boola
        private readonly IMapper _mapper;
        
        public RegisterAccountCommandHandler(IRepositoryAsync<Employee> employeeRepository, IRepositoryAsync<Customer> customerRepository, UserManager<IdentityUser> uManager, IMapper mapper)
        {
            _uManager = uManager;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<IdentityResult> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser {UserName = request.username, Email = request.email};
            var result = await _uManager.CreateAsync(user, request.password);

            if (request.isEmployee)
            {
                if (result.Succeeded)
                {
                    await _uManager.AddToRoleAsync(user, IdentityConstantHelper.EmployeeRoleConst);
                    var employee = _mapper.Map<Employee>(user);
                    await _employeeRepository.AddAsync(employee);
                }
                return result;
            }
            else if (!request.isEmployee)
            {
                if (result.Succeeded)
                {
                    await _uManager.AddToRoleAsync(user, IdentityConstantHelper.CustomerRoleConst);
                    var customer = _mapper.Map<Customer>(user);
                    await _customerRepository.AddAsync(customer);
                }
                return result;
            }
            else
            {
                return result;
            }

        }
    }
}
