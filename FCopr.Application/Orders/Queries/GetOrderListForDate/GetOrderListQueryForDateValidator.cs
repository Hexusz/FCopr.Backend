using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FCopr.Application.Orders.Queries.GetOrderListForDate
{
    public class GetOrderListQueryForDateValidator : AbstractValidator<GetOrderListQueryForDate>
    {
        public GetOrderListQueryForDateValidator()
        {
            RuleFor(date => date.Date).NotEmpty();
        }
    }
}
