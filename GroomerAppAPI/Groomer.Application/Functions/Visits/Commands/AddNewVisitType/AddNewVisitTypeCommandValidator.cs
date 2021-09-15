using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Application.Functions.Visits.Commands
{
    public class AddNewVisitTypeCommandValidator : AbstractValidator<AddNewVisitTypeCommand>
    {
        public AddNewVisitTypeCommandValidator()
        {
            RuleFor(x => x.name).MinimumLength(3).MaximumLength(15);
            RuleFor(x => x.cost).InclusiveBetween(1, 1000);
            RuleFor(x => x.requiredTime).InclusiveBetween(1, 1000);
        }
    }
}
