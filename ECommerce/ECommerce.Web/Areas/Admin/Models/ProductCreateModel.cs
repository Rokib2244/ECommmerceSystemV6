using Autofac;
using ECommerce.Application.Features.Feature1.Services;
using ECommerce.Infrastructure.Features.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductCreateModel
    {
        IProductService _productService;
        public ProductCreateModel()
        {

        }

        public ProductCreateModel(IProductService productService)
        {
            _productService = productService;
        }
        [Required]
        public string Name { get; set; }
        [Required , Range(0,500000, ErrorMessage ="Price should be between 0 and 500000")]
        public double Price { get; set; }

        public void CreateProduct()
        {
            if(!string.IsNullOrWhiteSpace(Name) && Price > 0)
            {
                _productService.CreateProduct(Name, Price);
            }
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _productService= scope.Resolve<IProductService>();
        }
    }
}
