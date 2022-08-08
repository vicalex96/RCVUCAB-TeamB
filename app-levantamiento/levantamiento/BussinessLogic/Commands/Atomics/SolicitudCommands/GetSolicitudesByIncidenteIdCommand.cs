using levantamiento.BussinesLogic.DTOs;
using levantamiento.DataAccess.DAOs;

namespace levantamiento.BussinesLogic.Commands
{
    public class GetSolicitudesByIncidenteIdCommand: Command<List<SolicitudesReparacionDTO>>
    {
        private List<SolicitudesReparacionDTO>? _result;
        private readonly Guid _incidenteId;

        public GetSolicitudesByIncidenteIdCommand(Guid incidenteId)
        {
            _incidenteId = incidenteId;
        }

        
        public override void Execute()
        {
            SolicitudReparacionDAO dao = DAOFactory.createSolicitudReparacionDAO();
            _result = dao.GetSolicitudByIncidenteId(_incidenteId);

        }

        public override List<SolicitudesReparacionDTO> GetResult()
        {
            return _result!;
        }
    }
}