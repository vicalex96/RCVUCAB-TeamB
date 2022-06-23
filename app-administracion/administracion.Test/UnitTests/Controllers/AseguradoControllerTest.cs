using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using administracion.BussinesLogic.DTOs;
using administracion.Controllers;
using administracion.Exceptions;
using administracion.Persistence.DAOs;
using administracion.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RCVUcab.Test.UnitTests.Controllers
{
    public class AseguradoControllerTest
    {
        private readonly AseguradoController _controller;
        private readonly Mock<IAseguradoDAO> _serviceMock;
        private readonly Mock<ILogger<AseguradoController>> _loggerMock;

        public AseguradoControllerTest()
        {
            _loggerMock = new Mock<ILogger<AseguradoController>>();
            _serviceMock = new Mock<IAseguradoDAO>();
            _controller = new AseguradoController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact(DisplayName = "Controller: Obtener todos los Asegurados")]
        public Task GetAsegurados()
        {
            _serviceMock
                .Setup(x => x.GetAsegurados())
                .Returns(new List<AseguradoDTO>());
              
            var result = _controller.GetAsegurados();

            Assert.IsType<ApplicationResponse<List<AseguradoDTO>>>(result);
            return Task.CompletedTask;
        }
        [Fact(DisplayName = "Controller: Obtener Excepticion al pedir todos los Asegurados")]
        public Task GetAseguradosException()
        {
            _serviceMock
                .Setup(x => x.GetAsegurados())
                .Throws(new RCVException("",new Exception()));
              
            var ex = _controller.GetAsegurados();
            Assert.NotNull(ex);
            //Assert.False(ex.Success);

            return Task.CompletedTask;
        }
        [Fact(DisplayName = "Controller: Obtener un asegurado a traves de su guid")]
        public Task GetAseguradoByGuid()
        {
            _serviceMock.Setup( x => x.GetAseguradoByGuid(It.IsAny<Guid>()))
            .Returns(new AseguradoDTO());
            var result = _controller.GetAsegurado(It.IsAny<Guid>());
            
            Assert.IsType<ApplicationResponse<AseguradoDTO>>(result);
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Controller: Obtener Excepticion al pedir Asegurado por Guid")]
        public Task GetAseguradoByGuidException()
        {
            _serviceMock
                .Setup(x => x.GetAseguradoByGuid(It.IsAny<Guid>()))
                .Throws(new RCVException("",new Exception()));
              
            var ex = _controller.GetAsegurados();
            Assert.NotNull(ex);
            //Assert.False(ex.Success);

            return Task.CompletedTask;
        }

         [Fact(DisplayName = "Controller: Obtener un asegurados por nombre")]
        public Task GetAseguradosByName()
        {
            _serviceMock.Setup( x => x.GetAseguradosPorNombreCompleto(It.IsAny<string>(),It.IsAny<string>()))
            .Returns(new List<AseguradoDTO>());
            var result = _controller.GetAseguradosPorNombreYApellido(It.IsAny<string>(),It.IsAny<string>());
            
            Assert.IsType<ApplicationResponse<List<AseguradoDTO>>>(result);
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Controller: Obtener Excepticion al pedir Asegurados por nombre")]
        public Task GetAseguradoByNameException()
        {
            _serviceMock
                .Setup(x => x.GetAseguradosPorNombreCompleto(It.IsAny<string>(),It.IsAny<string>()))
                .Throws(new RCVException("",new Exception()));
              
            var ex = _controller.GetAseguradosPorNombreYApellido(It.IsAny<string>(),It.IsAny<string>());
            Assert.NotNull(ex);
            //Assert.False(ex.Success);

            return Task.CompletedTask;
        }
        [Fact(DisplayName = "Controller: Agregar asegurado")]
        public Task CreateAsegurado()
        {
            _serviceMock.Setup( x => x.createAsegurado(It.IsAny<AseguradoSimpleDTO>()))
            .Returns(It.IsAny<string>());
            var result = _controller.AddAsegurado(It.IsAny<AseguradoSimpleDTO>());
            
            Assert.IsType<ApplicationResponse<string>>(result);
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Controller: Agregar asegurado arroja excepcion")]
        public Task CreateAseguradoException()
        {
            _serviceMock
                .Setup(x => x.createAsegurado(It.IsAny<AseguradoSimpleDTO>()))
                .Throws(new RCVException("",new Exception()));
              
            var ex = _controller.AddAsegurado(It.IsAny<AseguradoSimpleDTO>());
            Assert.NotNull(ex);
            //Assert.False(ex.Success);

            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Controller: Actualizar asegurado")]
        public Task UpdateAsegurado()
        {
            _serviceMock
                .Setup(x => x.updateAsegurado(It.IsAny<AseguradoSimpleDTO>()))
                .Returns(It.IsAny<string>());

            var result = _controller.UpdateAsegurado(It.IsAny<AseguradoSimpleDTO>());
            
            Assert.IsType<ApplicationResponse<string>>(result);
           
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Controller: Actualizar Asegurado Arroja excepcion")]
        public Task UpdateAseguradoException()
        {
            _serviceMock
                .Setup(x => x.updateAsegurado(It.IsAny<AseguradoSimpleDTO>()))
                .Throws(new RCVException("",new Exception()));
              
            var ex = _controller.UpdateAsegurado(It.IsAny<AseguradoSimpleDTO>());
            Assert.NotNull(ex);
            //Assert.False(ex.Success);
            return Task.CompletedTask;
        }


    }
}
