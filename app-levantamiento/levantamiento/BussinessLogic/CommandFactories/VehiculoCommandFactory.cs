using levantamiento.BussinesLogic.DTOs;
using levantamiento.BussinesLogic.Commands;
using levantamiento.DataAccess.Entities;

namespace levantamiento.BussinesLogic.Commands
{
    public class VehiculoCommandFactory
    {
        public static GetVehiculoFromAdminCommand createGetVehiculoFromAdminCommand(Guid vehiculoId)
        {
            return new GetVehiculoFromAdminCommand(vehiculoId);
        }
        public static RegisterVehiculoCommand createRegisterVehiculoCommand(VehiculoRegisterDTO vehiculo)
        {
            return new RegisterVehiculoCommand(vehiculo);
        }
    }
}