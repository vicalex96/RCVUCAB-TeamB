
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
//using taller.DataAcces.Entities;

namespace taller.BussinesLogic.DTOs
{
    /// <summary>
    /// DTO para mostrar informacion de CotizacionReparacion
    /// </summary>

    public class CotizacionRepDTO
    {  
        public Guid CotizacionRepId {get; set;}
        public Guid tallerId {get; set;}
        public float costoManoObra {get; set;}
        public string estado {get; set;} = "";
        public DateTime fechaInicioReparacion {get; set;}
        public DateTime fechaFinReparacion { get; set;}
        public Guid solicitudRepId {get; set;}
    }
}
        
