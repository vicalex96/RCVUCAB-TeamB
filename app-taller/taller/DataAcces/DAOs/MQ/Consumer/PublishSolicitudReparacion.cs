namespace taller.DataAccess.DAOs.MQ
{
    public record PublishSolicitudReparacion
    {
        public string? Id {get; set;}
        public string? incidenteId {get; set;}
        public string? vehiculoId {get; set;}
        public string? tallerId {get; set;}
    }
}