using Microsoft.AspNetCore.Mvc;
//using taller.Conections.APIs;
using taller.BussinesLogic.DTOs;
using taller.DataAcces.Entities;
using taller.DataAcces.Enums;
using taller.DataAcces.DAOs;
using taller.Responses;
using taller.Exceptions;
using System.ComponentModel.DataAnnotations;
using taller.BussinesLogic.Commands;


namespace taller.Controllers
{
    [ApiController]
    [Route("Cotizaciones")]
    public class CotizacionController : Controller
    {
        private readonly ICotizacionRepDAO _CotizacionDao;
        private readonly ILogger<CotizacionController> _logger;

        public CotizacionController(ILogger<CotizacionController> logger, ICotizacionRepDAO CotizacionDao)
        {
            _CotizacionDao = CotizacionDao;
            _logger = logger;
        }

        [HttpGet("mostrar_todos")]
        public ApplicationResponse<List<CotizacionRepDTO>> ConsultarTodos()
        {
            var response = new ApplicationResponse<List<CotizacionRepDTO>>();
            try
            {
                response.Data = _CotizacionDao.GetAll();
                response.Success = true;
                response.Message = "Cotizaciones encontradas";
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }

        [HttpGet("mostrar_por/{solictudId}")]
        public ApplicationResponse<CotizacionRepDTO> ConsultarCotizaciones([Required][FromRoute] Guid solictudId)
        {
            var response = new ApplicationResponse<CotizacionRepDTO>();
            try
            {
                response.Data = _CotizacionDao.GetCotizacionRep(solictudId);
                response.Success = true;
                response.Message = "Cotizaciones encontradas";
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }

        [HttpPost("registrar")]
        public ApplicationResponse<Guid> RegistrarCotizacion([Required][FromBody] CotizacionRepRegisterDTO cotizacionid)
        {
           var response = new ApplicationResponse<Guid>();
            try
            {
                RegisterCotizacionRepCommand command = CotizacionRepCommandFactory.createRegisterCotizacionRepCommand(cotizacionid);
                command.Execute();

                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Cotizacion registrada";
            }
            catch (RCVException ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Message = ex.Mensaje;
                response.Success = false;
            }
            return response;
        }

        [HttpPatch("actualizar/estado/{cotizacionId}/{estado}")]
        public ApplicationResponse<bool> ActualizarEstadoCotizacion([Required][FromRoute] Guid cotizacionId, [Required][FromRoute] EstadoCotRep estado)
        {
            var response = new ApplicationResponse<bool>();
            try
            {
                response.Data = _CotizacionDao.UpdateEstadoCotizacion(cotizacionId, estado);
                response.Success = true;
                response.Message = "Cotizacion actualizada";
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }
    
        [HttpPatch("actualizar/fechaInicio/{cotizacionId}/{fechaInicio:Datetime}")]
        public ApplicationResponse<bool> ActualizarFechaInicioCotizacion([Required][FromRoute] Guid cotizacionId, [Required][FromRoute] DateTime fechaInicio)
        {
            var response = new ApplicationResponse<bool>();
            try
            {
                response.Data = _CotizacionDao.UpdateFechaInicioReparacion(cotizacionId, fechaInicio);
                response.Success = true;
                response.Message = "Cotizacion actualizada";
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }

        [HttpPatch("actualizar/fechaFin/{cotizacionId}/{fechaFin:Datetime}")]
        public ApplicationResponse<bool> ActualizaFechaFinCotizacion([Required][FromRoute] Guid cotizacionId, [Required][FromRoute] DateTime fechaFin)
        {
            var response = new ApplicationResponse<bool>();
            try
            {
                response.Data = _CotizacionDao.UpdateFechaFinReparacion(cotizacionId, fechaFin);
                response.Success = true;
                response.Message = "Cotizacion actualizada";
            }
            catch (RCVException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }


    }
}
