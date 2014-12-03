using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using Microsoft.Owin;
using Owin;
using SharpBooks.Migrations;

[assembly: OwinStartupAttribute(typeof(SharpBooks.Startup))]
namespace SharpBooks
{
    public partial class Startup
    {
        public void deployMigrations()
        {

            var configuration = new Configuration();
            configuration.TargetDatabase = new DbConnectionInfo("DefaultConnection");

            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
