using levantamiento.BussinesLogic.DTOs;
using levantamiento.Exceptions;

namespace levantamiento.BussinesLogic.Commands
{
    public class RegisterRequerimientoLogicCommand: Command<Guid>
    {
        private Guid _result;
        private readonly RequerimientoRegisterDTO _requerimientoDTO;

        /// <summary>
        /// Registra un requerimiento
        /// </summary>
        // <param name="RequerimientoRegisterDTO">Requerimiento a registrar</param>
        /// <returns>Retorna el identificador del requerimiento</returns>
        public RegisterRequerimientoLogicCommand(RequerimientoRegisterDTO requerimientoDTO)
        {
            _requerimientoDTO = requerimientoDTO;
        }

        public override void Execute()
        {
            try
            {
                //Evitar continuar si la solicitud no existe
                GetSolicitudByIdCommand solicitudCommand = SolicitudCommandFactory.createGetSolicitudByIdCommand(_requerimientoDTO.solicitudId);
                solicitudCommand.Execute();
                
                if(solicitudCommand.GetResult() == null)
                    throw new RCVNullException("Error: no se puede registra el requerimiento, la solicitud no existe");

                //Evita seguir con el proceso si no existe la parte indicada
                GetParteByIdCommand parteCommand =  ParteCommandFactory.createGetParteByIdCommand(_requerimientoDTO.parteId);
                parteCommand.Execute();
                
                if(parteCommand.GetResult()  == null)
                    throw new RCVNullException("Error: no se puede registrar el requerimiento, el pieza indicada no existe");
                
                //Verifica si se indicó la cantidad de piesas mayor a cero
                if(_requerimientoDTO.cantidad <= 0)
                    throw new RCVInvalidFieldException("debe de indicar la cantidad de piezas requeridas");

                RegisterRequerimientoCommand RegisterCommand = RequerimientoCommandFactory.createRegisterRequerimientoCommand(_requerimientoDTO);
                RegisterCommand.Execute();
                _result = RegisterCommand.GetResult();
            }
            catch(RCVException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new RCVException("Error: No se logro registrar el requerimiento por algun error desconocido", ex);
            }
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}
