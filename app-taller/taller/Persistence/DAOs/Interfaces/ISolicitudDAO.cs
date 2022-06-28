
using taller.Persistence.Entities;
using taller.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace administracion.Persistence.DAOs
{
    public interface ISolicitudDAO
    {
        public string RegisterVehiculosPorAPI(List<VehiculoDTO> vehiculos);
        public string RegisterSolicitudesPorAPI(List<SolicitudDTO> solicitudes);
        
        public string RegisterRequerimientosPorAPI(List<RequerimientoDTO> requerimientos);
        
    }
}