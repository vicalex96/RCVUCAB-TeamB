using taller.BussinesLogic.DTOs;
using taller.DataAcces.APIs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetTallerDetailsFromAdminCommand: Command<TallerDTO>
    {
        private TallerDTO? _result;
        private readonly Guid _tallerId;

        public GetTallerDetailsFromAdminCommand(Guid tallerId)
        {
            _tallerId = tallerId;
        }

        
        public override void Execute()
        {
            TallerAPI dao = DAOFactory.createTallerAPI();
            Task.Run(async () =>
            {
                _result = await dao.GetDetailsFromAdmin(_tallerId);
            }).GetAwaiter().GetResult();
        }

        public override TallerDTO GetResult()
        {
            return _result!;
        }
    }
}