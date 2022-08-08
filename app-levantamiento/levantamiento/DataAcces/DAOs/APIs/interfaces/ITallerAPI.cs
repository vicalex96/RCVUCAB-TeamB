using levantamiento.DataAccess.Entities;
using levantamiento.BussinesLogic.DTOs;
using levantamiento.Responses;

namespace levantamiento.DataAccess.APIs
{
    public interface ITallerAPI
    {
        public Task<TallerDTO> GetBestTaller(string marca);
    }
}