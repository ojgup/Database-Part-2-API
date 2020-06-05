using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Location2177
    {
        public Location2177()
        {
            Inventory2177 = new HashSet<Inventory2177>();
            Purchaseorder2177 = new HashSet<Purchaseorder2177>();
        }

        public string Locationid { get; set; }
        public string Locname { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }

        public virtual ICollection<Inventory2177> Inventory2177 { get; set; }
        public virtual ICollection<Purchaseorder2177> Purchaseorder2177 { get; set; }
    }
}
