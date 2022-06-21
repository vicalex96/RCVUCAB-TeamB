
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace administracion.Persistence.Entities
{
    public class Asegurado
    {
        public Guid aseguradoId {get; set;}
        public string nombre {get; set;}
        public string apellido {get; set;}
        public virtual ICollection<Vehiculo>? vehiculos {get; set;}
    }
}