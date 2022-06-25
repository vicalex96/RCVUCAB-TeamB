using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proveedor.BussinesLogic.DTOs;
using proveedor.Persistence.DAOs;
using proveedor.Exceptions;
using proveedor.Responses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proveedor.Controllers
{
    [ApiController]
    [Route("CotizacionParte")]
    public class CotizacionParteController: Controller
    {
        private readonly ICotizacionParteDAO _cotpatDAO;
        private readonly ILogger<CotizacionParteController> _logger;

        public CotizacionParteController(ILogger<CotizacionParteController> logger, ICotizacionParteDAO cotpatDAO)
        {
            _cotpatDAO = cotpatDAO;
            _logger = logger;
        }

        [HttpGet("mostrar_todas_Las_cotizacionesPartes")]
        public ApplicationResponse<List<CotizacionParteDAO>> GetCotizacionPartes()
        {
            var response = new ApplicationResponse<List<CotizacionParteDAO>>();
            try
            {

                response.Data = _cotpatDAO.GetCotizacionPartes();
            }
            catch (ProveedorException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        
        [HttpGet("consultarCotpat_por/{estado}")]
        public ApplicationResponse<CotizacionParteDAO> GetCotizacionPartesByestado([Required][FromRoute] EstadoCotPt estado)
        {
            var response = new ApplicationResponse<CotizacionParteDAO>();
            try
            {
                response.Data = _cotpatDAO.GetCotizacionPartesByestado(estado);
            }
            catch (ProveedorException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }


        [HttpPatch("actualizar/{CotPtID}/{estado}")]
        public ApplicationResponse<string> actualizarCotizacionParte([Required][FromRoute] Guid CotizacionParteID, [Required][FromRoute] EstadoCotPt estado)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _cotpatDAO.actualizarCotizacionParte(CotizacionParteID, estado);

            }
            catch (ProveedorException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            };
            return response;
        }
    }
}