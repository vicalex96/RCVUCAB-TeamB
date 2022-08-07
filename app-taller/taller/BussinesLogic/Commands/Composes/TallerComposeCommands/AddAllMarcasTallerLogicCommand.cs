using taller.BussinesLogic.DTOs;
using taller.DataAcces.DAOs;
using taller.DataAcces.Entities;
using taller.Exceptions;

namespace taller.BussinesLogic.Commands
{
    public class AddAllMarcasTallerLogicCommand: Command<Guid>
    {
        private Guid _result;
        private readonly Guid _tallerId;

        public AddAllMarcasTallerLogicCommand(Guid tallerId)
        {
            _tallerId = tallerId;
        }
        
        public override void Execute()
        {
            try
            {
                //Borra los posible registros de marcas del taller
                DeleteMarcasFromTallerCommand deleteCommand = TallerCommandFactory.createDeleteMarcasFromTallerCommand(_tallerId);
                deleteCommand.Execute();

                //convierte los datos ingresados en un objeto MarcaTaller
                MarcaTaller marcaTaller = MarcaFactory.createMarcaTallerTodasLasMarcas(_tallerId);
            
                AddMarcaTallerCommand registerCommand = TallerCommandFactory.createAddMarcaTallerCommand(marcaTaller);
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