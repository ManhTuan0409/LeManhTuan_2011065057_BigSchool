using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeManhTuan_2011065057_BigSchool.Startup))]
namespace LeManhTuan_2011065057_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
