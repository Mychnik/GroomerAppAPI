using AutoMapper;
using Groomer.Application.Interfaces;
using Groomer.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Groomer.Core.Functions.Users.Queries.GetUserInformations
{
    public class GetCustomerInformationQueryHandler : IRequestHandler<GetCustomerInformationQuery, CustomerInformations>
    {
        public IMapper _mapper { get; }
        public IRepositoryAsync<Customer> _repository { get; }
        public GetCustomerInformationQueryHandler(IMapper mapper, IRepositoryAsync<Customer> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        

        public async Task<CustomerInformations> Handle(GetCustomerInformationQuery request, CancellationToken cancellationToken)
        {
            var userDetails = await _repository.GetByIdAsync(request.id);
            return _mapper.Map<CustomerInformations>(userDetails);
        }
    }
}
