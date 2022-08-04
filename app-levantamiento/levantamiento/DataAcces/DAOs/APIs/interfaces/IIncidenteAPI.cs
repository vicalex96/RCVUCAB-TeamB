using levantamiento.DataAccess.Entities;
using levantamiento.BussinesLogic.DTOs;
using levantamiento.Responses;

namespace levantamiento.DataAccess.APIs
{
    public interface IIncidenteAPI
    {
        public Task<IncidenteDTO> GetDetailsFromAdmin(Guid incidenteId);
    }
}