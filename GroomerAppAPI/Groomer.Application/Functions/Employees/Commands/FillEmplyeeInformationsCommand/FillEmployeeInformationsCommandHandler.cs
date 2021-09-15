using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Groomer.Domain.Entities;
using Groomer.Application.Interfaces;

namespace Groomer.Core.Functions.Employees.Commands.FillEmplyeeInformations
{
    public class FillEmployeeInformationsCommandHandler : IRequestHandler<FillEmployeeInformationsCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Employee> _repository;
        public FillEmployeeInformationsCommandHandler(IMapper mapper, IRepositoryAsync<Employee> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(FillEmployeeInformationsCommand request, CancellationToken cancellationToken)
        {
            //var userToUpdate = await _repository.GetByStringIdAsync(request.id);
            //var newOne = _mapper.Map(request, userToUpdate);
            var newOne = _mapper.Map<Employee>(request);
            await _repository.UpdateAsync(newOne);
            return Unit.Value;
        }
    }
}
