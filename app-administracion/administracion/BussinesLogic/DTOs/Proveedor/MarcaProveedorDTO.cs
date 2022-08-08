using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  administracion.DataAccess.Entities;
using System.Text.Json.Serialization;
using administracion.DataAccess.Enums;

namespace administracion.BussinesLogic.DTOs
{
    /// <summary>
    /// DTO para mostra informacion de una MarcaTaller
    /// </summary>
    public class MarcaProveedorDTO
    {
        public Guid Id {get; set;}
        public Guid ProveedorId { get; set; }
        public bool manejaTodas {get; set;}= false;
        public MarcaName? marcaName {get; set;} = null;
    }
}
