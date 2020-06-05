using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Product2177
    {
        public Product2177()
        {
            Inventory2177 = new HashSet<Inventory2177>();
            Orderline2177 = new HashSet<Orderline2177>();
            Purchaseorder2177 = new HashSet<Purchaseorder2177>();
        }

        public int Productid { get; set; }
        public string Prodname { get; set; }
        public decimal? Buyprice { get; set; }
        public decimal? Sellprice { get; set; }

        public virtual ICollection<Inventory2177> Inventory2177 { get; set; }
        public virtual ICollection<Orderline2177> Orderline2177 { get; set; }
        public virtual ICollection<Purchaseorder2177> Purchaseorder2177 { get; set; }
    }
}
