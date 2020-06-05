using System;
using System.Collections.Generic;

namespace Database_Part_2_API.Models
{
    public partial class Accountpayment2177
    {
        public int Accountid { get; set; }
        public DateTime Datetimereceived { get; set; }
        public decimal Amount { get; set; }

        public virtual Clientaccount2177 Account { get; set; }
    }
}
