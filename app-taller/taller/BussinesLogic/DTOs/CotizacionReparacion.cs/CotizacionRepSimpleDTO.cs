
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using taller.DataAcces.Entities;

namespace taller.BussinesLogic.DTOs
{
    public class CotizacionRepSimpleDTO
    {  
        public Guid Id {get; set;}
        public Guid tallerId {get; set;}
        public int porcentaje {get; set;}
        public float costoManoObra {get; set;}
        public Guid solicitudRepId {get; set;}
    }
}
        
