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
    public static class DataSeedVehiculo
    {
        public static void SetupDbContextData(this Mock<IAdminDBContext> _mockContext)
        {

            var requests = new List<Vehiculo>
                {
                    new Vehiculo
                    {
                        vehiculoId = new Guid("38f401c9-12aa-46bf-82a3-05ff65bb2c86"),
                        anioModelo = 2007,
                        fechaCompra = DateTime.Parse("20/01/2007"),
                        color = Color.Blanco,
                        placa = "AB123CM",
                        marca = Marca.Volkswagen,
                        polizas = new List<Poliza>()
                    },
                    new Vehiculo
                    {
                        vehiculoId = new Guid("38f401c9-12aa-46bf-82a3-05bb34bb2c86"),
                        anioModelo = 2013,
                        fechaCompra = DateTime.Parse("15/05/2015"),
                        color = Color.Plateado,
                        placa = "AB234CM",
                        marca = Marca.Honda,
                        polizas = new List<Poliza>()
                    },
                    new Vehiculo
                    {
                        vehiculoId = new Guid("26f401c9-12aa-46bf-82a3-05bb34bb2c86"),
                        anioModelo = 2019,
                        fechaCompra = DateTime.Parse("03/08/2020"),
                        color = Color.Dorado,
                        placa = "CD231CM",
                        marca = Marca.Ford,
                        polizas = new List<Poliza>()
                    },
                };
            var requestsPoliza = requests.SelectMany(q => q.polizas).Concat(new List<Poliza>
            {
            });

            _mockContext.Setup(
                c => c.Vehiculos
                ).Returns(
                    requests.AsQueryable().BuildMockDbSet().Object
                    );
            _mockContext.Setup(
                c => c.Polizas
                ).Returns(
                    requestsPoliza.AsQueryable().BuildMockDbSet().Object
                    );
        }
        
    }
}