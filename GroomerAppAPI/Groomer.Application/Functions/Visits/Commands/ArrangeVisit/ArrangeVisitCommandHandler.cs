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

namespace Groomer.Application.Functions.Visits.Commands.ArrangeVisit
{
    public class ArrangeVisitCommandHandler : IRequestHandler<ArrangeVisitCommand, Unit>
    {
        private readonly IRepositoryAsync<Visit> _visitRepository;
        private readonly IRepositoryAsync<VisitType> _visitTypeRepository;
        
        private readonly IMapper _mapper;
       
        public ArrangeVisitCommandHandler(IRepositoryAsync<Visit> visitRepository, IMapper mapper, IRepositoryAsync<VisitType> visitTypeRepository)
        {
            
            _visitRepository = visitRepository;
            _visitTypeRepository = visitTypeRepository;
            _mapper = mapper;
           
        }
        public async Task<Unit> Handle(ArrangeVisitCommand request, CancellationToken cancellationToken)
        {
            var newVisit = _mapper.Map<Visit>(request);

            var visitType = await _visitTypeRepository.GetByIdAsync(request.visitTypeId);
            newVisit.visitEndDate = newVisit.visitStartDate.AddMinutes(visitType.requiredTime);
            //sprawdzenie czy jest wolny termin
           
                await _visitRepository.AddAsync(newVisit);
                return Unit.Value;
           
               
        }
    }
}
