//using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using administracion.Persistence.DAOs;
using administracion.Persistence.Database;
using administracion.Test.DataSeed;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

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
            _mockLogger = new Mock<ILogger<AseguradoDAO>>();
            
            _dao = new AseguradoDAO(_contextMock.Object);
            _contextMock.SetupDbContextData();
        }

        [Fact]
        public void ValidarConsultaAsegurado()
        {
            //Arrage
            var result = _dao.GetAsegurados();
            //Act
            var isNoEmpty = result.Any();
            //Assert
            Assert.True(isNoEmpty);
        }
    }
    /*    public class AseguradoDAOTests
    {
        private readonly AseguradoDAO _dao;
        private readonly Mock<IAdminDBContext> _contextMock;
        private readonly Mock<ILogger<AseguradoDAO>> _mockLogger;
        public AseguradoDAOTest()
        {
            //var faker = new Faker();
            _contextMock = new Mock<IAdminDBContext>();
            _mockLogger = new Mock<ILogger<AseguradoDAO>>();
            
            _dao = new AseguradoDAO(_contextMock.Object);
            _contextMock.SetupDbContextData();
        }

        [TestMethod]
        public void ShouldReturnAllAseguradosData()
        {
            //var result = _dao.GetAsegurados();
            //var data = result;
            Assert.True(true);
            return Task.CompletedTask;
        }
    }*/
}