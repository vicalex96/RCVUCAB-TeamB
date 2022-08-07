
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
    public class TallerCommandTest
    {
        private readonly TallerController _controller;
        private readonly Mock<ILogger<TallerController>> _loggerMock;

        public TallerCommandTest()
        {
            _loggerMock = new Mock<ILogger<TallerController>>();
            _controller = new TallerController(_loggerMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }
        [Theory]
        [ClassData(typeof(TallerRegisterExceptionSeed))]
        public Task RegisterTallerReturnRCVInvalidFieldException(TallerRegisterDTO taller)
        {
            RegisterTallerLogicCommand command = TallerCommandFactory.createRegisterTallerLogicCommand(taller);
            
            Assert.Throws<RCVInvalidFieldException>(() => command.Execute());
            return Task.CompletedTask;
        }

    }
}
