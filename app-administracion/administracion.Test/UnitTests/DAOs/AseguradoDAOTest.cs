//using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using administracion.Persistence.DAOs;
using administracion.Persistence.Database;
using administracion.BussinesLogic.DTOs;
using administracion.Test.DataSeed;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Collections;

namespace administracion.Test.UnitTests.DAOs
{
    public class AseguradoDAOShould
    {
        private readonly AseguradoDAO _dao;
        private readonly Mock<IAdminDBContext> _contextMock;
        private readonly Mock<ILogger<AseguradoDAO>> _mockLogger;

        public AseguradoDAOShould()
        {
            //var faker = new Faker();
            _contextMock = new Mock<IAdminDBContext>();
            // el Mock no emplea un DBcontext real en IAdminDBContext =>  obligamos una respuesta por defecto para el SaveChanges y de esta forma evitar un error al no tener un DBcontext real
            _contextMock.Setup(m => m.DbContext.SaveChanges()).Returns(0);
            _mockLogger = new Mock<ILogger<AseguradoDAO>>();
            
            _dao = new AseguradoDAO(_contextMock.Object);
            _contextMock.SetupDbContextDataAsegurado();
        }

        public class AseguradoClassData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    new AseguradoSimpleDTO()
                    {
                        Id = new Guid (" 38f401c9-12aa-46bf-82a2-05ff65bb2500"),
                        nombre = "Pablo",
                        apellido = "Marmol",
                    }
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Fact(DisplayName = "DAO: Consulta Asegurados Retorna verdadero")]
        public Task GetAseguradosReturnTrue()
        {
            //Arrage
            var result = _dao.GetAsegurados();
            //Act
            var isNoEmpty = result.Any();
            //Assert
            Assert.True(isNoEmpty);
            return Task.CompletedTask;
        }
        
        [Theory (DisplayName = "DAO: Consultar asegurados por Guid y retornar verdadero")]
        [InlineData("38f401c9-12aa-46bf-82a2-05ff65bb2c86")]
        public Task GetAsegurado_PorID_ReturnTrue( Guid ID)
        {
            //Arrage
            var aseguradoDTO = _dao.GetAseguradoByGuid(ID);
            //Assert
            Assert.Equal(aseguradoDTO.Id,ID);
            return Task.CompletedTask;
        }

        [Theory (DisplayName = "DAO: Consultar Asegurado Por Nombre Y Apellido y retornar verdadero")]
        [InlineData("Juan","Willson")]
        public Task GetAsegurado_PorNombreYApellido_ReturnTrue(string nombre, string apellido)
        {
            //Arrage
            var aseguradoDTO = _dao.GetAseguradosPorNombreCompleto(nombre, apellido);
            //Act
            var isNoEmpty = aseguradoDTO.Any();
            //Assert
            Assert.True(isNoEmpty);
            return Task.CompletedTask;
        }

        [Theory (DisplayName = "DAO: Agregar Asegurado retornar verdadero")]
        [ClassData(typeof(AseguradoClassData))]
        public Task AddAsegurado_ReturnTrue(AseguradoSimpleDTO asegurado)
        {
            var resultado = _dao.createAsegurado(asegurado);

            Assert.Equal("Asegurado creado", resultado);
            return Task.CompletedTask;
        }

        [Theory (DisplayName = "DAO: actualizar Asegurado retornar verdadero")]
        [ClassData(typeof(AseguradoClassData))]
        public Task updateAsegurado_ReturnTrue(AseguradoSimpleDTO asegurado)
        {

            var resultado = _dao.updateAsegurado(asegurado);
            
            Assert.Equal("Asegurado editado", resultado);
            return Task.CompletedTask;
        }

    }
}