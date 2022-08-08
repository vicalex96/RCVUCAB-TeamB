using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetRequerimientoCommand: Command<ICollection<RequerimientoToShowDTO>>
    {
        private ICollection<RequerimientoToShowDTO>? _result;
        public override void Execute()
        {
            RequerimientoDAO dao = DAOFactory.createRequerimientoDAO();
            _result = dao.GetAll();

        }

        public override ICollection<RequerimientoToShowDTO> GetResult()
        {
            return _result!;
        }
    }
}