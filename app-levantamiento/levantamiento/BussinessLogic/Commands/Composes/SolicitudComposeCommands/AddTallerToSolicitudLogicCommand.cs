using levantamiento.BussinesLogic.DTOs;
using levantamiento.Exceptions;

namespace levantamiento.BussinesLogic.Commands
{
    public class AddTallerToSolicitudLogicCommand: Command<Guid>
    {
        private Guid _result;
        private readonly Guid _solicitudId;

        /// <summary>
        ///Asocia un taller a una solicitud si cumple con los requisitos pedidos, le solicita al Taller que le regrese el mejor taller para la solicitud
        /// </summary>
        /// <param name="solicitudId"> el identificador de la solicitud</param>
        /// <returns>regresa el ID del taller</returns>
        public AddTallerToSolicitudLogicCommand(Guid solicitudId)
        {
            _solicitudId = solicitudId;
        }

        public override void Execute()
        {
            try
            {   
                // busca la solicitud para conseguir el vehiculo
                GetSolicitudByIdCommand solicitudCommand = SolicitudCommandFactory.createGetSolicitudByIdCommand(_solicitudId);
                solicitudCommand.Execute();
                SolicitudesReparacionDTO solicitudTemp = solicitudCommand.GetResult();

                if(solicitudTemp == null)
                {
                    throw new RCVNullException("No se encontro la solicitud");
                }

                // busca la informacion del vehiculo solicitada al admin
                GetVehiculoFromAdminCommand vehiculoCommand = VehiculoCommandFactory.createGetVehiculoFromAdminCommand(solicitudTemp.vehiculoId);
                vehiculoCommand.Execute();
                VehiculoDTO vehiculoTemp = vehiculoCommand.GetResult();

                if(vehiculoTemp == null)
                {
                    throw new RCVNullException("No se encontro el vehiculo");
                }

                //usa la marca del vehiculo para conseguir el mejor Taller
                GetTallerForSolicitudCommand command = SolicitudCommandFactory.createGetTallerForSolicitudCommand(vehiculoTemp.marca);
                command.Execute();
                TallerDTO tallerTemp = command.GetResult();

                if(tallerTemp == null)
                {
                    throw new RCVNullException("No se encontro el taller");
                }
                
                //asocia el taller a la solicitud
                AddTallerToSolicitudCommand addTallerCommand = SolicitudCommandFactory.createAddTallerToSolicitudCommand(_solicitudId, tallerTemp.Id);
                addTallerCommand.Execute();
                _result = addTallerCommand.GetResult();

                //registra la solicitud de reparacion en el sistema de Taller
                solicitudTemp.tallerId = _result;
                SendSolicitudMQCommand sendCommand = MQCommandFactory.createSendSolicitudMQCommand(solicitudTemp);
                sendCommand.Execute();

            }
            catch(RCVNullException ex)
            {
                throw ex;
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