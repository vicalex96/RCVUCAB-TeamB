using taller.BussinesLogic.DTOs;
using taller.BussinesLogic.Mappers;
using taller.DataAcces.DAOs;
using taller.Exceptions;

namespace taller.BussinesLogic.Commands
{
    public class RegisterRequerimientoCommand: Command<Guid>
    {
        private Guid _result;
        private readonly RequerimientoRegisterDTO _requerimientoDTO;

        public RegisterRequerimientoCommand(RequerimientoRegisterDTO requerimientoDTO)
        {
            _requerimientoDTO = requerimientoDTO;
        }

        public override void Execute()
        {
            RequerimientoDAO dao = DAOFactory.createRequerimientoDAO();
            _result = dao.RegisterRequerimiento(
                        
                        RequerimientoMapper.MapToEntity(_requerimientoDTO)
                    );
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}
