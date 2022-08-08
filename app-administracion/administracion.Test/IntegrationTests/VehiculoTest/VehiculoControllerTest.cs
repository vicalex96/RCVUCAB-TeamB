
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
    public class VehiculoControllerTest
    {
        private readonly VehiculoController _controller;
        
        private readonly Mock<ILogger<VehiculoController>> _loggerMock;

        public VehiculoControllerTest()
        {
            _loggerMock = new Mock<ILogger<VehiculoController>>();

            _controller = new VehiculoController(_loggerMock.Object);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact]
        public Task GetVehiculosReturnList()
        {
            List<VehiculoDTO> result = _controller.GetAllVehiculos().Data!;

            Assert.True(result.Any());
            return Task.CompletedTask;
        }

        [Theory]
        [InlineData("0c5c3262-d5ef-46c7-0002-000000000001")]
        public Task GetVehiculoByGuidReturnVehiculoReturnVehiculo(Guid vehiculoId)
        {
            VehiculoDTO result = _controller.GetVehiculoByGuid(vehiculoId).Data!;

            Assert.Equal(vehiculoId, result.Id);
            return Task.CompletedTask;
        }

        [Theory]
        [ClassData(typeof(VehiculoRegisterSeed))]
        public Task RegisterVehiculoReturnGuid(VehiculoRegisterDTO vehiculo)
        {
            Guid result = _controller.registrarVehiculo(vehiculo).Data;

            Assert.NotEqual(Guid.Empty,result);
            return Task.CompletedTask;
        }

        [Theory]
        [ClassData(typeof(VehiculoRegisterExceptionSeed))]
        public Task RegisterVehiculoReturnInternalServerError(VehiculoRegisterDTO vehiculo)
        {
            var result = _controller.registrarVehiculo(vehiculo);
            Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);

            return Task.CompletedTask;
        }

        [Theory]
        [InlineData("0c5c3262-d5ef-46c7-0002-000000000005","0c5c3262-d5ef-46c7-0001-000000000004")]
        public Task AssociateVehiculoWithAseguradoReturnNumber(Guid vehiculoId, Guid AseguradoId)
        {
            int result = _controller.AddAsegurado(vehiculoId, AseguradoId).Data;

            Assert.NotNull(result);
            return Task.CompletedTask;
        }

        [Theory]
        [InlineData("0c5c3262-d5ef-46c7-0002-000000000001","0c5c3262-d5ef-46c7-0001-000000000001")]
        public Task AssociateVehiculoWithAseguradoReturnISErrorAlreadyAsociate(Guid vehiculoId, Guid AseguradoId)
        {
            var result = _controller.AddAsegurado(vehiculoId, AseguradoId);

            Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
            return Task.CompletedTask;
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000","0c5c3262-d5ef-46c7-0001-000000000001")]
        [InlineData("0c5c3262-d5ef-46c7-0002-000000000001","00000000-0000-0000-0000-000000000000")]
        public Task AssociateVehiculoWithAseguradoReturnISErrorNotfound(Guid vehiculoId, Guid AseguradoId)
        {
            var result = _controller.AddAsegurado(vehiculoId, AseguradoId);

            Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
            return Task.CompletedTask;
        }


    }
}
