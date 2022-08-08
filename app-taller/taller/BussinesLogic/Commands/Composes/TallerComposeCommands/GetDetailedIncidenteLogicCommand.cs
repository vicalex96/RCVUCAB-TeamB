using taller.BussinesLogic.DTOs;
using taller.Exceptions;

namespace taller.BussinesLogic.Commands
{
    public class GetTallerDetailsLogicCommand: Command<TallerDTO>
    {
        private TallerDTO? _result;
        private readonly Guid _TallerId;

        /// <summary>
        ///Solicita informacion detalla de un taller
        /// </summary>
        /// <param name="tallerId">Id del taller</param>
        /// <returns>Regresa un taller con sus solicitudes de reparacion</returns>
        public GetTallerDetailsLogicCommand(Guid TallerId)
        {
            _TallerId = TallerId;
        }

        public override void Execute()
        {
            try
            {
                GetTallerDetailsFromAdminCommand tallerCommand = TallerCommandFactory.createGetDetailsFromAdminCommand(_TallerId);
                tallerCommand.Execute();
                _result = tallerCommand.GetResult();

              /*  GetSolicitudesByTallerIdCommand solicitudCommand = SolicitudCommandFactory.createGetSolicitudesByTallerIdCommand(_TallerId);
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

        public override TallerDTO GetResult()
        {
            return _result!;
        }
    }
}