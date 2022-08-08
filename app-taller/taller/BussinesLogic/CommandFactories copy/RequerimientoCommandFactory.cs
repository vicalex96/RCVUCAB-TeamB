using taller.BussinesLogic.DTOs;
using taller.BussinesLogic.Commands;
using taller.DataAccess.Entities;

namespace taller.BussinesLogic.Commands
{
    public class RequerimientoCommandFactory
    {
        public static GetRequerimientoRepDetailsFromAdminCommand createGetDetailsFromAdminCommand(Guid requerimientoId)
        {
            return new GetRequerimientoRepDetailsFromAdminCommand(requerimientoId);
        }
        public static GetRequerimientoByIdCommand createGetRequerimientoByIdCommand(Guid requerimientoId)
        {
            return new GetRequerimientoByIdCommand(requerimientoId);
        }

        public static GetRequerimientoCommand createGeRequerimientoCommand()
        {
            return new GetRequerimientoCommand();
        }

        public static RegisterRequerimientoCommand createRegisterRequerimientoCommand(RequerimientoRegisterDTO requerimiento)
        {
            return new RegisterRequerimientoCommand(requerimiento);
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
        public static  RegisterRequerimientoCommand createRegisterRequerimientoCommand(RequerimientoRegisterDTO requerimiento)
        {
            return new RegisterRequerimientoCommand(requerimiento);
        }*/

    }
}