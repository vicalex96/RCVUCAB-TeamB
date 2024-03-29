using Microsoft.AspNetCore.Mvc;
using taller.Conections.rabbit;
using taller.BussinesLogic.DTOs;
using taller.DataAcces.Entities;
using taller.DataAcces.DAOs;
using taller.BussinesLogic.Commands;
using taller.Responses;
using taller.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace taller.Controllers
{
    /// <summary>
    /// Clase que contiene los endpoints del trabajo con talleres
    /// </summary>
    [ApiController]
    [Route("Taller")]
    public class TallerController : Controller
    {
       // private readonly ITallerDAO _TallerDao;
        private readonly ILogger<TallerController> _logger;

        public TallerController(ILogger<TallerController> logger)
        {
           // _TallerDao = TallerDao;
            _logger = logger;
        }

        /// <summary>
        /// Mostrar un listado de talleres que existen en el sistema
        /// </summary>
        /// <returns>Talleres en sistema</returns>
        [HttpGet("mostrar_todos")]
        public ApplicationResponse<ICollection<TallerToShowDTO>> ConsultarTalleres()
        {
            var response = new ApplicationResponse<ICollection<TallerToShowDTO>>();
            try
            {
                 GetTallerCommand command = TallerCommandFactory.createGeTallerCommand();
                
                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = " talleres encontrados";
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
        /// Busca un taller en el sistema según el Id del taller
        /// </summary>
        /// <param name="tallerId">Id del taller</param>
        /// <returns>Taller</returns>
        [HttpGet("buscar_por/{tallerId}")]
        public ApplicationResponse<TallerDTO> ConsultarTallerPorId([Required][FromRoute] Guid tallerId)
        {
            var response = new ApplicationResponse<TallerDTO>();
            try
            {
                GetTallerByIdCommand command = TallerCommandFactory.createGetTallerByIdCommand(tallerId);

                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = " taller encontrado";
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
        /// Registra un taller en el sistema
        /// </summary>
        /// <param name="tallerRegisterDTO">Taller a registrar</param>
        /// <returns>Taller registrado</returns>
        [HttpPost("registrar")]
        public ApplicationResponse<Guid> RegistrarTaller([FromBody] TallerRegisterDTO taller)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                RegisterTallerCommand command = TallerCommandFactory.createRegisterTallerCommand(taller);

                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = " taller registrado";
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
        
       /* /// <summary>
        /// Actualiza un taller indicado segun su id, se puede agregar una marca o incidar que trabaja con todas
        /// </summary>
        /// <param name="tallerRegisterDTO">taller a actualizar</param>
        /// <returns>taller actualizado</returns>
        [HttpPatch("agregar_marca/{tallerId}/{marca}")]
        public ApplicationResponse<Guid> AgregarMarcaATaller([FromRoute] Guid tallerId, [FromRoute] string marca)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                AddMarcaTallerLogicCommand command = TallerCommandFactory.createAddMarcaTallerLogicCommand(tallerId, marca);

                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = " marca agregada";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Success = false;
                response.Message = ex.Mensaje.ToString();
                response.Exception = ex.GetType().ToString();
            }
            return response;
        }
        
        /// <summary>
        /// Especializa el taller en todas las marcas
        /// </summary>
        /// <param name="tallerId">Id del taller</param>
        /// <returns>Boleano true si todo salio bien</returns>
        [HttpPatch("agrega_marca/todas/{tallerId}")]
        public ApplicationResponse<Guid> AgregarTodasLasMarcasATaller([FromRoute] Guid tallerId)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                AddAllMarcasTallerLogicCommand command = TallerCommandFactory.createAddAllMarcasTallerLogicCommand(tallerId);

                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = " marcas agregadas";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Success = false;
                response.Message = ex.Mensaje.ToString();
                response.Exception = ex.GetType().ToString();
            }
            return response;
        }*/
    }
}
