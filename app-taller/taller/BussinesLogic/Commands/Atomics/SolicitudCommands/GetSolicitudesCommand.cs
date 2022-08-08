using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetSolicitudesCommand: Command<List<SolicitudesReparacionDTO>>
    {
        private List<SolicitudesReparacionDTO>? _result;
        public override void Execute()
        {
            SolcitudReparacionDAO dao = DAOFactory.createSolcitudReparacionDAO();
            _result = dao.GetAll();

        }

        public override List<SolicitudesReparacionDTO> GetResult()
        {
            return _result!;
        }
    }
}