
//using administracion.DataAccess.Enums;
using taller.BussinesLogic.DTOs;
using taller.DataAccess.DAOs.MQ;
using taller.DataAcces.Enums;

namespace taller.BussinesLogic.Commands
{
    public class SendCotizacionRepMQCommand : Command<int>
    {
        private readonly CotizacionRepDTO _CotizacionRepDTO;
        public SendCotizacionRepMQCommand(CotizacionRepDTO CotizacionRepDTO)
        {
            _CotizacionRepDTO = CotizacionRepDTO;
        }

        public override void Execute()
        {
            ProviderMQ dao = MQFactory.CreateProviderMQ();
            dao.Producer(_CotizacionRepDTO, ExchangeName.CotizacionReparacion);
        }

        public override int GetResult()
        {
            throw new NotImplementedException();
        }
    }
}