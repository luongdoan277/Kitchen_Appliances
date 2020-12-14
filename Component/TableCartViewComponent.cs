using Kitchen_Appliances.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Kitchen_Appliances.Component
{
    public class TableCartViewComponent : ViewComponent
    {
        private IStoreRepository repository;

        public TableCartViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
