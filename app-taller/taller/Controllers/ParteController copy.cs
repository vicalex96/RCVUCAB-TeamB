using Microsoft.AspNetCore.Mvc;
using taller.BussinesLogic.DTOs;
using taller.DataAccess.DAOs;
using taller.Exceptions;
using taller.Responses;
using taller.BussinesLogic.Commands;

namespace taller.Controllers
{
    [ApiController]
    [Route("Parte")]
    public class ParteController: Controller
    {
        private readonly ILogger<ParteController> _logger;

        public ParteController(ILogger<ParteController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todas los partes registradas
        /// </summary>
        /// <returns>Lista de partes</returns>
        [HttpGet("mostrar_todos")]
        public ApplicationResponse<ICollection<ParteToShowDTO>> GetAll()
        {
            var response = new ApplicationResponse<ICollection<ParteToShowDTO>>();
            try
            {
                GetPartesCommand command = ParteCommandFactory.createGeParteCommand();
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


        /// <summary>
        ///Registrar una parte nueva en el sistema
        /// </summary>
        /// <param name="Parte">Objeto ParteDTO con los datos de la parte</param>
        /// <returns>Objeto Response con el resultado de la operación</returns>
        [HttpPost("registrar")]
        public ApplicationResponse<Guid> RegisterParte([FromBody] ParteRegisterDTO parte)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                RegisterParteCommand command = ParteCommandFactory.createRegisterParteCommand(parte);
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Parte registrada";
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