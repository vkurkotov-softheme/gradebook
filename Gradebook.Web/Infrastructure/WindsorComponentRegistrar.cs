using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Gradebook.Business.Implemintation;
using Gradebook.Business.Interfaces;

namespace Gradebook.Web.Infrastructure
{
    public class WindsorComponentRegistrar : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterComponents(container);
        }

        private void RegisterComponents(IWindsorContainer container)
        {
            //container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.Register(Component.For<IUserService>().ImplementedBy<UserService>().LifestylePerWebRequest());
        }
    }
}