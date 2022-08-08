using Microsoft.AspNetCore.Mvc;
using levantamiento.BussinesLogic.DTOs;
using levantamiento.Exceptions;
using levantamiento.Responses;
using System.ComponentModel.DataAnnotations;
using levantamiento.BussinesLogic.Commands;

namespace levantamiento.Controllers
{
    [ApiController]
    [Route("Vehiculo")]
    public class VehiculoController: Controller
    {
        private readonly ILogger<VehiculoController> _logger;

        public VehiculoController(ILogger<VehiculoController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("buscar_por/{VehiculoId}")]
        public ApplicationResponse<VehiculoDTO> GetVehiculoById(Guid VehiculoId)
        {
            var response = new ApplicationResponse<VehiculoDTO>();
            try
            {
                GetVehiculoFromAdminCommand command = new GetVehiculoFromAdminCommand(VehiculoId);
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Vehiculo encontrado";
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
            
        [HttpPost("registrar")]
        public ApplicationResponse<Guid> RegisterVehiculo([Required][FromBody] VehiculoRegisterDTO vehiculo)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                RegisterVehiculoCommand command = new RegisterVehiculoCommand(vehiculo);
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Vehiculo registrado";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.GetType().ToString();
            };
            return response;
        }

        
    }
}