namespace administracion.Persistence.Entities
{
    public class Poliza
    {
        public Guid polizaId {get; set;}
        public DateTime fechaRegistro {get; set;}
        public DateTime fechaVencimiento {get; set;}
        public TipoPoliza tipoPoliza {get; set;}

        public Guid vehiculoId {get; set;}
        public Vehiculo vehiculo {get; set;}
        public ICollection<Incidente>? incidente {get; set;}
    }

    public enum TipoPoliza {
        CoberturaCompleta,
        DaniosATerceros
    }
}