using levantamiento.BussinesLogic.DTOs;
using levantamiento.BussinesLogic.Commands;
using levantamiento.DataAccess.Entities;

namespace levantamiento.BussinesLogic.Commands
{
    public class ParteCommandFactory
    {
        public static GetParteByIdCommand createGetParteByIdCommand(Guid parteId)
        {
            return new GetParteByIdCommand(parteId);
        }

        public static  GetPartesCommand createGetPartesCommand()
        {
            return new GetPartesCommand();
        }

        public static  RegisterParteCommand createRegisterParteCommand(ParteRegisterDTO parte)
        {
            return new RegisterParteCommand(parte);
        }

    }
}