using taller.DataAccess.Entities;
using taller.BussinesLogic.DTOs;
using taller.Responses;

namespace taller.DataAcces.APIs
{
    public interface IParteAPI
    {
        public Task<ParteDTO> GetDetailsFromAdmin(Guid ParteId);
    }
}