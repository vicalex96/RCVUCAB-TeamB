using MockQueryable.Moq;
using Moq;
using proveedor.Persistence.Database;
using proveedor.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace proveedor.Test.DataSeed
{
    public static class DataSeed
    {
       /* public static void SetupDbContextData(this Mock<IProveedorDbContext> _mockContext)
        {
            var requests = new List<MarcaEntity>
            {
                new MarcaEntity
                {
                    Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                    Name = "Toyota",
                    Country = "Japon",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Providers = new List<ProveedorEntity>
                    {
                        new ProveedorEntity
                        {
                            Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c6"),
                            Nombre = "Provider Name 1",
                           // LastName = "Provider Last Name 1",
                           // Address = "Address",
                           // Phone  = "58666-552-66",
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            Marcas = new List<MarcaEntity>
                            {
                                new MarcaEntity
                                {
                                    Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86")
                                },
                                new MarcaEntity
                                {
                                    Id = new Guid("392b4155-f1d0-4fe0-b4de-4d6a2ef9181d")
                                }
                            }
                        },
                        new ProveedorEntity
                        {
                            Id = new Guid("9f1605fb-5a6a-4779-b289-1f9abfc942b0"),
                            Nombre = "Provider Name 2",
                           // LastName = "Provider Last Name 2",
                           // Address = "Address",
                           // Phone  = "58666-552-66",
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            Marcas = new List<MarcaEntity>
                            {
                                new MarcaEntity
                                {
                                    Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86")
                                }
                            }
                        },
                    }
                },
                new MarcaEntity
                {
                    Id = new Guid("392b4155-f1d0-4fe0-b4de-4d6a2ef9181d"),
                    Name = "Mercedes",
                    Country = "Alemania",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Providers = new List<ProveedorEntity>
                    {
                        new ProveedorEntity
                        {
                            Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c6"),
                            Nombre = "Provider Name 1",
                            //LastName = "Provider Last Name 1",
                           // Address = "Address",
                           // Phone  = "58666-552-66",
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            Marcas = new List<MarcaEntity>
                            {
                                new MarcaEntity
                                {
                                    Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86")
                                },
                                new MarcaEntity
                                {
                                    Id = new Guid("392b4155-f1d0-4fe0-b4de-4d6a2ef9181d")
                                }
                            }
                        }
                    }
                },

            };

            var requestsprovider = requests.SelectMany(q => q.Providers).Concat(new List<ProveedorEntity>
            {
            });

            _mockContext.Setup(c => c.Marcas).Returns(requests.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Providers).Returns(requestsprovider.AsQueryable().BuildMockDbSet().Object);
        }*/
    }
}
