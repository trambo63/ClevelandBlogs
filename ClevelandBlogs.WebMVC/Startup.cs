using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClevelandBlogs.WebMVC.Startup))]
namespace ClevelandBlogs.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
