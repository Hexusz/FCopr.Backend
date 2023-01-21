using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCorp.Domain
{
    public class Order
    {
        public ushort OrderId { get; set; }
        public string ClientFullName { get; set; }
        public OrderStatus Status { get; set; }

        //Ссылка на позиции заказа
        public List<OrderPositions> Positions { get; set; } = new List<OrderPositions>();
    }
}
