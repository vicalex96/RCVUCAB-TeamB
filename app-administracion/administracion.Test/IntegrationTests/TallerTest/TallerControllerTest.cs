
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
    public class TallerControllerTest
    {
        private readonly TallerController _controller;
        private readonly Mock<ILogger<TallerController>> _loggerMock;

        public TallerControllerTest()
        {
            _loggerMock = new Mock<ILogger<TallerController>>();
            _controller = new TallerController(_loggerMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Theory]
        [ClassData(typeof(TallerRegisterSeed))]
        public Task RegisterTallerReturnGuid(TallerRegisterDTO taller)
        {
            Guid result = _controller.RegistrarTaller(taller).Data;

            Assert.NotEqual(Guid.Empty, result);
            return Task.CompletedTask;
        }

        [Theory]
        [ClassData(typeof(TallerRegisterExceptionSeed))]
        public Task RegisterTallerReturnInternalServerError(TallerRegisterDTO taller)
        {
            var result = _controller.RegistrarTaller(taller);
            
            Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
            return Task.CompletedTask;
        }
        
        [Fact]
        public Task GetTallersReturnList()
        {
            List<TallerDTO> result = _controller.ConsultarTalleres().Data!;

            Assert.True(result.Any());
            return Task.CompletedTask;
        }

        [Theory]
        [InlineData("0c5c3262-d5ef-46c7-0005-000000000002")]
        public Task GetTallerByGuidReturnTaller(Guid tallerId)
        {
            TallerDTO result = _controller.ConsultarTallerPorId(tallerId).Data!;

            Assert.Equal(tallerId, result.Id);
            return Task.CompletedTask;
        } 

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        public Task GetTallerByGuidReturnNull(Guid tallerId)
        {
            var result = _controller.ConsultarTallerPorId(tallerId);

            Assert.Null(result.Data);
            return Task.CompletedTask;
        } 
    }
}
