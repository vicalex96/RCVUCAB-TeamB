using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.DAOs;
using administracion.DataAccess.Entities;
using administracion.DataAccess.Enums;

namespace administracion.BussinesLogic.Commands
{
    public class AddMarcaProveedorCommand: Command<Guid>
    {
        private Guid _result;
        private readonly Guid _proveedorId;
        private readonly MarcaProveedor _marca;

        public AddMarcaProveedorCommand( MarcaProveedor marca)
        {
            _marca = marca;
        }
        
        public override void Execute()
        {
            ProveedorDAO dao = DAOFactory.createProveedorDAO();
            _result = dao.AddMarca( _marca );
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}