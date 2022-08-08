
using taller.DataAccess.Entities;
using taller.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace taller.DataAcces.DAOs
{
    public interface ISolicitudReparacionDAO
    {
        public List<SolicitudesReparacionDTO> GetAll();
        //public List<SolicitudesReparacionDTO> GetSolicitudWithoutTaller();
        public SolicitudesReparacionDTO GetSolicitudById(Guid solicitudId);
        //public List<SolicitudesReparacionDTO> GetSolicitudByIncidenteId(Guid incidenteId);
        
        //public Guid RegisterSolicitud(SolicitudReparacion solicitud); 
        
    }
}