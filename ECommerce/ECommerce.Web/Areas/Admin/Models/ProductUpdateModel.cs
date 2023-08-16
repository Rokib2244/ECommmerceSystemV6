using Autofac;
using ECommerce.Application.Features.Feature1.Services;
using ECommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductUpdateModel
    {
        IProductService _productService;
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, Range(0, 500000, ErrorMessage = "Price should be between 0 and 500000")]
        public double Price { get; set; }
        
        public ProductUpdateModel()
        {

        }

        public ProductUpdateModel(IProductService productService)
        {
            _productService = productService;
        }

        public void Load(Guid id)
        {
            Product product = _productService.GetProduct(id);
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
        }
        public void UpdateProduct()
        {
            if (!string.IsNullOrWhiteSpace(Name) && Price > 0)
            {
                _productService.UpdateProduct(Id, Name, Price);
            }
        }
        

        public void ResolveDependency(ILifetimeScope scope)
        {
            _productService = scope.Resolve<IProductService>();
        }
    }
}
