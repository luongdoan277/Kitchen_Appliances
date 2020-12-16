using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Models
{
    public class Itemcart
    {
        public class Cart
        {
            public int CartID { get; set; }
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }


        public List<Cart> Items { get; set; } = new List<Cart>();


        public void AddItem(Product product, int quantity)
        {
            Cart item = Items
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();
            if (item == null)
            {
                Items.Add(new Cart
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        public void DeleteAItem(Product product, int quantity)
        {
            Cart item = Items
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();
            item.Quantity -= quantity;
        }

        public void RemoveItem(Product product)
        {
            if(product != null)
            {
                Items.RemoveAll(i => i.Product.ProductID == product.ProductID);
            }
        }

        public decimal ComputeTotalValue()
            => Items.Sum(e => e.Product.Price * e.Quantity);

        //    public void Clear()
        //        => Lines.Clear();
    }
}
