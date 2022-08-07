using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;
using taller.DataAcces.Entities;
using taller.DataAcces.Enums;

namespace taller.BussinesLogic.Commands
{
    public class AddMarcaTallerCommand: Command<Guid>
    {
        private Guid _result;
        private readonly Guid _proveedorId;
        private readonly MarcaTaller _marca;

        public AddMarcaTallerCommand( MarcaTaller marca)
        {
            _marca = marca;
        }
        
        public override void Execute()
        {
            TallerDAO dao = DAOFactory.createTallerDAO();
            _result = dao.AddMarca( _marca );
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}