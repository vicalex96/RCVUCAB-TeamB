
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using administracion.DataAccess.Entities;
using System.Text.Json.Serialization;

namespace administracion.BussinesLogic.DTOs
{
    /// <summary>
    /// DTO para registrar una poliza
    /// </summary>
    public class PolizaRegisterDTO
    {
        public DateTime fechaRegistro {get; set;}
        public DateTime fechaVencimiento {get; set;}
        public string tipoPoliza {get; set;} = "";
        
        public Guid vehiculoId {get; set;}
    }
}
