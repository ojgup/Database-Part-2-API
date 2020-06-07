using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database_Part_2_API.Models
{
    public partial class Authorisedperson2177
    {
        public Authorisedperson2177()
        {
            Clientauthorisedaccounts2177 = new HashSet<Clientauthorisedaccounts2177>();
            Order2177 = new HashSet<Order2177>();
        }

        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Accountid { get; set; }

        public virtual Clientaccount2177 Account { get; set; }
        public virtual ICollection<Clientauthorisedaccounts2177> Clientauthorisedaccounts2177 { get; set; }
        public virtual ICollection<Order2177> Order2177 { get; set; }
    }
}
