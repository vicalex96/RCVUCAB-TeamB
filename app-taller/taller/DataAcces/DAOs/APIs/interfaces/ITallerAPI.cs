using taller.DataAccess.Entities;
using taller.BussinesLogic.DTOs;
using taller.Responses;

namespace taller.DataAcces.APIs
{
    public interface ITallerAPI
    {
        public Task<TallerDTO> GetDetailsFromAdmin(Guid tallerId);
    }
}