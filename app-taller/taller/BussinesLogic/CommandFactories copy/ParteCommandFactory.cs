using taller.BussinesLogic.DTOs;
using taller.BussinesLogic.Commands;
using taller.DataAccess.Entities;

namespace taller.BussinesLogic.Commands
{
    public class ParteCommandFactory
    {
        public static GetParteDetailsFromAdminCommand createGetDetailsFromAdminCommand(Guid parteId)
        {
            return new GetParteDetailsFromAdminCommand(parteId);
        }
        public static GetParteByIdCommand createGetPartetoByIdCommand(Guid parteId)
        {
            return new GetParteByIdCommand(parteId);
        }

        public static GetPartesCommand createGeParteCommand()
        {
            return new GetPartesCommand();
        }

        public static RegisterParteCommand createRegisterParteCommand(ParteRegisterDTO Parte)
        {
            return new RegisterParteCommand(Parte);
        }

       /* public static GetRequerimientoDetailsLogicCommand createGetDetailedRequerimientoLogicCommand(Guid requerimientoId)
        {
            return new GetRequerimientoDetailsLogicCommand(requerimientoId);
        }*/
      /*  public static  RegisterRequerimientoLogicCommand createRegisterRequerimientoLogicCommand(RequerimientoRegisterDTO requerimientoDTO)
        {
            return new RegisterRequerimientoLogicCommand(requerimientoDTO);
        } 

        public static GetRequerimientosBySolicitudIdCommand createGetRequerimientosBySolicitudIdCommand(Guid solicitudId)
        {
            return new GetRequerimientosBySolicitudIdCommand(solicitudId);
        }
        public static  RegisterRequerimientoCommand createRegisterRequerimientoCommand(RequerimientoRegisterDTO Parte)
        {
            return new RegisterRequerimientoCommand(Parte);
        }*/

    }
}