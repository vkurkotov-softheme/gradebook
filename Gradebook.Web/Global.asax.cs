using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Gradebook.Web.Common.FormsAuthentification;
using Gradebook.Web.Common.GradebookPrincipalService;
using Gradebook.Web.Infrastructure;
using Newtonsoft.Json;

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

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                var serializeModel = JsonConvert.DeserializeObject<GradebookPrincipalSerializeModel>(authTicket.UserData);

                if (serializeModel != null)
                {
                    var newUser = new GradebookPrincipal(authTicket.Name)
                    {
                        Email = serializeModel.Email,
                        CultureName = serializeModel.CultureName,
                        UserTypeCode = serializeModel.UserTypeCode,
                        UserId = serializeModel.UserId
                    };

                    HttpContext.Current.User = newUser;
                }
                else
                {
                    var authenticationService = _container.Resolve<IFormsAuthenticationService>();
                    authenticationService.SignOut();
                }
            }
        }

        private void SetupLocale()
        {
            if (!String.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
            {
                var culture = ((GradebookPrincipal)HttpContext.Current.User).Culture;
                if (culture != null)
                {
                    Thread.CurrentThread.CurrentUICulture = culture;
                    Thread.CurrentThread.CurrentCulture = culture;
                    return;
                }
            }

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
