using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCWordDictionary.Startup))]
namespace MVCWordDictionary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
