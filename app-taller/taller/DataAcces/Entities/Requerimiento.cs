using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using taller.DataAcces.Enums;

namespace taller.DataAcces.Entities
{
    public class Requerimiento
    {
        public Guid requerimientoId {get; set;}
        public Guid solicitudRepId {get; set;}
        public Guid parteId {get; set;}
        public TipoRequerimiento tipoRequerimiento {get; set;}
        public int cantidad {get; set;}
        public EstadoRequerimiento? estado {get; set;}

        [ForeignKey("solicitudReparacionId")]
        public virtual SolicitudReparacion? solicitudReparacion {get; set;}
        public ICollection<CotizacionReparacion>? cotizacionesParte {get; set;} 
        public Parte parte {get; set;}
        
        public static bool IsTipoRequerimiento (string tipo)
        {
            try{
                TipoRequerimiento result = (TipoRequerimiento)Enum.Parse(typeof(TipoRequerimiento), tipo);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public static TipoRequerimiento ConvertToTipoRequerimiento (string tipo)
        {
            return ( TipoRequerimiento ) Enum
                .Parse( typeof(TipoRequerimiento), tipo );
        }

        public static bool IsEstado (string estado)
        {
            try{
                EstadoRequerimiento result = (EstadoRequerimiento)Enum.Parse(typeof(EstadoRequerimiento), estado);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public static EstadoRequerimiento ConvertToEstado (string estado)
        {
            return ( EstadoRequerimiento ) Enum
                .Parse( typeof(EstadoRequerimiento), estado );
        }

        
    }
    public enum TipoRequerimiento
    {
        Reparacion,
        ComprarPieza
    }

    public enum EstadoRequerimiento
    {
        PorEntregar,
        Entregado
    }
}