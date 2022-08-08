using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetTallerCommand: Command<ICollection<TallerToShowDTO>>
    {
        private ICollection<TallerToShowDTO>? _result;
        public override void Execute()
        {
            TallerDAO dao = DAOFactory.createTallerDAO();
            _result = dao.GetAll();

        }

        public override ICollection<TallerToShowDTO> GetResult()
        {
            return _result!;
        }
    }
}