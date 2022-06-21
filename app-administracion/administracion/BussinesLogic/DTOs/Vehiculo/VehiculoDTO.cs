
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using administracion.Persistence.Entities;

namespace administracion.BussinesLogic.DTOs
{
    public class VehiculoDTO
    {
        public Guid Id { get; set; }
        public int anioModelo { get; set; }
        public DateTime fechaCompra { get; set; }
        public string color { get; set; }

        public string placa { get; set; }
        public string marca {get; set;}
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual AseguradoDTO? asegurado { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<PolizaDTO>? polizas {get; set;}
    }
}
