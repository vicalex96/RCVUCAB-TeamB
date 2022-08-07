using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;


namespace taller.BussinesLogic.Commands
{
    public class GetTallerByGuidCommand: Command<TallerDTO>
    {
        private TallerDTO? _result;
        private readonly Guid _tallerId;

        public GetTallerByGuidCommand( Guid tallerId)
        {
            _tallerId = tallerId;
        }
        
        public override void Execute()
        {
            TallerDAO dao = DAOFactory.createTallerDAO();
            _result = dao.GetTallerByGuid(_tallerId);
        }

        public override TallerDTO GetResult()
        {
            return _result!;
        }
    }
}