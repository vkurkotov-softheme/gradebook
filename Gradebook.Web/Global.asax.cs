using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Gradebook.Web.Infrastructure;

namespace Gradebook.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        public IWindsorContainer Container
        {
            get { return _container; }
        }

        protected void Application_Start()
        {
            BootstrapContainer();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            _container.Dispose();
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var handler = application.Context.Handler;
            if ( handler is MvcHandler)
            {
                SetupLocale();
            }
        }

        private void SetupLocale()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-UA");
        }

        private static void BootstrapContainer()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
