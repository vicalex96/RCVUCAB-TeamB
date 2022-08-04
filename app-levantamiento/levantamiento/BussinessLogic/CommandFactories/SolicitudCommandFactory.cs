using levantamiento.BussinesLogic.DTOs;
using levantamiento.BussinesLogic.Commands;
using levantamiento.DataAccess.Entities;

namespace levantamiento.BussinesLogic.Commands
{
    public class SolicitudCommandFactory
    {
        public static GetSolicitudByIdCommand createGetSolicitudByIdCommand(Guid solicitudId)
        {
            return new GetSolicitudByIdCommand(solicitudId);
        }
        public static GetSolicitudesByIncidenteIdCommand createGetSolicitudesByIncidenteIdCommand(Guid incidenteId)
        {
            return new GetSolicitudesByIncidenteIdCommand(incidenteId);
        }
        public static GetSolicitudesCommand createGetSolicitudesCommand()
        {
            return new GetSolicitudesCommand();
        }
        public static GetSolicitudWithoutTallerCommand createGetSolicitudWithoutTallerCommand()
        {
            return new GetSolicitudWithoutTallerCommand();
        }
        
        public static RegisterSolicitudCommand createRegisterSolicitudCommand(SolicitudRepacionRegisterDTO solicitud)
        {
            return new RegisterSolicitudCommand(solicitud);
        }

        public static AddTallerToSolicitudLogicCommand createAddTallerToSolicitudLogicCommand(Guid IncidenteId
        )
        {
            return new AddTallerToSolicitudLogicCommand(IncidenteId);
        }

        public static RegisterSolicitudLogicCommand createRegisterSolicitudLogicCommand(SolicitudRepacionRegisterDTO solicitud)
        {
            return new RegisterSolicitudLogicCommand(solicitud);
        }
    }
}