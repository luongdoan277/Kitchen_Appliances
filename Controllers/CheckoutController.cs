using BraintreeHttp;
using Kitchen_Appliances.Helpers;
using Kitchen_Appliances.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayPal.Core;
using PayPal.v1.Payments;
using Kitchen_Appliances.Models;
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
        private readonly IStoreRepository repository;


        public CheckoutController(IConfiguration _configuration, StoreDbContext _context, IStoreRepository repo)
        {
            configuration = _configuration;
            context = _context;
            repository = repo;
        }
        public IActionResult Index()
        {
            Itemcart Items = HttpContext.Session.GetJson<Itemcart>("cart");
            return View(Items);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(int payment_method, double total, string firstName, string lastName, string email, string Number, string address)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            string OrderOPP = builder.Append(Convert.ToInt32(random.Next(1, 99999))).ToString();
            Customer customer = new Customer
            {
                CustomerName = firstName + lastName,
                CustomerEmail = email,
                CustomerPhone = Number,
                ImageUrl = null,
            };
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
            //var customer1 = new Customer();

            //Where(c => c.CustomerEmail == customer.CustomerEmail)
            Models.Order order = new Models.Order
            {
                OrderOPP = OrderOPP,
                CustomerID = customer.CustomerID,
                OrderAddress = address,
                ShipMethod = 1,
                PaymentMethod = payment_method,
                PaymentStatus = true,
                TotalPrice = total,
                dateTime = DateTime.Now,
                OrderStatus = true
            };
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            var orderID = order.OrderID;
            Console.WriteLine(orderID);
            Itemcart Items = HttpContext.Session.GetJson<Itemcart>("cart");
            foreach (var item in Items.Items)
            {
                OrderItem orderItem = new OrderItem
                {
                    ProductID = item.Product.ProductID,
                    OrderID = orderID,
                    ProductQty = item.Quantity,
                };
                await context.OrderItems.AddAsync(orderItem);
            };
            context.SaveChanges();
            string url = null;
            if (payment_method == 2)
            {
                HttpContext.Session.Remove("cart");
                url = "/";
            }
            else
            {
                if (payment_method == 1)
                {
                    url = await PaypalPayment(total);
                    if(url != null)
                    {
                        HttpContext.Session.Remove("cart");
                    };
                }
            }
            return Redirect(url);
        }

        public async Task<string> PaypalPayment(double total)
        {
            var environment = new SandboxEnvironment(configuration["PayPal:clientId"], configuration["PayPal:secret"]);
            var client = new PayPalHttpClient(environment);

            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        Amount = new Amount()
                        {
                            Total = total.ToString(),
                            Currency = "USD"
                        }
                    }
                },
                RedirectUrls = new RedirectUrls()
                {
                    CancelUrl = configuration["PayPal:cancelUrl"],
                    ReturnUrl = configuration["PayPal:returnUrl"]
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };

            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);
            string paypalRedirectUrl = null;
            try
            {
                HttpResponse response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();
                var links = result.Links.GetEnumerator();
                while (links.MoveNext())
                {
                    LinkDescriptionObject lnk = links.Current;
                    if (lnk.Rel.ToLower().Trim().Equals("approval_url"))
                    {
                        //saving the payapalredirect URL to which user will be redirected for payment  
                        paypalRedirectUrl = lnk.Href;
                    }
                }
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
            }
            return paypalRedirectUrl;
        }
    }
}
