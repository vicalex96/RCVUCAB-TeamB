
//using administracion.DataAccess.Enums;
using taller.BussinesLogic.DTOs;
using taller.DataAccess.DAOs.MQ;
using taller.DataAcces.Enums;

namespace taller.BussinesLogic.Commands
{
    public class SendTallerMQCommand : Command<int>
    {
        private readonly TallerDTO _TallerDTO;
        public SendTallerMQCommand(TallerDTO TallerDTO)
        {
            _TallerDTO = TallerDTO;
        }

        public override void Execute()
        {
            ProviderMQ dao = MQFactory.CreateProviderMQ();
            dao.Producer(_TallerDTO, ExchangeName.Taller);
        }

        public override int GetResult()
        {
            throw new NotImplementedException();
        }
    }
}