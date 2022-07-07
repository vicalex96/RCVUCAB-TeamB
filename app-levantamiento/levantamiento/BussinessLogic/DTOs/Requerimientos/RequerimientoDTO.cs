namespace levantamiento.BussinesLogic.DTOs
{
    public class RequerimientoDTO
    {
        public Guid Id {get; set;}
        public Guid solicitudId {get; set;}
        public Guid parteId {get; set;}
        public string descripcion {get; set;}
        public string tipoRequerimiento {get; set;}
        public int cantidad {get; set;}
        public ParteDTO parte {get; set;}
    }
}