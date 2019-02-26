using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(new_assignment.Startup))]
namespace new_assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
