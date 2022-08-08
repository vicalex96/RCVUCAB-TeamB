using taller.BussinesLogic.DTOs;
using taller.BussinesLogic.Mappers;
using taller.DataAcces.DAOs;
using taller.Exceptions;

namespace taller.BussinesLogic.Commands
{
    public class RegisterTallerCommand: Command<Guid>
    {
        private Guid _result;
        private readonly TallerRegisterDTO _TallerDTO;

        public RegisterTallerCommand(TallerRegisterDTO TallerDTO)
        {
            _TallerDTO = TallerDTO;
        }

        public override void Execute()
        {
            TallerDAO dao = DAOFactory.createTallerDAO();
            _result = dao.RegisterTaller(
                        TallerMapper.MapToEntity(_TallerDTO)
                    );
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}
