using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RakietaLogikaBiznesowa.Startup))]
namespace RakietaLogikaBiznesowa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
