using proveedor.Persistence.Entities;
using proveedor.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace administracion.Persistence.DAOs
{
    public interface ICotizacionParteDAO
    {
        public string actualizarCotizacionParte(Guid CotizacionParteID, EstadoCotPt estado);
        public string createCotizacionParte(CotizacionParteDTO cotPt);
        public List<CotizacionParteDAO> GetCotizacionPartes();
        public CotizacionParteDTO GetCotizacionPartesByestado(EstadoCotPt estado);
        public string actualizarCotizacionParte(Guid CotizacionParteID, EstadoCotPt estado);
       
    }
}