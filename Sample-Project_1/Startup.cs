using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sample_Project_1.Startup))]
namespace Sample_Project_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
