using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.DAOs;
using administracion.DataAccess.Entities;
using administracion.Exceptions;

namespace administracion.BussinesLogic.Commands
{
    public class AddAllMarcasProveedorLogicCommand: Command<Guid>
    {
        private Guid _result;
        private readonly Guid _proveedorId;

        public AddAllMarcasProveedorLogicCommand(Guid proveedorId)
        {
            _proveedorId = proveedorId;
        }
        
        public override void Execute()
        {
            try
            {
                //Borra los posible registros de marcas del proveedor
                DeleteMarcasFromProveedorCommand deleteCommand = ProveedorCommandFactory.createDeleteMarcasFromProveedorCommand(_proveedorId);
                deleteCommand.Execute();

                //convierte los datos ingresados en un objeto MarcaProveedor
                MarcaProveedor marcaProveedor = MarcaFactory.createMarcaProveedorTodasLasMarcas(_proveedorId);
            
                AddMarcaProveedorCommand registerCommand = ProveedorCommandFactory.createAddMarcaProveedorCommand(marcaProveedor);
                registerCommand.Execute();
                _result = registerCommand.GetResult();
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al registrar el incidente", ex);
            }
        }
        
        public override Guid GetResult()
        {
            return _result!;
        }
    }
}