using System;

namespace administracion.Persistence.Entities
{
    public class Incidente
    {
        public Guid incidenteId {get; set;} 
        public Guid polizaId {get; set;}
        public Poliza poliza {get; set;}
        public EstadoPoliza estado {get; set;} 
    }
}

public enum EstadoPoliza
{
    Pendiente,
    Analizando,
    Por_solucionar,
    cerrado

}