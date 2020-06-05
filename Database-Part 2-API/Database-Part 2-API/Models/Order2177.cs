using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Order2177
    {
        public Order2177()
        {
            Orderline2177 = new HashSet<Orderline2177>();
        }

        public int Orderid { get; set; }
        public string Shippingaddress { get; set; }
        public DateTime Datetimecreated { get; set; }
        public DateTime? Datetimedispatched { get; set; }
        public decimal Total { get; set; }
        public int Userid { get; set; }

        public virtual Authorisedperson2177 User { get; set; }
        public virtual ICollection<Orderline2177> Orderline2177 { get; set; }
    }
}
