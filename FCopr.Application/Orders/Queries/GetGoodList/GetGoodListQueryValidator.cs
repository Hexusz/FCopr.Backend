using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FCopr.Application.Orders.Queries.GetGoodList
{
    public class GetGoodListQueryValidator : AbstractValidator<GetGoodListQuery>
    {
        public GetGoodListQueryValidator()
        {

        }
    }
}
