
using administracion.Persistence.Entities;
using administracion.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace administracion.Persistence.DAOs
{
    public interface IIncidenteDAO
    {
        public string registrarIncidente (IncidenteSimpleDTO incidente);
        public IncidenteDTO consultarIncidente(Guid incidenteID);

        public List<IncidenteDTO> ConsultarIncidentesActivos();
        public string actualizarIncidente(Guid incidenteId, EstadoPoliza estado);
    }
}