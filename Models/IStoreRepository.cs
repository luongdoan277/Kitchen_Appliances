using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Models
{
    public class IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
