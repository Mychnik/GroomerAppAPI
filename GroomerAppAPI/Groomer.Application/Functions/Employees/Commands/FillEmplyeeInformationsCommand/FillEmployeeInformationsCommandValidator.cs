using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Groomer.Core.Functions.Employees.Commands.FillEmplyeeInformations;

namespace Groomer.Core.Functions.Employees.Commands.FillEmplyeeInformationsCommand
{
   public class FillEmployeeInformationsCommandValidator : AbstractValidator<FillEmployeeInformationsCommand>
    {
        public FillEmployeeInformationsCommandValidator()
        {
            RuleFor(x => x.name).MinimumLength(3).MaximumLength(15).WithMessage("Length must me beetween 3 and 15");
            RuleFor(x => x.surename).MinimumLength(3).MaximumLength(15).WithMessage("Length must be beetween 3 and 15");
            RuleFor(x => x.dateOfBirth).NotNull().WithMessage("Date can't be null");
        }
    }
}
