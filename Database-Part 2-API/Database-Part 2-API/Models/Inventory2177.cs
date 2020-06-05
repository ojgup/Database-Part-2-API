using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Inventory2177
    {
        public int Productid { get; set; }
        public string Locationid { get; set; }
        public int Numinstock { get; set; }

        public virtual Location2177 Location { get; set; }
        public virtual Product2177 Product { get; set; }
    }
}
