
using administracion.BussinesLogic.DTOs;
using administracion.Exceptions;
using Xunit;
using administracion.Test.DataSeed;
using administracion.BussinesLogic.Commands;

namespace administracion.Test.UnitTests.Controllers
{
    public class AseguradoCommandTest
    {

        [Theory]
        [ClassData(typeof(AseguradoRegisterExceptionData))]
        public Task RegisterAseguradoWithunValidDataReturnException(AseguradoRegisterDTO asegurado)
        {
            RegisterAseguradoCommand command = AseguradoCommandFactory.createRegisterAseguradoCommand(asegurado);
            
            Assert.Throws<RCVInvalidFieldException>(() => command.Execute());
            return Task.CompletedTask;
        }

    }
}
