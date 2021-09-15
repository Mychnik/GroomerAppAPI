using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Groomer.Core.Functions.Employees.Commands.VacationApplicationCommand
{
    public class VacationAplicationCommandHandler : IRequestHandler<VacationAplicationCommand, Unit>
    {
        public Task<Unit> Handle(VacationAplicationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
