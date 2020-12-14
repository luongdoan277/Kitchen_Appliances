using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string ProductImage { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        public int Status { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Categories { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
    }
}
