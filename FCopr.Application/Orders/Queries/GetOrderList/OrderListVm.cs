using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCopr.Application.Orders.Queries.GetOrderList
{
    public class OrderListVm
    {
        public IList<OrderLookupDto> Orders { get; set; }
    }
}
