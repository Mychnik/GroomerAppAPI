using AutoMapper;
using Groomer.Application.Interfaces;
using Groomer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Groomer.Application.Functions.Visits.Commands
{
    public class AddNewVisitTypeCommandHandler : IRequestHandler<AddNewVisitTypeCommand, Unit>
    {
        private readonly IRepositoryAsync<VisitType> _repository;
        private readonly IMapper _mapper;
        public AddNewVisitTypeCommandHandler(IRepositoryAsync<VisitType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(AddNewVisitTypeCommand request, CancellationToken cancellationToken)
        {
            var newVisitType = _mapper.Map<VisitType>(request);
            await _repository.AddAsync(newVisitType);
            return Unit.Value;
        }
    }
}
