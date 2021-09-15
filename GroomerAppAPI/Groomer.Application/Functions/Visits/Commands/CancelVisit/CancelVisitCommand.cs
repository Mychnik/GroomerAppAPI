using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Application.Functions.Visits.Commands.CancelVisit
{
    public class CancelVisitCommand : IRequest<Unit>
    {
        public int visitId { get; set; }
    }
}
