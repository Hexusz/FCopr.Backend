using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FCopr.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryValidator : AbstractValidator<GetOrderListQuery>
    {
        public GetOrderListQueryValidator()
        {

        }
    }
}
