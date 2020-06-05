using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Orderline2177
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Order2177 Order { get; set; }
        public virtual Product2177 Product { get; set; }
    }
}
