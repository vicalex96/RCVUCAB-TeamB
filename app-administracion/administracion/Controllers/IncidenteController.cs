using Microsoft.AspNetCore.Mvc;
using administracion.BussinesLogic.DTOs;
using  administracion.DataAccess.DAOs;
using administracion.Exceptions;
using administracion.Responses;
using System.ComponentModel.DataAnnotations;
using  administracion.DataAccess.Enums;
using administracion.BussinesLogic.Commands;

namespace administracion.Controllers
{
    /// <summary>
    /// Clase que representa el controlador de incidentes,permite mostrar los incidentes, registrarlos y actualizalos
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
        /// Obtiene una lista de incidentes registrados en el sistema
        /// </summary>
        /// <returns>Lista de incidentes</returns>
        [HttpGet("consultar/{incidenteID}")]
        public ApplicationResponse<IncidenteDTO> consultarIncidentePorId([Required][FromRoute] Guid incidenteID)
        {
            var response = new ApplicationResponse<IncidenteDTO>();
            try
            {
                GetIncidenteByIdCommand command = IncidenteCommandFactory
                    .createGetIncidenteByIdCommand(incidenteID);
                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Incidente encontrado";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.GetType().ToString();
            };
            return response;
        }

        /// <summary>
        /// Obtiene una lista de incidentes registrados en el sistema
        /// </summary>
        /// <returns>Lista de incidentes</returns>
        [HttpGet("consultar/estado/{estado}")]
        public ApplicationResponse<List<IncidenteDTO>> ConsultarIncidentesPorEstado([Required][FromRoute] EstadoIncidente estado)
        {
            var response = new ApplicationResponse<List<IncidenteDTO>>();
            try
            {
                GetIncidentesByStateCommand command = IncidenteCommandFactory
                    .createGetIncidentesByStateCommand(estado);

                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Incidente encontrado";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.GetType().ToString();
            };
            return response;
        }

        /// <summary>
        /// Registra un incidente en el sistema
        /// </summary>
        /// <param name="incidenteRegisterDTO">Incidente a registrar</param>
        /// <returns>Incidente registrado</returns>
        [HttpPost("registrar")]
        public ApplicationResponse<Guid> RegistrarIncidente([FromBody] IncidenteRegisterDTO incidente)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                RegisterIncidenteLogicCommand command = IncidenteCommandFactory
                    .createRegisterIncidenteLogicCommand(incidente);
                
                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Incidente registrado";

            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.GetType().ToString();
            };
            return response;
        }

        /// <summary>
        /// Actualiza el estadod el incidente
        /// </summary>
        /// <param name="incidenteId">Incidente a actualizar</param>
        /// <param name="estado">el estado del incidente</param>
        /// <returns>Incidente actualizado</returns>
        [HttpPatch("actualizar/{incidenteID}/{estado}")]
        public ApplicationResponse<Guid> UpdateIncidente([Required][FromRoute] Guid incidenteID, [Required][FromRoute] EstadoIncidente estado)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                UpdateIncidenteLogicCommand command = IncidenteCommandFactory
                    .createUpdateIncidenteLogicCommand(incidenteID, estado);

                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Incidente actualizado";

            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.GetType().ToString();
            };
            return response;
        }
    }
}