using taller.BussinesLogic.DTOs;
using taller.DataAcces.APIs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetParteDetailsFromAdminCommand: Command<ParteDTO>
    {
        private ParteDTO? _result;
        private readonly Guid _parteId;

        public GetParteDetailsFromAdminCommand(Guid parteId)
        {
            _parteId = parteId;
        }

        
        public override void Execute()
        {
            ParteAPI dao = DAOFactory.createParteAPI();
            Task.Run(async () =>
            {
                _result = await dao.GetDetailsFromAdmin(_parteId);
            }).GetAwaiter().GetResult();
        }

        public override ParteDTO GetResult()
        {
            return _result!;
        }
    }
}