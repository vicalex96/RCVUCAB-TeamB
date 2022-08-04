
using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.DAOs.MQ;
using administracion.DataAccess.Enums;

namespace administracion.BussinesLogic.Commands
{
    public class SendIncincenteMQCommand : Command<int>
    {
        private readonly IncidenteDTO _incidente;
        public SendIncincenteMQCommand(IncidenteDTO incidente)
        {
            _incidente = incidente;
        }

        public override void Execute()
        {
            ProviderMQ dao = MQFactory.CreateProviderMQ();
            dao.Producer(_incidente, ExchangeName.Incidente);
        }

        public override int GetResult()
        {
            throw new NotImplementedException();
        }
    }
}