using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Purchaseorder2177
    {
        public int Productid { get; set; }
        public string Locationid { get; set; }
        public DateTime Datetimecreated { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }

        public virtual Location2177 Location { get; set; }
        public virtual Product2177 Product { get; set; }
    }
}
