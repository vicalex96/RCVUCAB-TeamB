using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;
using taller.DataAcces.Entities;

namespace taller.BussinesLogic.Commands
{
    public class DeleteMarcasFromTallerCommand: Command<int>
    {
        private int _result;
        private readonly Guid _tallerId;

        public DeleteMarcasFromTallerCommand( Guid tallerId)
        {
            _tallerId = tallerId;
        }
        
        public override void Execute()
        {
            TallerDAO dao = DAOFactory.createTallerDAO();
            _result = dao.DeleteMarcasFromTaller(_tallerId);
        }

        public override int  GetResult()
        {
            return _result!;
        }
    }
}