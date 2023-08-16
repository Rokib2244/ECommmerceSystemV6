using ECommerce.Application;
using ECommerce.Application.Features.Feature1.Services;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Features.Exceptions;

namespace ECommerce.Infrastructure.Features.Services
{
    public class ProductService:IProductService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public ProductService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Product GetProduct(Guid id)
        {
            Product product = _unitOfWork.Products.GetById(id);
            return product;
        }
        public IList<Product> GetProducts()
        {
            return _unitOfWork.Products.GetAll();
        }

        public async Task<(IList<Product> records, int total, int totalDisplay)> GetPagedProductsAsync(
            int pageIndex, int pageSize, string searchText, string orderBy)
        {
            var result = await _unitOfWork.Products.GetTableDataAsync
                (x => x.Name.Contains(searchText), orderBy, pageIndex, pageSize);

            return result; 
        }

        public void CreateProduct(string name, double price)
        {
            if(_unitOfWork.Products.IsDuplicateName(name, null))
            {
                throw new DuplicateNameException("Product with same name exists. Try with different name.");
            }
            Product product = new Product()
            {
                Name = name,
                Price = price
            };
            _unitOfWork.Products.Add(product);
            _unitOfWork.Save();
        }
        public void UpdateProduct(Guid id,string name, double price)
        {
            if (_unitOfWork.Products.IsDuplicateName(name, id))
            {
                throw new DuplicateNameException("Product with same name exists. Try with different name.");
            }
            Product product = _unitOfWork.Products.GetById(id);
            product.Name = name;
            product.Price = price;
            _unitOfWork.Save();
        }

        public void DeleteProduct(Guid id)
        {
            _unitOfWork.Products.Remove(id);
            _unitOfWork.Save();
        }
    }
}
