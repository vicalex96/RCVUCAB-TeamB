using administracion.BussinesLogic.DTOs;
using administracion.BussinesLogic.Mappers;
using administracion.DataAccess.DAOs;
using administracion.Exceptions;

namespace administracion.BussinesLogic.Commands
{
    public class RegisterTallerLogicCommand: Command<Guid>
    {
        private Guid _result;
        private readonly TallerRegisterDTO _proveedorDTO;

        public RegisterTallerLogicCommand(TallerRegisterDTO proveedorDTO)
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

                RegisterTallerCommand registerCommand = TallerCommandFactory.createRegisterTallerCommand(_proveedorDTO);
                registerCommand.Execute();
                _result = registerCommand.GetResult();

                //registra el proveedor en el sistema
                SendTallerMQCommand sendCommand = MQCommandFactory.createSendTallerMQCommand(
                    TallerMapper.MapToDTO(_proveedorDTO, _result)
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