using Microsoft.AspNetCore.Mvc;
using levantamiento.BussinesLogic.DTOs;
using levantamiento.Exceptions;
using levantamiento.Responses;
using System.ComponentModel.DataAnnotations;
using levantamiento.BussinesLogic.Commands;

namespace levantamiento.Controllers
{
    [ApiController]
    [Route("Solicitud")]
    public class SolicitudController: Controller
    {
        private readonly ILogger<SolicitudController> _logger;

        public SolicitudController(ILogger<SolicitudController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Muestra el listado de todas las solicitudes en el sistema
        /// </summary>
        /// <returns>Solicitudes</returns>
        [HttpGet("mostrar_todos")]
        public ApplicationResponse<List<SolicitudesReparacionDTO>> GetAll()
        {
            var response = new ApplicationResponse<List<SolicitudesReparacionDTO>>();
            try
            {
                GetSolicitudesCommand command = SolicitudCommandFactory.createGetSolicitudesCommand();
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "solicitudes encontradas";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.GetType().ToString();
            }
            return response;
        }

        /// <summary>
        /// Busca las solicitudes que aun no tengan un taller asociado
        /// </summary>
        /// <returns>Solicitudes</returns>
        [HttpGet("mostrar_todos/sin_taller")]
        public ApplicationResponse<List<SolicitudesReparacionDTO>> GetSolicitudesSinTaller()
        {
            var response = new ApplicationResponse<List<SolicitudesReparacionDTO>>();
            try
            {
                GetSolicitudWithoutTallerCommand command = SolicitudCommandFactory.createGetSolicitudWithoutTallerCommand();
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "solicitudes encontradas";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.GetType().ToString();
            }
            return response;
        }

        /// <summary>
        /// Busca una solicitud por su id
        /// </summary>
        /// <param name="SolicitudId">Id de la solicitud</param>
        /// <returns>Solicitud</returns>
        [HttpGet("buscar_por/solicitud/{solicitudId}")]
        public ApplicationResponse<SolicitudesReparacionDTO> GetSolicitud(Guid solicitudId)
        {
            var response = new ApplicationResponse<SolicitudesReparacionDTO>();
            try
            {
                GetSolicitudByIdCommand command = SolicitudCommandFactory.createGetSolicitudByIdCommand(solicitudId);
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "solicitud encontrada";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.GetType().ToString();
            }
            return response;
        }

        /// <summary>
        /// Busca las solicitudes segun el id del incidente
        /// </summary>
        /// <param name="IncidenteId">Id del incidente</param>
        /// <returns>Solicitudes</returns>
        [HttpGet("buscar_por/incidente/{IncidenteId}")]
        public ApplicationResponse<List<SolicitudesReparacionDTO>> GetSolicitudesByIncidente(Guid IncidenteId)
        {
            var response = new ApplicationResponse<List<SolicitudesReparacionDTO>>();
            try
            {
                GetSolicitudesByIncidenteIdCommand command = SolicitudCommandFactory.createGetSolicitudesByIncidenteIdCommand(IncidenteId);
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "solicitudes encontradas";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.GetType().ToString();
            }
            return response;
        }

        /// <summary>
        /// Registrar los datos basicos de un incidente
        /// </summary>
        /// <param name="solicitud">Solicitud</param>
        /// <returns>bool</returns>
        [HttpPost("registrar")]
        public ApplicationResponse<Guid> RegistrarSolicitud([Required][FromBody] SolicitudRepacionRegisterDTO solicitud)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                RegisterSolicitudLogicCommand command = SolicitudCommandFactory.createRegisterSolicitudLogicCommand(solicitud);
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "solicitud registrada";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.GetType().ToString();
            }
            return response;
        }

        ///
        /// <summary>
        /// Asocia un taller a una solicitud y le envia la el registro por cola al taller
        /// </summary>
        /// <param name="solicitud">Solicitud</param>
        /// <returns>bool</returns>
        [HttpPost("asociar_taller/{solicitudId}")]
        public ApplicationResponse<Guid> AsociarTaller([Required][FromRoute]Guid solicitudId)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                AddTallerToSolicitudLogicCommand command = SolicitudCommandFactory.createAddTallerToSolicitudLogicCommand(solicitudId);
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Atencion esta funcion todavia no esta disponible";;
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.GetType().ToString();
            }
            return response;
        }
    }
}