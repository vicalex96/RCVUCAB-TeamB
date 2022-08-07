using taller.DataAcces.Entities;
using taller.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace taller.DataAcces.DAOs
{
    public interface IParteDAO
    {
        public List<ParteDTO> GetPartes();
        public bool RegisterParte(ParteDTO parte);
        
    }


}