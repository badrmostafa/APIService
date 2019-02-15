using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookConsumer.Startup))]
namespace BookConsumer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
