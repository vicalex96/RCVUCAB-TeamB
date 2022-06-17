using System;
using System.Collections.Generic;

namespace administracion.Persistence.Entities
{
    public class Vehiculo
    {
        public Guid vehiculoId { get; set; }
        public int anioModelo { get; set; }
        public DateTime fechaCompra { get; set; }
        public Color color { get; set; }
        public string placa { get; set; }
        public Marca marca {get; set;}


        public Guid aseguradoId {get; set;}
        public virtual Asegurado? asegurado { get; set; }
        public virtual ICollection<Poliza>? polizas {get; set;}

    }

    public enum Color
    {
        Rojo,
        Verde,
        Azul_oscuro,
        Azul_claro,
        Amarillo,
        Morado,
        Naranja,
        Marron,
        Violeta,
        Plateado,
        Dorado,
        Cobre,
        Blanco,


    }


}