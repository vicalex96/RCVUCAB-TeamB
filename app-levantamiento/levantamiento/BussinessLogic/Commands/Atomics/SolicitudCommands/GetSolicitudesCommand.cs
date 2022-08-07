using levantamiento.BussinesLogic.DTOs;
using levantamiento.DataAccess.DAOs;

namespace levantamiento.BussinesLogic.Commands
{
    public class GetSolicitudesCommand: Command<List<SolicitudesReparacionDTO>>
    {
        private List<SolicitudesReparacionDTO>? _result;
        public override void Execute()
        {
            SolicitudReparacionDAO dao = DAOFactory.createSolicitudReparacionDAO();
            _result = dao.GetAll();

        }

        public override List<SolicitudesReparacionDTO> GetResult()
        {
            return _result!;
        }
    }
}