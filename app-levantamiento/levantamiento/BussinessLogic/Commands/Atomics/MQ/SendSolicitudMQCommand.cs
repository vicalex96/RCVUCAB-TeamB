
using administracion.DataAccess.Enums;
using levantamiento.BussinesLogic.DTOs;
using levantamiento.DataAccess.DAOs.MQ;
using levantamiento.DataAccess.Enums;

namespace levantamiento.BussinesLogic.Commands
{
    public class SendSolicitudMQCommand : Command<int>
    {
        private readonly SolicitudesReparacionDTO _solcitudDTO;
        public SendSolicitudMQCommand(SolicitudesReparacionDTO solcitudDTO)
        {
            _solcitudDTO = solcitudDTO;
        }

        public override void Execute()
        {
            ProviderMQ dao = MQFactory.CreateProviderMQ();
            dao.Producer(_solcitudDTO, ExchangeName.Solicitud);
        }

        public override int GetResult()
        {
            throw new NotImplementedException();
        }
    }
}