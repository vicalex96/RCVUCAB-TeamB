using administracion.BussinesLogic.DTOs;
using administracion.BussinesLogic.Mappers;
using administracion.DataAccess.DAOs;
using administracion.Exceptions;

namespace administracion.BussinesLogic.Commands
{
    public class RegisterTallerCommand: Command<Guid>
    {
        private Guid _result;
        private readonly TallerRegisterDTO _proveedorDTO;

        public RegisterTallerCommand(TallerRegisterDTO proveedorDTO)
        {
            _proveedorDTO = proveedorDTO;
        }
        
        public override void Execute()
        {
            //registra el proveedor en el sistema
            TallerDAO dao = DAOFactory.createTallerDAO();
            _result = dao.RegisterTaller(
                    TallerMapper.MapToEntity(_proveedorDTO)
                );
        }
        
        public override Guid GetResult()
        {
            return _result!;
        }
    }
}