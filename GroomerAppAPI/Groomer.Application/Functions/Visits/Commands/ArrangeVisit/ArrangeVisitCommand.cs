using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Application.Functions.Visits.Commands.ArrangeVisit
{
    public class ArrangeVisitCommand : IRequest<Unit>
    {
        public string emplyeeId { get; set; }
        public string customerId { get; set; }
        public int petId { get; set; }
        public DateTime date { get; set; }
        public int visitTypeId { get; set; }
    }
}
