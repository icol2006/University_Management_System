using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using University_Manager.Models;
using Owin;
using System.Security.Claims;

[assembly: OwinStartupAttribute(typeof(University_Manager.Startup))]
namespace University_Manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        { 
            ConfigureAuth(app);
          
        }

    }
}