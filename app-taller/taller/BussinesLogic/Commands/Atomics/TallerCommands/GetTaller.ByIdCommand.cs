using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetTallerByIdCommand: Command<TallerDTO>
    {
        private TallerDTO? _result;
        private readonly Guid _TallerId;

        public GetTallerByIdCommand(Guid TallerId)
        {
            _TallerId = TallerId;
        }

        
        public override void Execute()
        {
            TallerDAO dao = DAOFactory.createTallerDAO();
            _result = dao.GetTallerByGuid(_TallerId);

        }

        public override TallerDTO GetResult()
        {
            return _result!;
        }
    }
}