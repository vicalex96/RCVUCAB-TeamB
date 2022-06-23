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
    [Route("vehiculo")]
    public class VehiculoController: Controller
    {
        private readonly IVehiculoDAO _vehiculoDao;
        private readonly ILogger<VehiculoController> _logger;

        public VehiculoController(ILogger<VehiculoController> logger, IVehiculoDAO vehiculoDao)
        {
            _vehiculoDao = vehiculoDao;
            _logger = logger;
        }
        [HttpGet("mostrar_todos")]
        public ApplicationResponse<List<VehiculoDTO>> GetAllVehiculos()
        {
            var response = new ApplicationResponse<List<VehiculoDTO>>();
            try
            {
                response.Data = _vehiculoDao.GetAllVehiculos();
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpGet("buscar_por/{guid}")]
        public ApplicationResponse<VehiculoDTO> GetVehiculoByGuid([Required][FromRoute] Guid guid)
        {
            var response = new ApplicationResponse<VehiculoDTO>();
            try
            {
                response.Data = _vehiculoDao.GetVehiculoByGuid(guid);
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }

        [HttpPost("crear")]
        public ApplicationResponse<string> createVehiculo([FromBody] VehiculoSimpleDTO Vehiculo)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _vehiculoDao.createVehiculo(Vehiculo);
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPost("asociar_asegurado/{vehiculoId}/{aseguradoId}")]
        public ApplicationResponse<string> AddAsegurado([Required][FromRoute] Guid vehiculoId ,[Required][FromRoute] Guid aseguradoId)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _vehiculoDao.addAsegurado(vehiculoId, aseguradoId );
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPut("actualizar")]
        public ApplicationResponse<string> UpdateVehiculo([FromBody] VehiculoSimpleDTO vehiculo)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _vehiculoDao.updateVehiculo(vehiculo);
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