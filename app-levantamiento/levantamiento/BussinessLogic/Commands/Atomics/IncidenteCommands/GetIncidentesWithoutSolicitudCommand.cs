using levantamiento.BussinesLogic.DTOs;
using levantamiento.DataAccess.DAOs;

namespace levantamiento.BussinesLogic.Commands
{
    public class GetIncidentesWithoutSolicitudCommand: Command<ICollection<IncidenteToShowDTO>>
    {
        private ICollection<IncidenteToShowDTO>? _result;

        public override void Execute()
        {
            IncidenteDAO dao = DAOFactory.createIncidenteDAO();
            _result = dao.GetAllWithoutSolicitud();

        }

        public override ICollection<IncidenteToShowDTO> GetResult()
        {
            return _result!;
        }
    }
}