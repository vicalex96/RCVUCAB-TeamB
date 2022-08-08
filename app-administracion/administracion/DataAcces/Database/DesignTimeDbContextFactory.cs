using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using administracion.DataAccess.Database;
using administracion.Configurations;

namespace administracion.DataAccess.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AdminDBContext>
    {
        public AdminDBContext CreateDbContext(string[]? args)
        {
            AppSettings config = new AppSettings();
            
            var builder = new DbContextOptionsBuilder<AdminDBContext>();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                builder.UseNpgsql(config.DBConnectionString);
            }
            else
            {
                
                builder.UseNpgsql(config.DBConnectionTestString);
            }

            return new AdminDBContext(builder.Options);
            
        }
    }
}