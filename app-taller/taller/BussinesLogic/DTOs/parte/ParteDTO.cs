using taller.Exceptions;
using taller.DataAccess.Entities;

namespace taller.BussinesLogic.DTOs
{
    public class ParteDTO
    {
        public Guid Id {get; set;}
        public string nombre {get; set;} = "";
    }

}