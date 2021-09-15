using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Application.Functions.Visits.Commands.ArrangeVisit
{
    public class ArrangeVisitCommandValidator : AbstractValidator<ArrangeVisitCommand>
    {
        public ArrangeVisitCommandValidator()
        {
            RuleFor(x => x.visitTypeId).NotEmpty();
            RuleFor(x => x.emplyeeId).NotEmpty();
            RuleFor(x => x.petId).NotEmpty();
        }
    }
}
