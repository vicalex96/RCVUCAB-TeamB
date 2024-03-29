using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using  taller.DataAcces.Enums;

namespace taller.DataAcces.Entities

{
    public class CotizacionReparacion
    {
        
        public Guid cotizacionRepId {get; set;}
        public Guid tallerId {get; set;}
        public float costoManoObra {get; set;}
        public EstadoCotRep  estado {get; set;}
        public DateTime fechaInicioReparacion {get; set;}
        public DateTime fechaFinReparacion { get; set;}
        
        public Guid solicitudRepId {get; set;}
       // public virtual SolicitudReparacion? solicitud {get; set;}

        public static bool IsEstado (string estado)
        {
            try{
                EstadoCotRep result = (EstadoCotRep)Enum.Parse(typeof(EstadoCotRep), estado);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public static EstadoCotRep ConvertToEstado (string estado)
        {
            return ( EstadoCotRep ) Enum
                .Parse( typeof(EstadoCotRep), estado );
        }
    }


}