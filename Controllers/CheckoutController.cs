using Kitchen_Appliances.Helpers;
using Kitchen_Appliances.Infrastructure;
using Kitchen_Appliances.Models;
using Kitchen_Appliances.PayPalHelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kitchen_Appliances.Controllers
{
    public class CheckoutController : Controller
    {
        public IConfiguration configuration { get; }
        private readonly StoreDbContext context;

        public CheckoutController(IConfiguration _configuration, StoreDbContext _context)
        {
            configuration = _configuration;
            context = _context;
        }
        public IActionResult Index()
        {
            Itemcart Items = HttpContext.Session.GetJson<Itemcart>("cart");
            return View(Items);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(decimal total, string firstName, string lastName, string email, string Number, string address)
        {
            var payPalAPI = new PayPalAPI(configuration);
            string url = await payPalAPI.getRedirectURLToPayPal(total, "USD");
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            string OrderOPP = builder.Append(Convert.ToChar(Convert.ToInt32(random.Next(1, 125)))).ToString();
            Customer customer = new Customer
            {
                CustomerName = firstName + lastName,
                CustomerEmail = email,
                ImageUrl = null,
            };
            Order order = new Order
            {
                OrderOPP = OrderOPP,
                CustomerID = customer.CustomerID,
                OrderAddress = address,
                ShipMethod = 1,
                PaymentMethod = 1,
                PaymentStatus = true,
                TotalPrice = total,
                OrderStatus = true
            };
            Itemcart Items = HttpContext.Session.GetJson<Itemcart>("cart");
            foreach (var item in Items.Items)
            {
                OrderItem orderItem = new OrderItem
                {
                    ProductID = item.Product.ProductID,
                    OrderID = order.OrderID,
                    ProductQty = item.Quantity,
                };
                context.OrderItems.Add(orderItem);
            };
            context.Customers.Add(customer);
            context.Orders.Add(order);
            context.SaveChanges();
            return Redirect(url);
        }
        [Route("Success")]
        public async Task<IActionResult> Success(decimal total)
        {
            var payPalAPI = new PayPalAPI(configuration);
            string url = await payPalAPI.getRedirectURLToPayPal(total, "USD");
            return Redirect(url);
        }
    }
}
