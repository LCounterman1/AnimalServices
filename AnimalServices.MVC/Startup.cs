using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimalServices.MVC.Startup))]
namespace AnimalServices.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
