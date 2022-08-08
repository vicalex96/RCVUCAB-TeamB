using levantamiento.BussinesLogic.DTOs;
using levantamiento.DataAccess.DAOs;

namespace levantamiento.BussinesLogic.Commands
{
    public class AddTallerToSolicitudCommand: Command<Guid>
    {
        private Guid _result;
        private readonly Guid _solicitudId;
        private readonly Guid _tallerId;

        public AddTallerToSolicitudCommand(Guid solicitudId, Guid tallerId)
        {
            _solicitudId = solicitudId;
            _tallerId = tallerId;
        }

        
        public override void Execute()
        {
            SolicitudReparacionDAO dao = DAOFactory.createSolicitudReparacionDAO();
            _result = dao.AddTallerToSolicitud(_solicitudId, _tallerId);

        }

        public override Guid GetResult()
        {
            return _result;
        }
    }
}