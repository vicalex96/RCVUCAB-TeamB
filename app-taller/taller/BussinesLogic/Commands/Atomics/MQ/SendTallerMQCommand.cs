
using taller.BussinesLogic.DTOs;
using taller.DataAccess.DAOs.MQ;
using taller.DataAcces.Enums;

namespace taller.BussinesLogic.Commands
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