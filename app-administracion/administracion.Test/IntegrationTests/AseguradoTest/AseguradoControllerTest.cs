using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using administracion.BussinesLogic.DTOs;
using administracion.Controllers;
using Xunit;
using administracion.Test.DataSeed;
using System.Net;

namespace administracion.Test.UnitTests.Controllers
{
    public class AseguradoControllerTest
    {
        private readonly AseguradoController _controller;
        private readonly Mock<ILogger<AseguradoController>> _loggerMock;

        public AseguradoControllerTest()
        {
            _loggerMock = new Mock<ILogger<AseguradoController>>();
            _controller = new AseguradoController(_loggerMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact]
        public Task GetAseguradosReturnList()
        {

            List<AseguradoDTO> result = _controller.GetAsegurados().Data!;

            Assert.True(result.Any());
            return Task.CompletedTask;
        }

        [Theory(DisplayName = "Controller: Obtener un asegurado a traves de su guid")]
        [InlineData("0c5c3262-d5ef-46c7-0001-000000000001")]
        public Task GetAseguradoByGuidReturnAsegurado(Guid aseguradoId)
        {
            AseguradoDTO result = _controller.GetAsegurado(aseguradoId).Data!;
            
            Assert.Equal("Luis Jose",result.nombre);
            return Task.CompletedTask;
        }

        [Theory]
        [InlineData("Maria","Salaguchi")]
        public Task GetAseguradosByNameReturnList(string nombre, string apellido)
        {
            List<AseguradoDTO> result = _controller.GetAseguradosPorNombreYApellido(nombre, apellido).Data!;
            
            Assert.True(result.Any());
            return Task.CompletedTask;
        }

        [Theory]
        [ClassData(typeof(AseguradoRegisterData))]
        public Task RegisterAseguradoReturnGuid(AseguradoRegisterDTO asegurado)
        {
            
            Guid result = _controller.AddAsegurado(asegurado).Data;
            Assert.NotEqual(Guid.Empty, result);
            return Task.CompletedTask;
        }

        [Theory]
        [ClassData(typeof(AseguradoRegisterExceptionData))]
        public Task AddAseguradoWithunValidDataReturnInternalServerError(AseguradoRegisterDTO asegurado)
        {
            var result = _controller.AddAsegurado(asegurado);
            
            Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
            return Task.CompletedTask;
        }

    }
}
