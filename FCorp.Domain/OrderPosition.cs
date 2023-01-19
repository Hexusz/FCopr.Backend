using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCorp.Domain
{
    public class OrderPosition
    {
        public Good Good { get; set; }
        public sbyte Count { get; set; }
    }
}
