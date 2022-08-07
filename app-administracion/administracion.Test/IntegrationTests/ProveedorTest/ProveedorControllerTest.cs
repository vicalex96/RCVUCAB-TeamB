
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
    public class ProveedorControllerTest
    {
        private readonly ProveedorController _controller;
        private readonly Mock<ILogger<ProveedorController>> _loggerMock;

        public ProveedorControllerTest()
        {
            _loggerMock = new Mock<ILogger<ProveedorController>>();
            _controller = new ProveedorController(_loggerMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Theory]
        [ClassData(typeof(ProveedorRegisterSeed))]
        public Task RegisterProveedorReturnGuid(ProveedorRegisterDTO proveedor)
        {
            Guid result = _controller.RegistrarProveedor(proveedor).Data;

            Assert.NotEqual(Guid.Empty, result);
            return Task.CompletedTask;
        }

        [Theory]
        [ClassData(typeof(ProveedorRegisterExceptionSeed))]
        public Task RegisterProveedorReturnInternalServerError(ProveedorRegisterDTO proveedor)
        {
            var result = _controller.RegistrarProveedor(proveedor);
            
            Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task GetProveedorsReturnList()
        {
            List<ProveedorDTO> result = _controller.ConsultarProveedores().Data!;

            Assert.True(result.Any());
            return Task.CompletedTask;
        }

        [Theory]
        [InlineData("0c5c3262-d5ef-46c7-0006-000000000002")]
        public Task GetProveedorByGuidReturnProveedor(Guid proveedorId)
        {
            ProveedorDTO result = _controller.ConsultarProveedorPorId(proveedorId).Data!;

            Assert.Equal(proveedorId, result.Id);
            return Task.CompletedTask;
        } 

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        public Task GetProveedorByGuidReturnNull(Guid proveedorId)
        {
            var result = _controller.ConsultarProveedorPorId(proveedorId);

            Assert.Null(result.Data);
            return Task.CompletedTask;
        } 
    }
}
