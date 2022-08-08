
using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.DAOs.MQ;
using administracion.DataAccess.Enums;

namespace administracion.BussinesLogic.Commands
{
    public class SendTallerMQCommand : Command<int>
    {
        private readonly TallerDTO _tallerDTO;
        public SendTallerMQCommand(TallerDTO tallerDTO)
        {
            _tallerDTO = tallerDTO;
        }

        public override void Execute()
        {
            ProviderMQ dao = MQFactory.CreateProviderMQ();
            dao.Producer(_tallerDTO, ExchangeName.Taller);
        }

        public override int GetResult()
        {
            throw new NotImplementedException();
        }
    }
}