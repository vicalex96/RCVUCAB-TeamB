
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

        public Asegurado( string nombre, string apellido)
        {
            aseguradoId = Guid.NewGuid();
            this.nombre = nombre;
            this.apellido = apellido;
        }
        public Asegurado( Guid ID, string nombre, string apellido)
        {
            aseguradoId = ID;
            this.nombre = nombre;
            this.apellido = apellido;
        }
        public Asegurado()
        {
        }

    }
}