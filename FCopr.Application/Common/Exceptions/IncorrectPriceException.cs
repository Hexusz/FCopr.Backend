using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCorp.Domain;

namespace FCopr.Application.Common.Exceptions
{
    public class IncorrectPriceException : Exception
    {
        public IncorrectPriceException(decimal price, object key)
            : base($"The amount of goods cannot be more than 15000. Goods price: {price}") { }
    }
}
