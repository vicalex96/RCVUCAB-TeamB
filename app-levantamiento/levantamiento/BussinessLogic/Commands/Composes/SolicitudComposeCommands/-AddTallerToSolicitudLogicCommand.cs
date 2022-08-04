using levantamiento.Exceptions;

namespace levantamiento.BussinesLogic.Commands
{
    public class AddTallerToSolicitudLogicCommand: Command<Guid>
    {
        private Guid _result;
        private readonly Guid _IncidenteId;

        /// <summary>
        ///Asocia un taller a una solicitud si cumple con los requisitos pedidos, le solicita al Taller que le regrese el mejor taller para la solicitud
        /// </summary>
        /// <param name="IncidenteId"></param>
        /// <returns>regresa el identificador del taller</returns>
        public AddTallerToSolicitudLogicCommand(Guid IncidenteId)
        {
            _IncidenteId = IncidenteId;
        }

        public override void Execute()
        {
            try
            {   
                _result = _IncidenteId;

            }
            catch(RCVException ex)
            {
                throw new RCVException(ex.Mensaje, ex);
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrió un error desconocido", ex);
            }
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}