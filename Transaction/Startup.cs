using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Transaction.Startup))]
namespace Transaction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
