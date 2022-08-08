using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetPartesCommand: Command<ICollection<ParteToShowDTO>>
    {
        private ICollection<ParteToShowDTO>? _result;
        public override void Execute()
        {
            ParteDAO dao = DAOFactory.createParteDAO();
            _result = dao.GetAll();

        }

        public override ICollection<ParteToShowDTO> GetResult()
        {
            return _result!;
        }
    }
}