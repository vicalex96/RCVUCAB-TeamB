using levantamiento.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace levantamiento.DataAccess.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LevantamientoDBContext>
    {
        public LevantamientoDBContext CreateDbContext(string[]? args)
        {
            AppSettings config = new AppSettings();
            
            var builder = new DbContextOptionsBuilder<LevantamientoDBContext>();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                builder.UseNpgsql(config.DBConnectionString);
            }
            else
            {
                builder.UseNpgsql(config.DBConnectionTestString);
            }
            return new LevantamientoDBContext(builder.Options);
        }
    }
}