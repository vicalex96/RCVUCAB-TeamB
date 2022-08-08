using taller.BussinesLogic.DTOs;
using taller.DataAcces.APIs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetSolicitudRepDetailsFromAdminCommand: Command<SolicitudesReparacionDTO>
    {
        private SolicitudesReparacionDTO? _result;
        private readonly Guid _solicitudId;

        public GetSolicitudRepDetailsFromAdminCommand(Guid solicitudId)
        {
            _solicitudId = solicitudId;
        }

        
        public override void Execute()
        {
            SolicitudReparacionAPI dao = DAOFactory.createSolcitudReparacionAPI();
            Task.Run(async () =>
            {
                _result = await dao.GetDetailsFromAdmin(_solicitudId);
            }).GetAwaiter().GetResult();
        }

        public override SolicitudesReparacionDTO GetResult()
        {
            return _result!;
        }
    }
}