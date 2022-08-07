
using taller.DataAcces.Entities;
using taller.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace taller.DataAcces.DAOs
{
    public interface ISolicitudDAO
    {
        public List<SolicitudDTO> GetSolicitudes();
    }
}