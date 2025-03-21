using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Domain.Entities
{
    public class Ordering //this entity will be using for making an order.
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; } //an oder should have the users id for tracking the order.
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }//it will have a relationship with OrderDetails entity.
    }
}
