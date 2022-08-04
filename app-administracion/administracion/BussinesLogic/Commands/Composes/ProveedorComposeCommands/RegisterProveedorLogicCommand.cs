using administracion.BussinesLogic.DTOs;
using administracion.BussinesLogic.Mappers;
using administracion.DataAccess.DAOs;
using administracion.Exceptions;

namespace administracion.BussinesLogic.Commands
{
    public class RegisterProveedorLogicCommand: Command<Guid>
    {
        private Guid _result;
        private readonly ProveedorRegisterDTO _proveedorDTO;

        public RegisterProveedorLogicCommand(ProveedorRegisterDTO proveedorDTO)
        {
            _proveedorDTO = proveedorDTO;
        }
        
        private bool IsNotValidName( string name)
        {
            if(name.ToLower() == "string" || name.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public override void Execute()
        {
            try
            {
                //El nombre del local del proveedor no puede estar vacio
                if(IsNotValidName(_proveedorDTO.nombreLocal))
                {
                    throw new RCVInvalidFieldException("Error: el nombre del local no puede estar vacio o por defecto");
                }

                RegisterProveedorCommand registerCommand = ProveedorCommandFactory.createRegisterProveedorCommand(_proveedorDTO);
                registerCommand.Execute();
                _result = registerCommand.GetResult();

                //registra el proveedor en el sistema
                SendProveedorMQCommand sendCommand = MQCommandFactory.createSendProveedorMQCommand(
                    ProveedorMapper.MapToDTO(_proveedorDTO, _result)
                    );
                sendCommand.Execute();

            }
            catch(RCVInvalidFieldException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new RCVException("Error al registrar el proveedor", ex);
            }
        }
        
        public override Guid GetResult()
        {
            return _result!;
        }
    }
}