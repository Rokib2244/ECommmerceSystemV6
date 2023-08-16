using Autofac;

namespace ECommerce.Application
{
    public class ApplicationModule : Module
    {

        public ApplicationModule()
        {
            
        }
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            //builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
            //    .InstancePerLifetimeScope();
        }
    }
}
