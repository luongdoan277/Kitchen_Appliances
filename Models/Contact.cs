using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string ContactGmail { get; set; }
        public string ContactOperationTime { get; set; }
        public virtual Shop ShopAddress { get; set; }
    }
}
