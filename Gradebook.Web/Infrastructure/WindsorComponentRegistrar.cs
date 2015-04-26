﻿using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Gradebook.Business.Implemintation;
using Gradebook.Business.Interfaces;
using Gradebook.DAL.EF;

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
            container.Register(Classes.FromThisAssembly()
                            .BasedOn<IController>()
                            .LifestyleTransient());

            container.Register(
                Component.For<IUserService>().ImplementedBy<UserService>().LifestylePerWebRequest(),
                Component.For<Entities>().LifestylePerWebRequest()
                );
        }
    }
}