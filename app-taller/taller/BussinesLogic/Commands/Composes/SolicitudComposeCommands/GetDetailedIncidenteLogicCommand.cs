using taller.BussinesLogic.DTOs;
using taller.Exceptions;

namespace taller.BussinesLogic.Commands
{
    public class RegisterSolicitudLogicCommand: Command<SolicitudesReparacionDTO>
    {
        private SolicitudesReparacionDTO? _result;
        private readonly Guid _SolicitudId;

        /// <summary>
        ///Solicita informacion detalla de un taller
        /// </summary>
        /// <param name="solicitudId">Id del taller</param>
        /// <returns>Regresa un taller con sus solicitudes de reparacion</returns>
        public RegisterSolicitudLogicCommand(Guid SolicitudId)
        {
           _SolicitudId = SolicitudId;
        }

        public override void Execute()
        {
            try
            {
                GetSolicitudRepDetailsFromAdminCommand solicitudCommand = SolicitudCommandFactory.createGetDetailsFromAdminCommand(_SolicitudId);
                solicitudCommand.Execute();
                _result = solicitudCommand.GetResult();

              /*  GetSolicitudesBySIdCommand solicitudCommand = SolicitudCommandFactory.createGetSolicitudesByTallerIdCommand(_TallerId);
                solicitudCommand.Execute();
                _result.solicitudes = solicitudCommand.GetResult();*/
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

        public override SolicitudesReparacionDTO GetResult()
        {
            return _result!;
        }
    }
}