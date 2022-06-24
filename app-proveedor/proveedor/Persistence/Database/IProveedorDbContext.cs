using Microsoft.EntityFrameworkCore;
using proveedor.Persistence.Entities;

namespace proveedor.Persistence.Database
{
    public interface IProveedorDbContext
    {
        DbContext DbContext
        {
            get;
        }



        DbSet<CotizacionParteEntity> CotizacionPartes
        {
            get; set;
        }
    }
}
