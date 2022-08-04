using administracion.BussinesLogic.DTOs;
using administracion.BussinesLogic.Mappers;
using administracion.DataAccess.DAOs;
using administracion.DataAccess.Enums;
using administracion.Exceptions;

namespace administracion.BussinesLogic.Commands
{
    public class RegisterIncidenteLogicCommand: Command<Guid>
    {
        private Guid _result;
        private readonly IncidenteRegisterDTO _incidenteRegisterDTO;

        public RegisterIncidenteLogicCommand(IncidenteRegisterDTO incidenteRegisterDTO)
        {
            _incidenteRegisterDTO = incidenteRegisterDTO;
        }

        
        public override void Execute()
        {
            try
            {
                RegisterIncidenteCommand registerCommand = IncidenteCommandFactory.createRegisterIncidenteCommand(_incidenteRegisterDTO);
                registerCommand.Execute();
                _result = registerCommand.GetResult();

                SendIncincenteMQCommand sendCommand = MQCommandFactory.createSendIncincenteMQCommand(
                    IncidenteMapper.MapToDTO(_incidenteRegisterDTO, _result)
                    );
                sendCommand.Execute();
            }
            catch (Exception e)
            {
                throw new RCVException("Error al registrar el incidente", e);
            }

        }
        
        public override Guid GetResult()
        {
            return _result!;
        }
    }
}