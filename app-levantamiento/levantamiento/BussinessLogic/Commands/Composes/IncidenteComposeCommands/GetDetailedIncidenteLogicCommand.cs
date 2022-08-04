using levantamiento.BussinesLogic.DTOs;
using levantamiento.Exceptions;

namespace levantamiento.BussinesLogic.Commands
{
    public class GetIncidenteDetailsLogicCommand: Command<IncidenteDTO>
    {
        private IncidenteDTO? _result;
        private readonly Guid _IncidenteId;

        /// <summary>
        ///Solicita informacion detalla de un incidente
        /// </summary>
        /// <param name="incidenteId">Id del incidente</param>
        /// <returns>Regresa un incidente con sus solicitudes de reparacion</returns>
        public GetIncidenteDetailsLogicCommand(Guid IncidenteId)
        {
            _IncidenteId = IncidenteId;
        }

        public override void Execute()
        {
            try
            {
                GetIncidenteDetailsFromAdminCommand incidenteCommand = IncidenteCommandFactory.createGetDetailsFromAdminCommand(_IncidenteId);
                incidenteCommand.Execute();
                _result = incidenteCommand.GetResult();

                GetSolicitudesByIncidenteIdCommand solicitudCommand = SolicitudCommandFactory.createGetSolicitudesByIncidenteIdCommand(_IncidenteId);
                solicitudCommand.Execute();
                _result.solicitudes = solicitudCommand.GetResult();
            }
            catch(RCVException ex)
            {
                throw new RCVException(ex.Mensaje, ex);
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrió un error desconocido", ex);
            }
        }

        public override IncidenteDTO GetResult()
        {
            return _result!;
        }
    }
}