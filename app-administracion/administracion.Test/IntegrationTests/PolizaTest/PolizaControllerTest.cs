
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using administracion.BussinesLogic.DTOs;
using administracion.Controllers;
using System.Net;
using Xunit;
using administracion.Test.DataSeed;

namespace administracion.Test.UnitTests.Controllers
{
    public class PolizaControllerTest
    {
        private readonly PolizaController _controller;
        private readonly Mock<ILogger<PolizaController>> _loggerMock;

        public PolizaControllerTest()
        {
            _loggerMock = new Mock<ILogger<PolizaController>>();
            _controller = new PolizaController(_loggerMock.Object);
            
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Theory]
        [ClassData(typeof(PolizaRegisterSeed))]
        public Task RegistrerPolizaReturnGuid(PolizaRegisterDTO poliza)
        {

            Guid result = _controller.registrarPoliza(poliza).Data;

            Assert.NotEqual(Guid.Empty, result);
            return Task.CompletedTask;
        }
        [Theory]
        [ClassData(typeof(PolizaRegisterAsociationExceptionSeed))]
        public Task RegistrerPolizaInsetedInvalidVehiculoReturnInternalServerError(PolizaRegisterDTO poliza)
        {
            var result = _controller.registrarPoliza(poliza);

            Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
            return Task.CompletedTask;
        }

        [Theory]
        [ClassData(typeof(PolizaRegisterDateExceptionSeed))]
        public Task RegistrerPolizaInsetedInvalidDateReturnInternalServerError(PolizaRegisterDTO poliza)
        {
            var result = _controller.registrarPoliza(poliza);

            Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
            return Task.CompletedTask;
        }

        [Theory]
        [InlineData("0c5c3262-d5ef-46c7-0002-000000000003")]
        public Task GetPolizaByVehiculoID(Guid vehiculoId)
        {
            PolizaDTO result = _controller.ConsultarPolizaPorVehiculoId(vehiculoId).Data!;

            Assert.Equal(vehiculoId,result.vehiculoId);
            return Task.CompletedTask;
        }

    }
}
