
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using administracion.BussinesLogic.DTOs;
using administracion.Controllers;
using administracion.Exceptions;
using administracion.Responses;
using Xunit;
using administracion.Test.DataSeed;
using System.Net;
using administracion.BussinesLogic.Commands;

namespace administracion.Test.UnitTests.Controllers
{
    public class ProveedorCommandTest
    {
        private readonly ProveedorController _controller;
        private readonly Mock<ILogger<ProveedorController>> _loggerMock;

        public ProveedorCommandTest()
        {
            _loggerMock = new Mock<ILogger<ProveedorController>>();
            _controller = new ProveedorController(_loggerMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }
        [Theory]
        [ClassData(typeof(ProveedorRegisterExceptionSeed))]
        public Task RegisterProveedorReturnRCVInvalidFieldException(ProveedorRegisterDTO proveedor)
        {
            RegisterProveedorLogicCommand command = ProveedorCommandFactory.createRegisterProveedorLogicCommand(proveedor);
            
            Assert.Throws<RCVInvalidFieldException>(() => command.Execute());
            return Task.CompletedTask;
        }

    }
}
