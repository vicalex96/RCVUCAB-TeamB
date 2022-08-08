using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetCotizacionRepByIdCommand: Command<CotizacionRepDTO>
    {
        private CotizacionRepDTO? _result;
        private readonly Guid _cotizacionId;

        public GetCotizacionRepByIdCommand(Guid cotizacionId)
        {
            _cotizacionId = cotizacionId;
        }

        
        public override void Execute()
        {
            CotizacionRepDAO dao = DAOFactory.createCotizacionRepDAO();
            _result = dao.GetCotizacionRepByGuid(_cotizacionId);

        }

        public override CotizacionRepDTO GetResult()
        {
            return _result!;
        }
    }
}