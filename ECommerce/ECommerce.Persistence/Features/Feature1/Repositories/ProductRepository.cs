using ECommerce.Application.Features.Feature1.Repositories;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Persistence.Features.Feature1.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext context) : base((DbContext)context)
        {

        }
        public bool IsDuplicateName(string name, Guid? id)
        {
            int? existingProductCount = null;

            if (id.HasValue)
                existingProductCount = GetCount(x => x.Name == name && x.Id != id.Value);
            else
                existingProductCount = GetCount(x => x.Name == name);

            return existingProductCount > 0;
        }

        public async Task<(IList<Product> records, int total, int totalDisplay)>
            GetTableDataAsync(Expression<Func<Product, bool>> expression,
            string orderBy, int pageIndex, int pageSize)
        {
            return await GetDynamicAsync(expression, orderBy, null,
                pageIndex, pageSize, true);
        }
    }
}
