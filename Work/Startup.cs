using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Work.Startup))]
namespace Work
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
