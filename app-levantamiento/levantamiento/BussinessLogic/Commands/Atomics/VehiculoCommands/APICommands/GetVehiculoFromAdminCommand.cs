using levantamiento.BussinesLogic.DTOs;
using levantamiento.DataAccess.APIs;
using levantamiento.DataAccess.DAOs;

namespace levantamiento.BussinesLogic.Commands
{
    public class GetVehiculoFromAdminCommand: Command<VehiculoDTO>
    {
        private VehiculoDTO? _result;
        private readonly Guid _vehiculoId;

        public GetVehiculoFromAdminCommand(Guid vehiculoId)
        {
            _vehiculoId = vehiculoId;
        }

        
        public override void Execute()
        {
            VehiculoAPI dao = DAOFactory.createVehiculoAPI();
            Task.Run(async () =>
            {
                _result = await dao.GetVehiculoFromAdmin(_vehiculoId);
            }).GetAwaiter().GetResult();
            
        }

        public override VehiculoDTO GetResult()
        {
            return _result!;
        }
    }
}