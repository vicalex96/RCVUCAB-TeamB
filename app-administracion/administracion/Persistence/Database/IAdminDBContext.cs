using Microsoft.EntityFrameworkCore;
using administracion.Persistence.Entities;
namespace administracion.Persistence.Database
{
    public interface IAdminDBContext
    {
         DbContext DbContext { get;}

         DbSet<Asegurado> Asegurados {get; set;}
         DbSet<Vehiculo> Vehiculos {get; set;}
         DbSet<Poliza> Polizas {get; set;}
         DbSet<Incidente> incidentes {get; set;}
    }
}