using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Models
{
    public class Media
    {
        public int MediaID { get; set; }
        public string MediaImage1 { get; set; }
        public string MediaImage2 { get; set; }
        public string MediaImage3 { get; set; }
        public int ProductID { get; set; }

        public virtual Product Products { get; set; }
    }
}
