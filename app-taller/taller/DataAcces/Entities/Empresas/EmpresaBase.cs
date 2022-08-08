
using System.ComponentModel.DataAnnotations;

namespace  taller.DataAccess.Entities
{
    public class EmpresaBase<T>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string nombreLocal {get; set;} ="";
        public ICollection<T>? marcas {get; set;}
        

        public EmpresaBase ()
        {
            Id = Guid.NewGuid();
        }
    }
}