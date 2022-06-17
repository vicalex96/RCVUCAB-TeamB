using MockQueryable.Moq;
using Moq;
using administracion.Persistence.Database;
using administracion.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace administracion.Test.DataSeed
{
    public static class DataSeedAsegurado
    {
        public static void SetupDbContextData(this Mock<IAdminDBContext> _mockContext)
        {
            /*
            public interface IAdminDBContext
            {
                DbContext DbContext { get;}

                DbSet<Asegurado> Asegurados {get; set;}
                DbSet<Vehiculo> Vehiculos {get; set;}
                DbSet<Poliza> Polizas {get; set;}
                DbSet<Incidente> incidentes {get; set;}
            }
            */

            var requests = new List<Asegurado>
                {
                    new Asegurado
                    {
                        aseguradoId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                        nombre = "Rogelio",
                        apellido = "Zambrano",
                    },
                    new Asegurado
                    {
                        aseguradoId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                        nombre = "Mario",
                        apellido = "Perez",
                    },
                    new Asegurado
                    {
                        aseguradoId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                        nombre = "Juan",
                        apellido = "Willson",
                    }
                };
            _mockContext.Setup(
                c => c.Asegurados
                ).Returns(
                    requests.AsQueryable().BuildMockDbSet().Object
                    );
        }
        
    }
}