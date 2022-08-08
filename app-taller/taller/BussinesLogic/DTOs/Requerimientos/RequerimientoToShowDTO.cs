using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace taller.BussinesLogic.DTOs
{
    public class RequerimientoToShowDTO
    {
      
        public Guid solicitudId {get; set;}
        public Guid parteId {get; set;}
        public string tipoRequerimiento {get; set;} = "";
        public int cantidad {get; set;}
        public ParteDTO? parte {get; set;}
        public ICollection<ParteDTO>? partes {get; set;} 
        
    }

}