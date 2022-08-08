using taller.BussinesLogic.DTOs;
using taller.BussinesLogic.Commands;
using taller.DataAcces.Entities;

namespace taller.BussinesLogic.Commands
{
    public class CotizacionRepCommandFactory
    {

       
        public static GetCotizacionRepByIdCommand createGetCotizacionRepByIdCommand(Guid cotizacionId)
        {
            return new GetCotizacionRepByIdCommand(cotizacionId);
        }

        public static GetCotizacionRepCommand createGetCotizacionRepCommand()
        {
            return new GetCotizacionRepCommand();
        }

       

        public static RegisterCotizacionRepCommand createRegisterCotizacionRepCommand(CotizacionRepRegisterDTO cotizacion)
        {
            return new RegisterCotizacionRepCommand(cotizacion);
        }

        public static GetCotizacionRepDetailsLogicCommand createGetDetailedCotizacionRepLogicCommand(Guid cotizacionId)
        {
            return new GetCotizacionRepDetailsLogicCommand(cotizacionId);
        }

    }
}