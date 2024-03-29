using MockQueryable.Moq;
using Moq;
using taller.DataAcces.Database;
using taller.DataAcces.Entities;
using taller.DataAcces.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace taller.Test.DataSeed
{
    public static class DataSeedEmpresas
    {
        public static void SetupDbContextDataEmpresas(this Mock<ITallerDBContext> _mockContext)
        {
            var requestsTalleres = new List<Taller>
            {
                new Taller
                {
                    Id = new Guid("100001c9-12aa-46bf-82a3-05ff65bb2c86"),
                    nombreLocal = "Taller 1",
                    marcas = new List<MarcaTaller>{

                        new MarcaTaller
                        {
                            Id = new Guid("100001c9-1212-46bf-82a3-05ff65bb2c85"),
                            tallerId = new Guid("100001c9-12aa-46bf-82a3-05ff65bb2c86"),
                            manejaTodas = true,
                        },
                    }
                },
                new Taller
                {
                    Id = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c87"),
                    nombreLocal = "Taller 2",
                    marcas = new List<MarcaTaller>{

                        new MarcaTaller
                        {
                            Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c88"),
                            tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c87"),
                            marcaName = MarcaName.Suzuki
                    
                        },
                        new MarcaTaller
                        {
                            Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c89"),
                            tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c87"),
                            marcaName = MarcaName.Volkswagen
                        },
                        new MarcaTaller
                        {
                            Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c90"),
                            tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c87"),
                            marcaName = MarcaName.General_Motors
                        },
                    }
                },

                new Taller
                {
                    Id = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c89"),
                    nombreLocal = "Taller 3",
                    marcas = new List<MarcaTaller>{

                        new MarcaTaller
                        {
                            Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c88"),
                            tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c89"),
                            marcaName = MarcaName.Suzuki
                        },
                        new MarcaTaller
                        {
                            Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c89"),
                            tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c89"),
                            marcaName = MarcaName.Volkswagen
                        },
                        new MarcaTaller
                        {
                            Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c90"),
                            tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c89"),
                            marcaName = MarcaName.General_Motors
                        },
                    }
                },
                              new Taller
                {
                    Id = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c90"),
                    nombreLocal = "Taller 4",
                    marcas = new List<MarcaTaller>{

                        new MarcaTaller
                        {
                            Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c88"),
                            tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c90"),
                            marcaName = MarcaName.Suzuki
                        },
                        new MarcaTaller
                        {
                            Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c89"),
                            tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c90"),
                            marcaName = MarcaName.Volkswagen
                        },
                        new MarcaTaller
                        {
                            Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c90"),
                            tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c90"),
                            marcaName = MarcaName.General_Motors
                        },
                    }
                },
            };

            var requestsMarcasTaller = new List<MarcaTaller>
            {

                new MarcaTaller
                {
                    Id = new Guid("100001c9-1212-46bf-82a3-05ff65bb2c85"),
                    tallerId = new Guid("100001c9-12aa-46bf-82a3-05ff65bb2c86"),
                    manejaTodas = true,
                },
                new MarcaTaller
                {
                    Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c88"),
                    tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c87"),
                    marcaName= MarcaName.Suzuki
                },
                new MarcaTaller
                {
                    Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c89"),
                    tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c87"),
                    marcaName = MarcaName.Volkswagen
                },
                new MarcaTaller
                {
                    Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c90"),
                    tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c87"),
                    marcaName= MarcaName.General_Motors
                },
                              new MarcaTaller
                {
                    Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c88"),
                    tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c89"),
                    marcaName = MarcaName.Suzuki
                },
                new MarcaTaller
                {
                    Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c89"),
                    tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c89"),
                    marcaName = MarcaName.Volkswagen
                },
                new MarcaTaller
                {
                    Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c90"),
                    tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c89"),
                    marcaName = MarcaName.General_Motors
                },
                              new MarcaTaller
                {
                    Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c88"),
                    tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c90"),
                    marcaName = MarcaName.Suzuki
                },
                new MarcaTaller
                {
                    Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c89"),
                    tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c90"),
                    marcaName = MarcaName.Volkswagen
                },
                new MarcaTaller
                {
                    Id = new Guid("200001c9-1212-46bf-82a3-05ff65bb2c90"),
                    tallerId = new Guid("200001c9-12aa-46bf-82a3-05ff65bb2c90"),
                    marcaName = MarcaName.General_Motors
                },
            };

            _mockContext.Setup(
                c => c.Talleres
                ).Returns(
                    requestsTalleres.AsQueryable().BuildMockDbSet().Object
                    );
            _mockContext.Setup(
                c => c.Marcas
                ).Returns(
                    requestsMarcasTaller.AsQueryable().BuildMockDbSet().Object
            );
        }

    }
}