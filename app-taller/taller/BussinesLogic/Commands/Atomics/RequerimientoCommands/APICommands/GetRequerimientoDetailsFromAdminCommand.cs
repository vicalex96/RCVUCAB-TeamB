using taller.BussinesLogic.DTOs;
using taller.DataAcces.APIs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetRequerimientoRepDetailsFromAdminCommand: Command<RequerimientoDTO>
    {
        private RequerimientoDTO? _result;
        private readonly Guid _requerimientoId;

        public GetRequerimientoRepDetailsFromAdminCommand(Guid requerimientoId)
        {
            _requerimientoId = requerimientoId;
        }

        
        public override void Execute()
        {
            RequerimientoAPI dao = DAOFactory.createRequerimientoAPI();
            Task.Run(async () =>
            {
                _result = await dao.GetDetailsFromAdmin(_requerimientoId);
            }).GetAwaiter().GetResult();
        }

        public override RequerimientoDTO GetResult()
        {
            return _result!;
        }
    }
}