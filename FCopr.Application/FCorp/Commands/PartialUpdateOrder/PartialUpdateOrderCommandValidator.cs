using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCorp.Domain;
using FluentValidation;

namespace FCopr.Application.FCorp.Commands.PartialUpdateOrder
{
    public class PartialUpdateOrderCommandValidator : AbstractValidator<PartialUpdateOrderCommand>
    {
        public PartialUpdateOrderCommandValidator()
        {
            RuleFor(partialUpdateOrderCommand => partialUpdateOrderCommand.OrderId).NotEmpty();
        }
    }
}
