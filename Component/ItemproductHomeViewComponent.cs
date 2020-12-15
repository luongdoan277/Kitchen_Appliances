using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Kitchen_Appliances.Models;

namespace Kitchen_Appliances.Component
{
    public class ItemproductHomeViewComponent : ViewComponent
    {
        private readonly IStoreRepository repository;

        public ItemproductHomeViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke(Product product)
        {
            return View(product);
        }
    }
}