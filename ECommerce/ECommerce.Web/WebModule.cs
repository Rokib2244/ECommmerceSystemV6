using Autofac;
using ECommerce.Application;
using ECommerce.Application.Features.Feature1.Repositories;
using ECommerce.Persistence;
using ECommerce.Persistence.Features.Feature1.Repositories;
using ECommerce.Web.Areas.Admin.Models;

namespace ECommerce.Web
{
    public class WebModule:Module
    {
        public WebModule()
        {
        }
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ProductListModel>().AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductCreateModel>().AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductUpdateModel>().AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
