using ECommerce.Application.Features.Feature1.Services;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure;
using System.Web;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private readonly IProductService _productService;
       
        public ProductListModel(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Product> GetPopularProducts()
        {
            return _productService.GetProducts();
        }

        public async Task<object> GetPagedProductAsync(DataTablesAjaxRequestUtility dataTableUtility)
        {
            var data = await _productService.GetPagedProductsAsync(
                dataTableUtility.PageIndex,
                dataTableUtility.PageSize,
                dataTableUtility.SearchText,
                dataTableUtility.GetSortText(new string[] { "Name", "Price" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = from record in data.records
                        select new string[]
                        {
                            HttpUtility.HtmlEncode(record.Name),
                            record.Price.ToString(),
                            record.Id.ToString()
                        }
            };
        }

        public void DeleteProduct(Guid id)
        {
            _productService.DeleteProduct(id);
        }

    }
}
