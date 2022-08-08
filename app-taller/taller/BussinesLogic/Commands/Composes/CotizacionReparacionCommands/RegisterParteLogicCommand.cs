using taller.BussinesLogic.DTOs;
using taller.Exceptions;

namespace taller.BussinesLogic.Commands
{
    public class RegisterCotizacionRepLogicCommand: Command<Guid>
    {
        private Guid _result;
        private readonly CotizacionRepRegisterDTO _cotizacionDTO;

        /// <summary>
        /// Registra un requerimiento
        /// </summary>
        // <param name="CotizacionRegisterDTO">Requerimiento a registrar</param>
        /// <returns>Retorna el identificador del requerimiento</returns>
        public RegisterCotizacionRepLogicCommand(CotizacionRepRegisterDTO cotizacionDTO)
        {
            _cotizacionDTO = cotizacionDTO;
        }

        public override void Execute()
        {
            try
            {
                //Evitar continuar si la solicitud no existe
                GetCotizacionRepByIdCommand solicitudCommand = CotizacionRepCommandFactory.createGetCotizacionRepByIdCommand(_cotizacionDTO.CotizacionRepId);
                solicitudCommand.Execute();
                
                if(solicitudCommand.GetResult() == null)
                    throw new RCVNullException("Error: no se puede registra el requerimiento, la solicitud no existe");

                //Evita seguir con el proceso si no existe la parte indicada
                GetCotizacionRepByIdCommand parteCommand =  CotizacionRepCommandFactory.createGetCotizacionRepByIdCommand(_cotizacionDTO.CotizacionRepId);
                parteCommand.Execute();
                
                if(parteCommand.GetResult()  == null)
                    throw new RCVNullException("Error: no se puede registrar el requerimiento, el pieza indicada no existe");
                
                //Verifica si se indicó la cantidad de piesas mayor a cero
               // if(_parteDTO.cantidad <= 0)
                 //   throw new RCVInvalidFieldException("debe de indicar la cantidad de piezas requeridas");

                RegisterCotizacionRepCommand RegisterCommand = CotizacionRepCommandFactory.createRegisterCotizacionRepCommand(_cotizacionDTO);
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
