using ECommerce.Application.Features.Feature1.Repositories;
using ECommerce.Domain.UnitOfWorks;


namespace ECommerce.Application
{
    public interface IApplicationUnitOfWork:IUnitOfWork
    {
        IProductRepository Products { get; }
    }
}
