//using System;

namespace administracion.Persistence.Entities
{
    public class Usuario
    {
        public Guid usuarioId {get; set;}
        public string nombreReal {get; set;}
        public string username {get; set;}
        public string password {get; set;}
        public string correo {get; set;}
    }
}