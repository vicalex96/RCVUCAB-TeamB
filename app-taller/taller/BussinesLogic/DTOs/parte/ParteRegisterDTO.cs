using taller.Exceptions;
using taller.DataAccess.Entities;

namespace taller.BussinesLogic.DTOs
{
    public class ParteRegisterDTO
    {
        public Guid Id {get; set;}
        public string nombre {get; set;} = "";
    }

}