using levantamiento.BussinesLogic.DTOs;
using levantamiento.Conections.rabbit;
using levantamiento.Exceptions;

namespace levantamiento.BussinesLogic.Logic
{
    public interface ISolicitudReparacionLogic
    {
        public bool RegisterSolicitud(SolicitudRepacionRegisterDTO solicitud);
        public bool AddTallerToSolicitud(Guid solicitudId);
    }
}