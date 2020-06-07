using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Clientauthorisedaccounts2177
    {
        public int Accountid { get; set; }
        public string Acctname { get; set; }
        public decimal Balance { get; set; }
        public decimal Creditlimit { get; set; }
        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Clientaccount2177 Account { get; set; }
        public virtual Authorisedperson2177 User { get; set; }
    }
}
