using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCorp.Domain;

namespace FCopr.Application.Common.Exceptions
{
    public class IncorrectStatusException : Exception
    {
        public IncorrectStatusException(ushort orderId,OrderStatus orderStatus, object key)
            : base($"Order {orderId} in {orderStatus} status cannot be changed") { }
    }
}
