using levantamiento.BussinesLogic.DTOs;
using levantamiento.DataAccess.APIs;
using levantamiento.DataAccess.DAOs;

namespace levantamiento.BussinesLogic.Commands
{
    public class GetTallerForSolicitudCommand: Command<TallerDTO>
    {
        private TallerDTO? _result;
        private readonly string _marca;

        public GetTallerForSolicitudCommand(string marca)
        {
            _marca = marca;
        }

        
        public override void Execute()
        {
            TallerAPI dao = DAOFactory.createTallerAPI();
            Task.Run(async () =>
            {
                _result = await dao.GetBestTaller(_marca);
            }).GetAwaiter().GetResult();

        }

        public override TallerDTO GetResult()
        {
            return _result!;
        }
    }
}