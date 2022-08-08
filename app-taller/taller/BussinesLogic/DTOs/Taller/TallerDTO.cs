using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taller.DataAcces.Entities;
using System.Text.Json.Serialization;

namespace taller.BussinesLogic.DTOs
{
    /// <summary>
    /// DTO para mostra informacion de un Taller
    /// </summary>
    public class TallerDTO
    {
        public Guid TallerId { get; set; }
        public string nombreLocal {get; set;} = "";
        public ICollection<MarcaDTO>? marcas {get; set;} 
    }
}
