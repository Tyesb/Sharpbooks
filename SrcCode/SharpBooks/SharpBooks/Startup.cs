using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharpBooks.Startup))]
namespace SharpBooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
