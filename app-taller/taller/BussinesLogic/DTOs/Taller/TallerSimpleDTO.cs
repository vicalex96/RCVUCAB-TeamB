using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taller.DataAcces.Entities;
using System.Text.Json.Serialization;

namespace taller.BussinesLogic.DTOs
{
    public class TallerSimpleDTO
    {
        public Guid TallerId { get; set; }
        public string nombreLocal {get; set;} 
    }
}
