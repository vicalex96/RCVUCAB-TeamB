using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;


namespace taller.BussinesLogic.Commands
{
    public class GetTalleresCommand: Command<List<TallerDTO>>
    {
        private List<TallerDTO>? _result;

        public override void Execute()
        {
            TallerDAO dao = DAOFactory.createTallerDAO();
            _result = dao.GetTalleres();
        }

        public override List<TallerDTO> GetResult()
        {
            return _result!;
        }
    }
}