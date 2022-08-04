using levantamiento.BussinesLogic.DTOs;
using levantamiento.BussinesLogic.Commands;
using levantamiento.DataAccess.Entities;

namespace levantamiento.BussinesLogic.Commands
{
    public class IncidenteCommandFactory
    {

        public static GetIncidenteDetailsFromAdminCommand createGetDetailsFromAdminCommand(Guid incidenteId)
        {
            return new GetIncidenteDetailsFromAdminCommand(incidenteId);
        }
        public static GetIncidenteByIdCommand createGetIncidenteByIdCommand(Guid incidenteId)
        {
            return new GetIncidenteByIdCommand(incidenteId);
        }

        public static GetIncidentesCommand createGetIncidentesCommand()
        {
            return new GetIncidentesCommand();
        }

        public static GetIncidentesWithoutSolicitudCommand createGetIncidentesWithoutSolicitudCommand()
        {
            return new GetIncidentesWithoutSolicitudCommand();
        }

        public static RegisterIncidenteCommand createRegisterIncidenteCommand(IncidenteRegisterDTO incidente)
        {
            return new RegisterIncidenteCommand(incidente);
        }

        public static GetIncidenteDetailsLogicCommand createGetDetailedIncidenteLogicCommand(Guid incidenteId)
        {
            return new GetIncidenteDetailsLogicCommand(incidenteId);
        }

    }
}