
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using administracion.BussinesLogic.DTOs;
using administracion.Controllers;
using Xunit;
using administracion.DataAccess.Enums;
using administracion.Test.DataSeed;
using System.Net;
using administracion.BussinesLogic.Commands;
using administracion.Exceptions;

namespace administracion.Test.UnitTests.Controllers
{
    public class IncidenteCommandTest
    {
        private readonly IncidenteController _controller;
        private readonly Mock<ILogger<IncidenteController>> _loggerMock;

        public IncidenteCommandTest()
        {
            _loggerMock = new Mock<ILogger<IncidenteController>>();
            _controller = new IncidenteController(_loggerMock.Object);
            
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Theory]
        [ClassData(typeof(IncidenteRegisterExceptionData))]
        public Task RegisterIncidenteReturnException(IncidenteRegisterDTO incidente)
        {
            RegisterIncidenteLogicCommand command = IncidenteCommandFactory.createRegisterIncidenteLogicCommand(incidente);

            Assert.Throws<RCVException>(() => command.Execute());

            return Task.CompletedTask;
        }

        [Theory(DisplayName = "Controller: Actualizar Estado Incidente")]
        [InlineData("00000000-0000-0000-0000-000000000000",EstadoIncidente.Pendiente)]
        public Task UpdateIncidenteStateSendIdNotAsociateReturnException(Guid incidenteId, EstadoIncidente state)
        {
            UpdateIncidenteLogicCommand command = IncidenteCommandFactory.createUpdateIncidenteLogicCommand(incidenteId, state);
            
            Assert.Throws<RCVNullException>(() => command.Execute());
            return Task.CompletedTask;
        }

    }
}
