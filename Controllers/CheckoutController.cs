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
        public CheckoutController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult Index()
        {
            Itemcart Items = HttpContext.Session.GetJson<Itemcart>("cart");
            return View(Items);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(IApplicationBuilder app, decimal total, string firstName, string lastName, string email, string Number, string address)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            var payPalAPI = new PayPalAPI(configuration);
            string url = await payPalAPI.getRedirectURLToPayPal(total, "USD");
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            string OrderOPP = builder.Append(Convert.ToChar(Convert.ToInt32(random.Next(1000000, 9999999)))).ToString();
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
            context.OrderItems.AddRange();
            {
                foreach (var item in Items.Items)
                {
                    new OrderItem
                    {
                        ProductID = item.Product.ProductID,
                        OrderID = order.OrderID,
                        ProductQty = item.Quantity,
                    };
                };
            };
            context.Customers.AddRange(customer);
            context.Orders.AddRange(order);
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
