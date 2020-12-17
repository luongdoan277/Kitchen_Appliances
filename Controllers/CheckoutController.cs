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
        public async Task<IActionResult> Checkout(int payment_method,double total, string firstName, string lastName, string email, string Number, string address)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            string OrderOPP = builder.Append(Convert.ToChar(Convert.ToInt32(random.Next(1, 125)))).ToString();
            Customer customer = new Customer
            {
                CustomerName = firstName + lastName,
                CustomerEmail = email,
                ImageUrl = null,
            };
            context.Customers.Add(customer);
            Models.Order order = new Models.Order
            {
                OrderOPP = OrderOPP,
                CustomerID = customer.CustomerID,
                OrderAddress = address,
                ShipMethod = 1,
                PaymentMethod = payment_method,
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
            context.Orders.Add(order);
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
                                url = lnk.Href;
                            }
                        }
                    }
                    catch (HttpException httpException)
                    {
                        var statusCode = httpException.StatusCode;
                        var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
                    }
                }
            }
            return Redirect(url);
        }

        //public async Task<IActionResult> CreatePaypalPaymentAsync(double total)
        //{
        //    var environment = new SandboxEnvironment(configuration["PayPal:clientId"], configuration["PayPal:secret"]);
        //    var client = new PayPalHttpClient(environment);

        //    var payment = new Payment()
        //    {
        //        Intent = "sale",
        //        Transactions = new List<Transaction>()
        //        {
        //            new Transaction()
        //            {
        //                Amount = new Amount()
        //                {
        //                    Total = total.ToString(),
        //                    Currency = "USD"
        //                }
        //            }
        //        },
        //        RedirectUrls = new RedirectUrls()
        //        {
        //            CancelUrl = configuration["PayPal:cancelUrl"],
        //            ReturnUrl = configuration["PayPal:returnUrl"]
        //        },
        //        Payer = new Payer()
        //        {
        //            PaymentMethod = "paypal"
        //        }
        //    };

        //    PaymentCreateRequest request = new PaymentCreateRequest();
        //    request.RequestBody(payment);

        //    try
        //    {
        //        HttpResponse response = await client.Execute(request);
        //        var statusCode = response.StatusCode;
        //        Payment result = response.Result<Payment>();
        //        return var links = result.Links.GetEnumerator();
        //        string paypalRedirectUrl = null;
        //        while (links.MoveNext())
        //        {
        //            LinkDescriptionObject lnk = links.Current;
        //            if (lnk.Rel.ToLower().Trim().Equals("approval_url"))
        //            {
        //                //saving the payapalredirect URL to which user will be redirected for payment  
        //                paypalRedirectUrl = lnk.Href;
        //            }
        //        }

        //        return Redirect(paypalRedirectUrl);
        //    }
        //    catch (HttpException httpException)
        //    {
        //        var statusCode = httpException.StatusCode;
        //        var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
        //        return Redirect("/Paypal/CheckoutFail");
        //    }
        //}
        [Route("Success")]
        public IActionResult Success(double total)
        {
            return View();
        }
    }
}
