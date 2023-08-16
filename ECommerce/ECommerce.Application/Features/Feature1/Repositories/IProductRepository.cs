using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Feature1.Repositories
{
    public interface IProductRepository:IRepositoryBase<Product, Guid>
    {
        Task<(IList<Product> records, int total, int totalDisplay)>
            GetTableDataAsync(Expression<Func<Product, bool>> expression, string orderBy,
            int pageIndex, int pageSize);
        bool IsDuplicateName(string name, Guid? id);
    }
}
