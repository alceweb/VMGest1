using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VMGest1.Startup))]
namespace VMGest1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
