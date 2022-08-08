using taller.BussinesLogic.DTOs;
using taller.BussinesLogic.Commands;
using taller.DataAcces.Entities;

namespace taller.BussinesLogic.Commands
{
    public class SolicitudCommandFactory
    {
        public static GetSolicitudRepDetailsFromAdminCommand createGetDetailsFromAdminCommand(Guid solicitudId)
        {
            return new GetSolicitudRepDetailsFromAdminCommand(solicitudId);
        }
        public static GetSolicitudByIdCommand createGetSolicitudByIdCommand(Guid solicitudId)
        {
            return new GetSolicitudByIdCommand(solicitudId);
        }
        
        public static GetSolicitudesCommand createGetSolicitudesCommand()
        {
            return new GetSolicitudesCommand();
        }

        
        public static RegisterSolicitudCommand createRegisterSolicitudCommand(SolicitudRepacionRegisterDTO solicitud)
        {
            return new RegisterSolicitudCommand(solicitud);
        }


        public static RegisterSolicitudLogicCommand createRegisterSolicitudLogicCommand(Guid solicitudId)
        {
            return new RegisterSolicitudLogicCommand(solicitudId);
        }
    }
}