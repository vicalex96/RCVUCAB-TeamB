using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using  taller.DataAcces.Enums;

namespace   taller.DataAcces.Entities
{
    public class MarcaEntity
    {

        [Key]
        public Guid Id {get; set;}
        public bool manejaTodas {get; set;}= false;
        public MarcaName? marcaName {get; set;} = null;

        public MarcaEntity ()
        {
            Id = Guid.NewGuid();
        }


    }
}