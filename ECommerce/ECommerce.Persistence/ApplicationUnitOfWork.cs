using ECommerce.Application;
using ECommerce.Application.Features.Feature1.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence
{
    public class ApplicationUnitOfWork : UnitOfWork,IApplicationUnitOfWork
    {
        public IProductRepository Products { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext, 
            IProductRepository ProductRepository) : base((DbContext)dbContext)
        {
            Products = ProductRepository;
        }

        
    }
}
