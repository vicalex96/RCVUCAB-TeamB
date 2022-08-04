using Microsoft.AspNetCore.Mvc;
using levantamiento.BussinesLogic.DTOs;
using levantamiento.DataAccess.DAOs;
using levantamiento.Exceptions;
using levantamiento.Responses;
using levantamiento.BussinesLogic.Commands;

namespace levantamiento.Controllers
{
    [ApiController]
    [Route("Requerimiento")]
    public class RequerimientoController: Controller
    {
        private readonly ILogger<RequerimientoController> _logger;

        public RequerimientoController(ILogger<RequerimientoController> logger)
        {
            _logger = logger;       
        }

        ///<summary>
        ///Obtiene todos los requerimientos de la una solicitud
        ///</summary>
        ///<param name="SolicitudId">Solicitud de la cual se desean obtener los requerimientos</param>
        ///<returns>Respuesta con la lista de requerimientos</returns>
        [HttpGet("obtener_por/{SolicitudId}")]
        public ApplicationResponse<List<RequerimientoDTO>> GetRequerimientosBySolicitudId(Guid SolicitudId)
        {
            var response = new ApplicationResponse<List<RequerimientoDTO>>();
            try
            {
                GetRequerimientosBySolicitudIdCommand command = RequerimientoCommandFactory.createGetRequerimientosBySolicitudIdCommand(SolicitudId);
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Requerimientos obtenidos";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = ex.Mensaje;
                response.Success = false;
            }
            return response;
        }

        //[HttpGet("buscar_por/{SolicitudId}")]
        ///<summary>
        ///Registra un requerimiento para la solicitud indicada
        ///</summary>
        ///<param name="RequerimientoDTO">requerimiento que se va a registrar</param>
        ///<returns>Respuesta bool true or false indicando el exito de la operacion</returns>
        [HttpPost("registrar")]
        public ApplicationResponse<Guid> RegisterRequerimiento ([FromBody] RequerimientoRegisterDTO requerimiento)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                RegisterRequerimientoLogicCommand  command = RequerimientoCommandFactory.createRegisterRequerimientoLogicCommand(requerimiento);
                command.Execute();
                
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Requerimiento registrado";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = ex.Mensaje;
                response.Success = false;
            }
            return response;
        }
        
    }
}