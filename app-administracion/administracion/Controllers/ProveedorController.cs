using Microsoft.AspNetCore.Mvc;
using administracion.BussinesLogic.DTOs;
using  administracion.DataAccess.DAOs;
using administracion.Exceptions;
using administracion.Responses;
using System.ComponentModel.DataAnnotations;
using administracion.BussinesLogic.Commands;

namespace administracion.Controllers
{
    /// <summary>
    /// Clase que contiene los endpoints el trabajo con proveedores
    /// </summary>
    [ApiController]
    [Route("Proveedor")]
    public class ProveedorController: Controller
    {
        private readonly ILogger<ProveedorController> _logger;

        public ProveedorController(ILogger<ProveedorController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Mostrar un listado de proveedores que existen en el sistema
        /// </summary>
        /// <returns>Proveedores en sistema</returns>
        [HttpGet("mostrar_todos")]
        public ApplicationResponse<List<ProveedorDTO>> ConsultarProveedores()
        {
            var response = new ApplicationResponse<List<ProveedorDTO>>();
            try
            {
                GetProveedoresCommand command = ProveedorCommandFactory.createGetProveedoresCommand();

                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Listado de proveedores cargado";
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
        /// Busca un proveedor en el sistema según el Id del proveedor
        /// </summary>
        /// <param name="proveedorId">Id del proveedor</param>
        /// <returns>Proveedor</returns>
        [HttpGet("buscar_por/{proveedorId}")]
        public ApplicationResponse<ProveedorDTO> ConsultarProveedorPorId([Required][FromRoute] Guid proveedorId)
        {
            var response = new ApplicationResponse<ProveedorDTO>();
            try
            {
                GetProveedoresByGuidCommand command = ProveedorCommandFactory.createGetProveedoresByGuidCommand(proveedorId);

                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = " Proveedor encontrado";
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
        /// Registra un proveedor en el sistema
        /// </summary>
        /// <param name="proveedorRegisterDTO">Proveedor a registrar</param>
        /// <returns>Proveedor registrado</returns>
        [HttpPost("registrar")]
        public ApplicationResponse<Guid> RegistrarProveedor([FromBody] ProveedorRegisterDTO proveedor)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                RegisterProveedorLogicCommand command = ProveedorCommandFactory.createRegisterProveedorLogicCommand(proveedor);

                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = " Proveedor registrado";
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
        /// Actualiza un proveedor indicado segun su id, se puede agregar una marca o incidar que trabaja con todas
        /// </summary>
        /// <param name="proveedorRegisterDTO">Proveedor a actualizar</param>
        /// <returns>Proveedor actualizado</returns>
        [HttpPatch("agregar_marca/{proveedorId}/{marca}")]
        public ApplicationResponse<Guid> AgregarMarcaAproveedor([FromRoute] Guid proveedorId, [FromRoute] string marca)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                AddMarcaProveedorLogicCommand command = ProveedorCommandFactory.createAddMarcaProveedorLogicCommand(proveedorId, marca);

                command.Execute();
                response.Data = command.GetResult();
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Success = true;
                response.Message = " Marca agregada";
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
        /// Especializa el proveedor en todas las marcas
        /// </summary>
        /// <param name="proveedorId">Id del proveedor</param>
        /// <returns>Boleano true si todo salio bien</returns>
        [HttpPatch("agrega_marca/todas/{proveedorId}")]
        public ApplicationResponse<Guid> AgregarTodasLasMarcasAProveedor([FromRoute] Guid proveedorId)
        {
            var response = new ApplicationResponse<Guid>();
            try
            {
                AddAllMarcasProveedorLogicCommand command = ProveedorCommandFactory.createAddAllMarcasProveedorLogicCommand(proveedorId);

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
        }
    }
}