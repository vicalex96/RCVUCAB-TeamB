using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taller.DataAcces.Entities
{
    public class SolicitudReparacion
    {
        [Key]
        public Guid Id {get; set;}
        public Guid tallerId {get; set;}
        public Guid RequerimientoId {get; set;}

        public DateTime fechaSolicitud {get; set;}

        
        public virtual ICollection<Requerimiento>? requerimientos {get; set;}

        public SolicitudReparacion(){
            Id = Guid.NewGuid();
        }
    }
}