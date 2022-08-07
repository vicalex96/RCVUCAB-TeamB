using levantamiento.BussinesLogic.DTOs;
using levantamiento.BussinesLogic.Mappers;
using levantamiento.DataAccess.APIs;
using levantamiento.DataAccess.DAOs;
using levantamiento.Exceptions;

namespace levantamiento.BussinesLogic.Commands
{
    public class RegisterVehiculoCommand: Command<Guid>
    {
        private Guid _result;
        private readonly VehiculoRegisterDTO _vehiculoDTO;

        public RegisterVehiculoCommand(VehiculoRegisterDTO vehiculoDTO)
        {
            _vehiculoDTO = vehiculoDTO;
        }

        public override void Execute()
        {
            VehiculoAPI dao = DAOFactory.createVehiculoAPI();
            Task.Run(async () =>
            {
                _result = await dao.RegisterVehiculo(_vehiculoDTO);
            }).GetAwaiter().GetResult();
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}
