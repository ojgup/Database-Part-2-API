using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Clientaccount2177
    {
        public Clientaccount2177()
        {
            Accountpayment2177 = new HashSet<Accountpayment2177>();
            Authorisedperson2177 = new HashSet<Authorisedperson2177>();
        }

        public int Accountid { get; set; }
        public string Acctname { get; set; }
        public decimal Balance { get; set; }
        public decimal Creditlimit { get; set; }

        public virtual ICollection<Accountpayment2177> Accountpayment2177 { get; set; }
        public virtual ICollection<Authorisedperson2177> Authorisedperson2177 { get; set; }
    }
}
