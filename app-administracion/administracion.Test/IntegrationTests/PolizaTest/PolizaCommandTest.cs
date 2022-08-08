
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using administracion.BussinesLogic.DTOs;
using administracion.Controllers;
using administracion.Exceptions;
using Xunit;
using administracion.Test.DataSeed;
using administracion.BussinesLogic.Commands;

namespace administracion.Test.UnitTests.Controllers
{
    public class PolizaCommandTest
    {
        private readonly PolizaController _controller;
        private readonly Mock<ILogger<PolizaController>> _loggerMock;

        public PolizaCommandTest()
        {
            _loggerMock = new Mock<ILogger<PolizaController>>();
            _controller = new PolizaController(_loggerMock.Object);
            
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }
        [Theory]
        [ClassData(typeof(PolizaRegisterAsociationExceptionSeed))]
        public Task RegistrerPolizaReturnException(PolizaRegisterDTO poliza)
        {
            RegisterPolizaLogicCommand command = PolizaCommandFactory.createRegisterPolizaLogicCommand(poliza);

            Assert.Throws<RCVAsociationException>(() => command.Execute());
            return Task.CompletedTask;
        }

        [Theory]
        [ClassData(typeof(PolizaRegisterDateExceptionSeed))]
        public Task RegistrerPolizaInsetedInvalidDateReturnDateException(PolizaRegisterDTO poliza)
        {
            RegisterPolizaLogicCommand command = PolizaCommandFactory.createRegisterPolizaLogicCommand(poliza);

            Assert.Throws<RCVDateOrderException>(() => command.Execute());
            return Task.CompletedTask;
        }

    }
}
