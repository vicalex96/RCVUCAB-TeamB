using System;
using System.Collections.Generic;

namespace administracion.Persistence.Entities
{
    public class Taller: Usuario
    {
        public List<Marca> especializaciones {get; set;}

    }
}