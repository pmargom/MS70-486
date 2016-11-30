using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Book.Web.Startup))]
namespace Book.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
