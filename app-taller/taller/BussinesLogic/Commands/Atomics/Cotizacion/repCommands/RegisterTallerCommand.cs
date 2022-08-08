using taller.BussinesLogic.DTOs;
using taller.BussinesLogic.Mappers;
using taller.DataAcces.DAOs;
using taller.Exceptions;

namespace taller.BussinesLogic.Commands
{
    public class RegisterCotizacionRepCommand: Command<Guid>
    {
        private Guid _result;
        private readonly CotizacionRepRegisterDTO _CotizacionRepDTO;

        public RegisterCotizacionRepCommand(CotizacionRepRegisterDTO CotizacionRepDTO)
        {
            _CotizacionRepDTO = CotizacionRepDTO;
        }

        public override void Execute()
        {
            CotizacionRepDAO dao = DAOFactory.createCotizacionRepDAO();
            _result = dao.RegisterCotizacionReparacion(
                        CotizacionReparacionMapper.MapToEntity(_CotizacionRepDTO)
                    );
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}
