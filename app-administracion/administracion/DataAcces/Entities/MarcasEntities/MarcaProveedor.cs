using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace   administracion.DataAccess.Entities
{
    public class MarcaProveedor: MarcaEntity
    {
        [Required]
        public Guid proveedorId { get; set; }
        [ForeignKey("proveedorId")]
        public Proveedor? proveedor {get; set;}
    }
}
