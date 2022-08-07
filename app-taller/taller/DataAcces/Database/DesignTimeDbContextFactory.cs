using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using taller.DataAcces.Database;


namespace taller.DataAcces.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TallerDBContext>
    {
        public TallerDBContext CreateDbContext(string[]? args)
        {
            var builder = new DbContextOptionsBuilder<TallerDBContext>();
            var connectionString = "Server=localhost;Database=Taller;Port=5432;User Id=postgres;Password=postgres";
            builder.UseNpgsql(connectionString);
            return new TallerDBContext(builder.Options);
        }
    }
}