using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Feature1.Services
{
    public interface IProductService
    {
        
        IList<Product> GetProducts();
        Product GetProduct(Guid id);
        Task<(IList<Product> records, int total, int totalDisplay)> GetPagedProductsAsync(
           int pageIndex, int pageSize, string searchText, string orderBy);
        void CreateProduct(string name, double price);
        void UpdateProduct(Guid id,string name, double price);
        void DeleteProduct(Guid id);
    }
}
