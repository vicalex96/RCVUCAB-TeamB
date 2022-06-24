using Microsoft.EntityFrameworkCore;
using proveedor.Persistence.Entities;

namespace proveedor.Persistence.Database
{
    public class ProveedorDbContext : DbContext, IProveedorDbContext
    {
        public ProveedorDbContext()
        {
        }

        public ProveedorDbContext(DbContextOptions<ProveedorDbContext> options) : base(options)
        {
        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }


        public virtual DbSet<CotizacionParteEntity> CotizacionPartes    {
            get;
            set;
        }

    }
}