using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCorp.Domain;

namespace FCopr.Application.Common.Exceptions
{
    public class IncorrectAmountGoodsException : Exception
    {
        public IncorrectAmountGoodsException(int goods, object key)
            : base($"The number of products cannot be more than 10. Goods amount: {goods}") { }
    }
}
