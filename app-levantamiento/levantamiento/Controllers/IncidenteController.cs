using Microsoft.AspNetCore.Mvc;
using levantamiento.BussinesLogic.DTOs;
using levantamiento.DataAccess.DAOs;
using levantamiento.Exceptions;
using levantamiento.Responses;
using levantamiento.BussinesLogic.Commands;
using System.ComponentModel.DataAnnotations;

namespace levantamiento.Controllers
{
    /// <summary>
    /// Clase que representa el controlador de incidentes, nos da las herramientas para trabajar con el incidente, desde leer la cola de incidentes nuevos hasta mostrar la informacion en detalle
    /// </summary>
    [ApiController]
    [Route("Incidente")]
    public class IncidenteController: Controller
    {
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Trae un listado de incidentes sin solicitudes registradas
        /// </summary>
        /// <returns>Incidentes</returns>
        [HttpGet("mostrar_todos/sin_solicitudes")]
        public ApplicationResponse<ICollection<IncidenteToShowDTO>> GetAllWithoutSolicitud()
        {
            var response = new ApplicationResponse<ICollection<IncidenteToShowDTO>>();
            try
            {
                GetIncidentesWithoutSolicitudCommand command = IncidenteCommandFactory.createGetIncidentesWithoutSolicitudCommand();
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "listado de incidentes";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.GetType().ToString();
            };
            return response;
        }
        
        /// <summary>
        /// Trae un listado de incidentes con solicitudes registradas
        /// </summary>
        /// <returns>Incidentes</returns>
        [HttpGet("mostrar_todos")]
        public ApplicationResponse<ICollection<IncidenteToShowDTO>> GetAll()
        {
            var response = new ApplicationResponse<ICollection<IncidenteToShowDTO>>();
            try
            {
                GetIncidentesCommand command = IncidenteCommandFactory.createGetIncidentesCommand();
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "listado de incidentes";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.GetType().ToString();
            };
            return response;
        }

        ///
        /// <summary>
        /// Trae un listado de incidentes con sus datos en detalle
        /// </summary>
        /// <returns>Incidentes</returns>
        [HttpGet("mostrar_detalle/{incidenteId}")]
        public ApplicationResponse<IncidenteDTO> GetDetaledIncidenteById( [Required] [FromRoute] Guid incidenteId)
        {
            var response = new ApplicationResponse<IncidenteDTO>();
            try
            {
                GetIncidenteDetailsLogicCommand command = IncidenteCommandFactory.createGetDetailedIncidenteLogicCommand(incidenteId);
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Informacion detallada del incidente";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.GetType().ToString();
            }
            return response;
        }
        
    }
}