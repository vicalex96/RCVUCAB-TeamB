using levantamiento.DataAccess.Entities;
using levantamiento.BussinesLogic.DTOs;
using levantamiento.Responses;

namespace levantamiento.DataAccess.APIs
{
    public interface IVehiculoAPI
    {
        public Task<Guid> RegisterVehiculo(VehiculoRegisterDTO vehiculo);
        public Task<VehiculoDTO> GetVehiculoFromAdmin(Guid vehiculoId);
    }
}