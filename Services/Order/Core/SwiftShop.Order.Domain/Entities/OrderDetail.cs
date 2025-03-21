using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Domain.Entities
{
    public class OrderDetail //this entity is for the details of and order. it will give information about the ordered products.
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; } //products data was saving in MongoDb and we'll get the data from there. so that we are defining the ProductId as string type. 
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; } //the unit price of a product
        public int ProductAmount { get; set; } //How many units of a particular product the user ordered.
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
        public Ordering Ordering { get; set; } //it will have a relationship with Ordering class. 
    }
}
