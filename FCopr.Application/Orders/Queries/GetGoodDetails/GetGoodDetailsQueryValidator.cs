using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FCopr.Application.Orders.Queries.GetGoodDetails
{
    public class GetGoodDetailsQueryValidator : AbstractValidator<GetGoodDetailsQuery>
    {
        public GetGoodDetailsQueryValidator()
        {
            RuleFor(query => query.Articul).NotEmpty();
        }
    }
}
