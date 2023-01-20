using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCopr.Application.Orders.Queries.GetGoodList
{
    public class GoodListVm
    {
        public IList<GoodLookupDto> Goods { get; set; }
    }
}
