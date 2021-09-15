using Groomer.Application.Interfaces;
using Groomer.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Groomer.Application.Functions.Visits.Commands.CancelVisit
{
    public class CancelVisitCommandHandler : IRequestHandler<CancelVisitCommand, Unit>
    {
        private readonly IRepositoryAsync<Visit> _repository;
        public CancelVisitCommandHandler(IRepositoryAsync<Visit> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CancelVisitCommand request, CancellationToken cancellationToken)
        {
            var visitToCancel = await _repository.GetByIdAsync(request.visitId);
            await _repository.DeleteAsync(visitToCancel);
            return Unit.Value;
        }
    }
}
