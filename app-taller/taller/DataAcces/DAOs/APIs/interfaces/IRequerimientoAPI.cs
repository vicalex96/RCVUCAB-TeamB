using taller.DataAccess.Entities;
using taller.BussinesLogic.DTOs;
using taller.Responses;

namespace taller.DataAcces.APIs
{
    public interface IRequerimientoAPI
    {
        public Task<RequerimientoDTO> GetDetailsFromAdmin(Guid RequerimeintoId);
    }
}