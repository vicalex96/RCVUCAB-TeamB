using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetRequerimientoByIdCommand: Command<RequerimientoDTO>
    {
        private RequerimientoDTO? _result;
        private readonly Guid _requerimientoId;

        public GetRequerimientoByIdCommand(Guid requerimientoId)
        {
            _requerimientoId = requerimientoId;
        }

        
        public override void Execute()
        {
            RequerimientoDAO dao = DAOFactory.createRequerimientoDAO();
            _result = dao.GetRequerimientoByGuid(_requerimientoId);

        }

        public override RequerimientoDTO GetResult()
        {
            return _result!;
        }
    }
}