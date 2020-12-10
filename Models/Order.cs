using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderOPP { get; set; }
        public int CustomerID { get; set; }
        public string OrderAddress { get; set; }
        public int ShipMethod { get; set; }
        public int PaymentMethod { get; set; }
        public int PaymentStatus { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal TotalPrice { get; set; }
        public int OrderStatus { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
