using levantamiento.BussinesLogic.DTOs;
using levantamiento.BussinesLogic.Commands;
using levantamiento.DataAccess.Entities;

namespace levantamiento.BussinesLogic.Commands
{
    public class RequerimientoCommandFactory
    {

        public static  RegisterRequerimientoLogicCommand createRegisterRequerimientoLogicCommand(RequerimientoRegisterDTO requerimientoDTO)
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
        }

    }
}