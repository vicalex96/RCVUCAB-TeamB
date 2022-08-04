using levantamiento.BussinesLogic.DTOs;
using levantamiento.DataAccess.APIs;
using levantamiento.DataAccess.DAOs;

namespace levantamiento.BussinesLogic.Commands
{
    public class GetIncidenteDetailsFromAdminCommand: Command<IncidenteDTO>
    {
        private IncidenteDTO? _result;
        private readonly Guid _incidenteId;

        public GetIncidenteDetailsFromAdminCommand(Guid incidenteId)
        {
            _incidenteId = incidenteId;
        }

        
        public override void Execute()
        {
            IncidenteAPI dao = DAOFactory.createIncidenteAPI();
            Task.Run(async () =>
            {
                _result = await dao.GetDetailsFromAdmin(_incidenteId);
            }).GetAwaiter().GetResult();
        }

        public override IncidenteDTO GetResult()
        {
            return _result!;
        }
    }
}