using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCorp.Domain
{
    public class OrderPositions
    {
        public int Id { get; set; }
        public ushort OrderId { get; set; }
        public int GoodId { get; set; }
        public byte Count { get; set; }

    }
}
