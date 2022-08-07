
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

namespace administracion.Test.UnitTests.Controllers
{
    public class IncidenteControllerTest
    {
        private readonly IncidenteController _controller;
        private readonly Mock<ILogger<IncidenteController>> _loggerMock;

        public IncidenteControllerTest()
        {
            _loggerMock = new Mock<ILogger<IncidenteController>>();
            _controller = new IncidenteController(_loggerMock.Object);
            
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Theory]
        [ClassData(typeof(IncidenteRegisterData))]
        public Task RegisterIncidenteReturnGuid(IncidenteRegisterDTO incidente)
        {
            Guid result = _controller.RegistrarIncidente(incidente).Data;

            Assert.NotEqual(Guid.Empty,result);
            return Task.CompletedTask;
        }

        [Theory]
        [ClassData(typeof(IncidenteRegisterExceptionData))]
        public Task RegisterIncidenteReturnInternalServerError(IncidenteRegisterDTO incidente)
        {
            var result = _controller.RegistrarIncidente(incidente);
            Assert.Equal(HttpStatusCode.InternalServerError,result.StatusCode);

            return Task.CompletedTask;
        }

        [Theory]
        [InlineData("0c5c3262-d5ef-46c7-0004-000000000001")]
        public Task GetIncidenteByGuidReturnGuid(Guid incidenteId)
        {
            IncidenteDTO result = _controller.consultarIncidentePorId(incidenteId).Data!;
            
            Assert.Equal(incidenteId, result.Id);
            return Task.CompletedTask;
        }

        [Theory]
        [InlineData(EstadoIncidente.Pendiente)]
        [InlineData(EstadoIncidente.Procesando)]
        [InlineData(EstadoIncidente.Cerrado)]
        public Task GetIncidentesByStateReturnList(EstadoIncidente value)
        {
            List<IncidenteDTO> result = _controller.ConsultarIncidentesPorEstado(value).Data!;
            
            Assert.True(result.Any());
            return Task.CompletedTask;
        }

        [Theory(DisplayName = "Controller: Actualizar Estado Incidente")]
        [InlineData("0c5c3262-d5ef-46c7-0004-000000000001",EstadoIncidente.Pendiente)]
        public Task UpdateIncidenteStateReturnGuid(Guid incidenteId, EstadoIncidente state)
        {
            Guid result = _controller.UpdateIncidente(incidenteId,state).Data;
            
            Assert.Equal(incidenteId,result);
            return Task.CompletedTask;
        }

        [Theory(DisplayName = "Controller: Actualizar Estado Incidente")]
        [InlineData("00000000-0000-0000-0000-000000000001",EstadoIncidente.Pendiente)]
        public Task UpdateIncidenteStateReturnServerInternalError(Guid incidenteId, EstadoIncidente state)
        {
            var result = _controller.UpdateIncidente(incidenteId,state);
            
            Assert.Equal(HttpStatusCode.InternalServerError,result.StatusCode);
            return Task.CompletedTask;
        }

    }
}
