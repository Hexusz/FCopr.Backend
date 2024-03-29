﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCopr.Application.FCorp.Commands.CreateOrder;
using FluentValidation;

namespace FCopr.Application.FCorp.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(updateOrderCommand => updateOrderCommand.OrderId).NotEmpty();
        }
    }
}