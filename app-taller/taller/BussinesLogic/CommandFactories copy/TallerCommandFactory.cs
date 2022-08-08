using taller.BussinesLogic.DTOs;
using taller.BussinesLogic.Commands;
using taller.DataAcces.Entities;

namespace taller.BussinesLogic.Commands
{
    public class TallerCommandFactory
    {

        public static GetTallerDetailsFromAdminCommand createGetDetailsFromAdminCommand(Guid tallerId)
        {
            return new GetTallerDetailsFromAdminCommand(tallerId);
        }
        public static GetTallerByIdCommand createGetTallerByIdCommand(Guid tallerId)
        {
            return new GetTallerByIdCommand(tallerId);
        }

        public static GetTallerCommand createGeTallerCommand()
        {
            return new GetTallerCommand();
        }

       

        public static RegisterTallerCommand createRegisterTallerCommand(TallerRegisterDTO taller)
        {
            return new RegisterTallerCommand(taller);
        }

        public static GetTallerDetailsLogicCommand createGetDetailedTallerLogicCommand(Guid TallerId)
        {
            return new GetTallerDetailsLogicCommand(TallerId);
        }

    }
}