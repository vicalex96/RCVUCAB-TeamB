using taller.BussinesLogic.DTOs;
using taller.BussinesLogic.Mappers;
using taller.DataAcces.DAOs;
using taller.Exceptions;

namespace taller.BussinesLogic.Commands
{
    public class RegisterSolicitudCommand: Command<Guid>
    {
        private Guid _result;
        private readonly SolicitudRepacionRegisterDTO _solicitudDTO;

        public RegisterSolicitudCommand(SolicitudRepacionRegisterDTO solicitudDTO)
        {
            _solicitudDTO = solicitudDTO;
        }

        public override void Execute()
        {
            SolcitudReparacionDAO dao = DAOFactory.createSolcitudReparacionDAO();
            _result = dao.RegisterSolicitud(
                        SolicitudReparacionMapper.MapToEntity(_solicitudDTO)
                    );
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}
