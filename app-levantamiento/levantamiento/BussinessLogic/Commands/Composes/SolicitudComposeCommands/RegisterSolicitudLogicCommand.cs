using levantamiento.BussinesLogic.DTOs;
using levantamiento.Exceptions;

namespace levantamiento.BussinesLogic.Commands
{
    public class RegisterSolicitudLogicCommand: Command<Guid>
    {
        private Guid _result;
        private readonly SolicitudRepacionRegisterDTO _solicitudRegisterDTO;

        /// <summary>
        /// Revisa la solicitud a ver si cumple con la logica necesaria par poder ser registrado
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns> regresa un bool true si todo salio bien</returns>
        public RegisterSolicitudLogicCommand(SolicitudRepacionRegisterDTO solicitudRegisterDTO)
        {
            _solicitudRegisterDTO = solicitudRegisterDTO;
        }

        public override void Execute()
        {
            try
            {
                //verifica que exista el incidente
                GetIncidenteByIdCommand incidenteCommand = IncidenteCommandFactory.createGetIncidenteByIdCommand(_solicitudRegisterDTO.incidenteId);
                incidenteCommand.Execute();

                if( incidenteCommand.GetResult() == null )
                    throw new RCVNullException("no se encontró ningun incidente asociado con el identificador indicado");

                //verifica que exista el vehiculo
                GetVehiculoFromAdminCommand vehiculoCommand = VehiculoCommandFactory.createGetVehiculoFromAdminCommand(_solicitudRegisterDTO.vehiculoId);
                vehiculoCommand.Execute();

                if( vehiculoCommand.GetResult() == null )
                    throw new RCVNullException("no se encontró ningun vehiculo asociado con el identificador indicado");
                
                //registra la solicitud
                RegisterSolicitudCommand solicitudCommand = SolicitudCommandFactory.createRegisterSolicitudCommand(_solicitudRegisterDTO);
                solicitudCommand.Execute();
                _result = solicitudCommand.GetResult();
            }
            catch (RCVNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new RCVException("Error al ejecutar la logica para el registro de la solicitud", ex);
            }
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}
