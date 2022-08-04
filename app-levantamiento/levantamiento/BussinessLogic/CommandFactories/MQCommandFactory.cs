using levantamiento.BussinesLogic.DTOs;
using levantamiento.BussinesLogic.Commands;
using levantamiento.DataAccess.Entities;
using levantamiento.DataAccess.Enums;

namespace levantamiento.BussinesLogic.Commands
{
    public class MQCommandFactory
    {
        public static SendSolicitudMQCommand createSendSolicitudMQCommand(SolicitudesReparacionDTO  solicitud)
        {
            return new SendSolicitudMQCommand(solicitud);
        }
        
    }
}