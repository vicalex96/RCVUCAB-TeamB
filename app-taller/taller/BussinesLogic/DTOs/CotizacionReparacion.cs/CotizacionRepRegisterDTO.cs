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
        public Guid tallerId {get; set;}
    }

}