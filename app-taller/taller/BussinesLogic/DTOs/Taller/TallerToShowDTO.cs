using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace taller.BussinesLogic.DTOs
{
    public class TallerToShowDTO
    {
        public Guid Id {get; set;}
        public ICollection<MarcaDTO>? marcas {get; set;} 
        
    }

}