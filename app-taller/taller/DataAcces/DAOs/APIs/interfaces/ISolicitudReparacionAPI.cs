using taller.DataAccess.Entities;
using taller.BussinesLogic.DTOs;
using taller.Responses;

namespace taller.DataAcces.APIs
{
    public interface ISolicitudReparacionAPI
    {
        public Task<SolicitudesReparacionDTO> GetDetailsFromAdmin(Guid solicitudId);
    }
}