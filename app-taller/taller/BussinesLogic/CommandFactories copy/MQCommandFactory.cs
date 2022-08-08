using taller.BussinesLogic.DTOs;
using taller.BussinesLogic.Commands;
using taller.DataAcces.Entities;
using taller.DataAcces.Enums;

namespace taller.BussinesLogic.Commands
{
    public class MQCommandFactory
    {

        public static SendTallerMQCommand createSendTallerMQCommand(TallerDTO  taller)
        {
            return new SendTallerMQCommand(taller);
        }
        
        public static SendCotizacionRepMQCommand createSendProveedorMQCommand(CotizacionRepDTO  cotizacionRep)
        {
            return new SendCotizacionRepMQCommand(cotizacionRep);
        }
        
    }
}