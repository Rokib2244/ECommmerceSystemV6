using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Seeds
{
    internal static class ProductSeed
    {
        public static IList<Product>Products
        {
            get
            {
                return new List<Product>()
                {
                    new Product { Id = new Guid("7537A3C6-B939-4E6F-9530-43AC571F3749"), Name = "Product 1111", Price = 60 },
                    new Product { Id = new Guid("D5401BF6-9671-4456-89F8-10C37DF2E514"), Name = "Product 1112", Price = 50 },
                    new Product { Id = new Guid("E4453FFC-4836-44D1-B17A-2F31C34292CE"), Name = "Product 1113", Price = 70 },
                    new Product { Id = new Guid("6D0D807B-E18E-46B2-B12A-5557B264587A"), Name = "Product 1114", Price = 80 }
            };
            }
        }
    }
}
