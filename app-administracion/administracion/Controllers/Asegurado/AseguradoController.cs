using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using administracion.BussinesLogic.DTOs;
using administracion.Persistence.DAOs;
using administracion.Exceptions;
using administracion.Responses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace administracion.Controllers
{
    [ApiController]
    [Route("asegurado")]
    public class AseguradoController: Controller
    {
        private readonly IAseguradoDAO _aseguradoDAO;
        private readonly ILogger<AseguradoController> _logger;

        public AseguradoController(ILogger<AseguradoController> logger, IAseguradoDAO providerDAO)
        {
            _aseguradoDAO = providerDAO;
            _logger = logger;
        }

        [HttpGet("asegurados")]
        public ApplicationResponse<List<AseguradoDTO>> GetAsegurados()
        {
            Console.WriteLine("Estoy ejecutando");
            var response = new ApplicationResponse<List<AseguradoDTO>>();
            try
            {

                response.Data = _aseguradoDAO.GetAsegurados();
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        [HttpGet("/{guid}")]
        public ApplicationResponse<AseguradoDTO> GetAsegurado([Required][FromRoute] Guid guid)
        {
            var response = new ApplicationResponse<AseguradoDTO>();
            try
            {
                response.Data = _aseguradoDAO.GetAseguradoByGuid(guid);
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        [HttpGet("asegurados/{nombre}/{apellido}")]
        public ApplicationResponse<List<AseguradoDTO>> GetAseguradosPorNombreYApellido([Required][FromRoute] string nombre, string apellido)
        {
            var response = new ApplicationResponse<List<AseguradoDTO>>();
            try
            {
                response.Data = _aseguradoDAO.GetAseguradosPorNombreCompleto(nombre,apellido);
            }
            catch (RCVException ex)
            {
                Console.WriteLine();
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.Message.ToString();
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return response;
        }

        [HttpPost("add")]
        public ApplicationResponse<string> AddAsegurado([FromBody] AseguradoDTO asegurado)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _aseguradoDAO.createAsegurado(asegurado);
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        [HttpPut("update")]
        public ApplicationResponse<string> UpdateAsegurado([FromBody] AseguradoDTO asegurado)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                
                response.Data = _aseguradoDAO.updateAsegurado(asegurado);
                if(response.Data =="Asegurado editado")
                    response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
    }
}