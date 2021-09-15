using AutoMapper;
using Groomer.Application.Interfaces;
using Groomer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Groomer.Core.Functions.Users.Commands.EditUserInformation
{
    public class EditCustomerInformationCommandHandler : IRequestHandler<EditCustomerInformationCommand, Unit>
    {
        private readonly IRepositoryAsync<Customer> _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _uManager;
        public EditCustomerInformationCommandHandler(IRepositoryAsync<Customer> repository, IMapper mapper, UserManager<IdentityUser> uManager)
        {
            _uManager = uManager;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(EditCustomerInformationCommand request, CancellationToken cancellationToken)
        {
            //  var newCustomerInformations = _mapper.Map<Customer>(request);
            //await  _repository.UpdateAsync(newCustomerInformations);
            //var userToUpdate = _uManager.FindByIdAsync(request.customerId);
            //var userToUpdate = await _repository.GetByStringIdAsync(request.customerId);
            //var editedOne = await _mapper.Map(request,userToUpdate);
            var newOne = _mapper.Map<Customer>(request);
            await  _repository.UpdateAsync(newOne);
            return Unit.Value;
        }
    }
}
