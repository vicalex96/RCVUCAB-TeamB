using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;
using taller.DataAcces.Enums;

namespace taller.BussinesLogic.Commands
{
    public class IsMarcaExistsOnTallerCommand: Command<bool>
    {
        private bool _result;
        private readonly Guid _tallerId;
        private readonly MarcaName _marca;

        public IsMarcaExistsOnTallerCommand(Guid tallerId, MarcaName marca)
        {
            _tallerId = tallerId;
            _marca = marca;
        }

        
        public override void Execute()
        {
            TallerDAO Dao = DAOFactory
                .createTallerDAO();
            _result = Dao.IsMarcaExistsOnTaller( _tallerId, _marca );

        }
        
        public override bool GetResult()
        {
            return _result!;
        }
    }
}