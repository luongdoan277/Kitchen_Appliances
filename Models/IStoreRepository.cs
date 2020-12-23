using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Media> Medias { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Customer> Customers { get; }
    }
}
