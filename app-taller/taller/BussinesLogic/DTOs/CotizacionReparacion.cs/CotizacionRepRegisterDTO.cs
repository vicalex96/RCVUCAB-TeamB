using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace taller.BussinesLogic.DTOs
{
    /// <summary>
    /// DTO para registrar incidente
    /// </summary>
    public class CotizacionRepRegisterDTO
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