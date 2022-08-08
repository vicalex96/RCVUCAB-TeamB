using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;

namespace taller.BussinesLogic.Commands
{
    public class GetCotizacionRepCommand: Command<List<CotizacionRepDTO>>
    {
        private List<CotizacionRepDTO>? _result;
        public override void Execute()
        {
            CotizacionRepDAO dao = DAOFactory.createCotizacionRepDAO();
            _result = dao.GetAll();

        }

        public override List<CotizacionRepDTO> GetResult()
        {
            return _result!;
        }
    }
}