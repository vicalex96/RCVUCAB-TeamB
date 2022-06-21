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
    [Route("Incidente")]
    public class IncidenteController: Controller
    {
        private readonly IIncidenteDAO _incidenteDao;
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger, IIncidenteDAO incidenteDao)
        {
            _incidenteDao = incidenteDao;
            _logger = logger;
        }





        [HttpPost("registrar")]
        public ApplicationResponse<string> registrarIncidente([FromBody] IncidenteSimpleDTO incidente)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _incidenteDao.registrarIncidente(incidente);
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }

        [HttpGet("consultar/{incidenteID}")]
        public ApplicationResponse<IncidenteDTO> consultarIncidente([Required][FromRoute] Guid incidenteID)
        {
            var response = new ApplicationResponse<IncidenteDTO>();
            try
            {
                response.Data = _incidenteDao.consultarIncidente(incidenteID);
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }

        [HttpGet("consultar_lista_activos")]
        public ApplicationResponse<List<IncidenteDTO>> ConsultarIncidentesActivos()
        {
            var response = new ApplicationResponse<List<IncidenteDTO>>();
            try
            {
                response.Data = _incidenteDao.ConsultarIncidentesActivos();
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }

        [HttpPatch("actualizar/{incidenteID}/{estado}")]
        public ApplicationResponse<string> actualizarIncidente([Required][FromRoute] Guid incidenteID, [Required][FromRoute] EstadoPoliza estado)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _incidenteDao.actualizarIncidente(incidenteID, estado);

            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }


/*
        [HttpGet("consultar_por_vehiculo/{vehiculoID}")]
        public ApplicationResponse<IncidenteDTO> consultarIncidenteDeVehiculo([Required][FromRoute] Guid vehiculoID)
        {
            var response = new ApplicationResponse<IncidenteDTO>();
            try
            {
                response.Data = _incidenteDao.consultarIncidenteDeVehiculo(vehiculoID);
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }

        [HttpGet("consultar_por_poliza/{polizaID}")]
        public ApplicationResponse<List<IncidenteDTO>> consultarIncidentesDePoliza([Required][FromRoute] Guid polizaID)
        {
            var response = new ApplicationResponse<List<IncidenteDTO>>();
            try
            {
                response.Data = _incidenteDao.consultarIncidentesDePoliza(polizaID);
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }

        [HttpGet("consultar_por_cliente/{clienteID}")]
        public ApplicationResponse<List<
/*
        [HttpPost("registrar")]
        public ApplicationResponse<string> registrarPoliza([FromBody] PolizaSimpleDTO poliza)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _polizaDao.registrarPoliza(poliza);
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }

        [HttpGet("consultar_por_vehiculo/{vehiculoID}")]
        public ApplicationResponse<PolizaDTO> consultarPolizaDeVehiculo([Required][FromRoute] Guid vehiculoID)
        {
            var response = new ApplicationResponse<PolizaDTO>();
            try
            {
                response.Data = _polizaDao.consultarPolizaDeVehiculo(vehiculoID);
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
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
 */   
    }
}