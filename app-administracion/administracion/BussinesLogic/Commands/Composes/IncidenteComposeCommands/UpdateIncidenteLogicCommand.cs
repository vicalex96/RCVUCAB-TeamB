using administracion.BussinesLogic.DTOs;
using administracion.BussinesLogic.Mappers;
using administracion.DataAccess.DAOs;
using administracion.DataAccess.Enums;
using administracion.Exceptions;

namespace administracion.BussinesLogic.Commands
{
    public class UpdateIncidenteLogicCommand: Command<Guid>
    {
        private Guid _result;
        private readonly Guid _incidenteId;
        private readonly EstadoIncidente _state;

        public UpdateIncidenteLogicCommand(Guid incidenteId, EstadoIncidente state)
        {
            _incidenteId = incidenteId;
            _state = state;
        }

        
        public override void Execute()
        {
            try
            {
                GetIncidenteByIdCommand selectCommand = 
                IncidenteCommandFactory.createGetIncidenteByIdCommand(_incidenteId);
                selectCommand.Execute();
                
                IncidenteDTO incidenteDTO = selectCommand.GetResult();
                
                if(incidenteDTO == null)
                    throw new RCVNullException("No existe ningun incidente con el id suministrado");

                incidenteDTO.estadoIncidente = _state.ToString();


                UpdateIncidenteCommand registerCommand = IncidenteCommandFactory.createUpdateIncidenteCommand( incidenteDTO );
                registerCommand.Execute();
                _result =  registerCommand.GetResult();

            }
            catch (RCVNullException ex)
            {
                throw ex;
            }
            catch (RCVUpdateException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw new RCVException("No se pudo actualizar el incidente", ex);
            }
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}