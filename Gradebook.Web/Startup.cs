using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gradebook.Web.Startup))]
namespace Gradebook.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
