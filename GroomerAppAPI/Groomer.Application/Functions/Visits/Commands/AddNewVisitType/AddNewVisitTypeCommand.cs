using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Application.Functions.Visits.Commands
{
    public class AddNewVisitTypeCommand : IRequest<Unit>
    {
        public string name { get; set; }
        public int requiredTime { get; set; }
        public int cost { get; set; }
    }
}
