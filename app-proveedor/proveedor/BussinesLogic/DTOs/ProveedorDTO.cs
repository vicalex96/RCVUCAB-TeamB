using System;

namespace proveedor.BussinesLogic.DTOs
{
    public class ProveedorDTO
    {
        public Guid ProveedorId {get; set;}
        public virtual ICollection<CotizacionParteDTO>? cotizacionPs {get; set;}

        public string CreatedAt { get; set; }
    }
}
