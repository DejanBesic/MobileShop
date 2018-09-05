using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Owin;
using System.Text;

[assembly: OwinStartupAttribute(typeof(MobileShop.Startup))]
namespace MobileShop
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
        }
    }
}
