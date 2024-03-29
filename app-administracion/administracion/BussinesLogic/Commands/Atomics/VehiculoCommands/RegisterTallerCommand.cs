using administracion.BussinesLogic.DTOs;
using administracion.BussinesLogic.Mappers;
using administracion.DataAccess.DAOs;
using administracion.Exceptions;

namespace administracion.BussinesLogic.Commands
{
    public class RegisterVehiculoCommand: Command<Guid>
    {
        private Guid _result;
        private readonly VehiculoRegisterDTO _proveedorDTO;

        public RegisterVehiculoCommand(VehiculoRegisterDTO proveedorDTO)
        {
            _proveedorDTO = proveedorDTO;
        }
        
        public override void Execute()
        {
            //registra el proveedor en el sistema
            VehiculoDAO dao = DAOFactory.createVehiculoDAO();
            _result = dao.RegisterVehiculo(
                    VehiculoMapper.MapToEntity(_proveedorDTO)
                );
        }
        
        public override Guid GetResult()
        {
            return _result!;
        }
    }
}