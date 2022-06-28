namespace taller.Persistence.Entities
{
    public class CotizacionReparacion
    {
        
        public Guid cotizacionRepId {get; set;}
        public Guid tallerId {get; set;}
        public float costoManoObra {get; set;}
        public EstadoCotRep estado {get; set;}
        public DateTime fechaInicioReparacion {get; set;}
        public DateTime fechaFinReparacion { get; set;}
        
        public Guid solicitudRepId {get; set;}
        public SolicitudReparacion? solicitud {get; set;}

    }

    public enum EstadoCotRep 
    {
        Pendiente,
        Cotizado,
        OrdenDeCompra,
        Facturado
    }
}