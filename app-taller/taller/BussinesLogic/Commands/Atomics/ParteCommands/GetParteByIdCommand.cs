using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetParteByIdCommand: Command<ParteDTO>
    {
        private ParteDTO? _result;
        private readonly Guid _parteId;

        public GetParteByIdCommand(Guid parteId)
        {
            _parteId = parteId;
        }

        
        public override void Execute()
        {
            ParteDAO dao = DAOFactory.createParteDAO();
            _result = dao.GetParteByGuid(_parteId);

        }

        public override ParteDTO GetResult()
        {
            return _result!;
        }
    }
}