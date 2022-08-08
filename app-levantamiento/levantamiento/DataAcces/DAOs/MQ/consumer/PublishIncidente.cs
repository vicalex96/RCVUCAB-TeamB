namespace levantamiento.DataAccess.DAOs.MQ
{
    public record PublishIncidente
    {
        public string? Id {get; init;}
        public string? polizaId {get; init;}
    }
}